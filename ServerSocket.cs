using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kuittisovellus
{
    public class ServerSocket
    {
        Socket _socket;
        IPEndPoint _ipEndPoint;
        SocketType _socketType;
        ProtocolType _protocolType;
        bool _shutdown;
        byte[] _data;
        List<Action<byte[]>>? _listeners;
        List<Action<Image, byte?>>? _listenersForImage;
        ServerNotificationMode _mode;
        string _messageEnd;
        Thread _thread;
        byte[] _orientationTag;
        byte? _orientation;


        public ServerSocket(int port, SocketType SocketType, ProtocolType protocolType, ServerNotificationMode mode, string messageEnd)
        {
            _ipEndPoint = new IPEndPoint(IPAddress.Any, port);
            _socketType = SocketType;
            _protocolType = protocolType;
            _socket = new Socket(_ipEndPoint.AddressFamily, _socketType, _protocolType);
            _socket.Blocking = true;
            _socket.Bind(_ipEndPoint);
            _shutdown = false;
            _listeners = new List<Action<byte[]>>();
            _listenersForImage = new List<Action<Image, byte?>>();
            _mode = mode;
            _messageEnd = messageEnd;
            _thread = new Thread(new ThreadStart(StartThread));
            _orientationTag = Encoding.UTF8.GetBytes("WO_");
            _orientation = null;
        }

        private void StartThread()
        {
            List<byte[]> bytesReceived = new List<byte[]>();

            Socket? connection = _socket.Accept();

            while (!_shutdown)
            {
                if (!IsCurrentConnectionAlive(connection))
                {
                    connection = _socket.Accept();
                }

                if (IfBytesAvailable(connection))
                {
                    
                    _data = GetAvailableData(connection); 

                    if (ContainsImageOrientationData(_data))
                    {
                        _orientation = ExtractImageOrientationByte(_data);
                        _data = RemoveImageOrientationData(_data);
                    }

                    if (IsImmediateNotification())
                    {
                        if (_listeners is not null)
                        {
                            InformListeners(_data);
                        }
                    }


                    bytesReceived.Add(_data);

                    if (CheckEndOfMessage(_data))
                    {

                        connection.Send(Encoding.UTF8.GetBytes(_messageEnd));


                        if (_mode == ServerNotificationMode.OnCompleteMessage)
                        {
                            byte[] finalBytes = JoinByteArrays(bytesReceived);

                            finalBytes = RemoveEndOfMessageFromBytes(finalBytes);

                            
                            InformListeners(finalBytes);
                            
                            InformImageListeners(finalBytes, _orientation);
                            
                            bytesReceived.Clear();

                        }
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void StartListening()
        {
            _socket.Listen(100);
            _thread.Start();
        }

        public void ShutDown()
        {
            _shutdown = true;
            _socket.Close();
        }

        


        public void RegisterListener(Action<byte[]> listener)
        {
            _listeners.Add(listener);
        }

        public void RegisterImageListener(Action<Image, byte?> listener)
        {
            _listenersForImage.Add(listener);
        }

        public enum ServerNotificationMode
        {
            None = 0,
            OnIncompleteReceive = 1,
            OnCompleteMessage = 2,
        }

        private int GetAmountOfItemsInArray<T>(T[] array)
        {
            int amount = 0;
            foreach (T item in array)
            {
                if (item != null)
                {
                    amount++;
                }
            }
            return amount;
        }

        private int ChangeNumberToNotNegative(int number)
        {
            if (number < 0)
            {
                return 0;
            }
            return 0;
        }

        private bool IsCurrentConnectionAlive(Socket connection)
        {
            if (connection.Poll(1000, SelectMode.SelectRead) & connection.Available == 0)
            {
                return false;
            }
            return true;
        }

        private bool IfBytesAvailable(Socket connection)
        {
            return connection.Available > 0;
        }

        private bool IsImmediateNotification()
        {
            return _mode == ServerNotificationMode.OnIncompleteReceive;
        }

        private byte[] GetAvailableData(Socket connection)
        {
            byte[] data = new byte[connection.Available];
            connection.Receive(data);
            return data;
        }


        private void InformListeners(byte[] data)
        {
            if (_listeners is null)
            {
                return;
            }
            foreach (Action<byte[]> action in _listeners)
            {
                byte[] copy = new byte[data.Length];
                data.CopyTo(copy, 0);
                action.Invoke(copy);


            }
        }

        private void InformImageListeners(byte[] data, byte? orientation)
        {
            if (_listenersForImage is null)
            {
                return;
            }

            Image img = CreateImage(data);
           
            foreach (Action<Image, byte?> action in _listenersForImage)
            {
                action.Invoke(img, orientation);
            }
            _orientation = null;
        }
        private Image CreateImage(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                stream.Seek(0, SeekOrigin.Begin);
                return Bitmap.FromStream(stream);
            }
        }



        private Image ConvertImageToJPEG(Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return Image.FromStream(stream);
            }
        }    

    private bool CheckEndOfMessage(byte[] data)
        {
            byte[] endOfMessage = Encoding.UTF8.GetBytes(_messageEnd);
            int counter = 1;
            for(int i = data.Length -1; i > data.Length - endOfMessage.Length; i--)
            {
                if (endOfMessage[endOfMessage.Length - counter] != data[i])
                {
                    return false;
                }
                counter++;
            }
            
            return true;
        }

        private byte[] JoinByteArrays(List<byte[]> arrays)
        {
            byte[] finalBytes = new byte[arrays.Sum(a => a.Length)];
            int position = 0;
            foreach (byte[] array in arrays)
            {
                array.CopyTo(finalBytes, position);
                position += array.Length;
            }

            return finalBytes;
        }

        private byte[] RemoveEndOfMessageFromBytes(byte[] data)
        {
            byte[] endOfMessage = Encoding.UTF8.GetBytes(_messageEnd);
            byte[] alteredData = data.Take(data.Length - endOfMessage.Length).ToArray();
            return alteredData;
        }

        private bool ContainsImageOrientationData(byte[] data)
        {
            
            if (data.Length < _orientationTag.Length)
            {
                return false;
            }
            byte[] dataTag = data.Take(_orientationTag.Length).ToArray();
            for (int i = 0; i < _orientationTag.Length; i++)
            {
                if (dataTag[i] != _orientationTag[i])
                {
                    return false;
                }
            }

            return true;
        }

        private byte ExtractImageOrientationByte(byte[] data)
        {
            byte[] withTag = data.Take(_orientationTag.Length + 1).ToArray();
            return withTag[withTag.Length - 1];
        }

        private byte[] RemoveImageOrientationData(byte[] data)
        {
            return data.Take(new Range(_orientationTag.Length + 1, data.Length - 1)).ToArray();
        }
    }

    
}
