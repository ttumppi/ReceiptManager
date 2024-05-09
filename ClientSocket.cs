using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ReceiptManager
{
    internal class ClientSocket
    {
        Socket _socket;
        IPAddress _ipAddress;
        IPEndPoint _endPoint;

        SocketType _socketType;
        ProtocolType _protocolType;

        volatile bool _running;

        string _messageEnd;
        byte[] _messageEndInBytes;
        bool _listening;

        static object _runningLock = new object();

        List<byte[]> _messages;

        static object _messageOperationsLock = new object();

        byte[] _receivedMessage;

        EventHandler<ConnectionChangedEventArgs>? _connectionHandler;
        
        public ClientSocket(IPAddress ip, int port, SocketType socketType, ProtocolType protocolType, string messageEnd)
        {
            _ipAddress = ip;
            _endPoint = new IPEndPoint(_ipAddress, port);
            _socketType = socketType;
            _protocolType = protocolType;
            _socket = new Socket(_endPoint.AddressFamily, _socketType, _protocolType);
            
            _messageEnd = messageEnd;
            _messageEndInBytes = Encoding.UTF8.GetBytes(_messageEnd);

            _running = false;
            _listening = false;
            _messages = new List<byte[]>();
            _receivedMessage = new byte[0];
        }

        private void StartClient()
        {
           while (_running)
            {
                if (Disconnected())
                {
                    InformListenersOnConnectionChange(ConnectionChangedEventArgs.ConnectionState.Disconnected);
                    break;
                }
                if (Listening())
                {
                    if (BytesAvailable())
                    {
                        AppendReceivedMessage(GetMessage());
                        if (EndOfMessageReceived())
                        {
                            SetToSend();
                        }
                    }
                }
                else
                {
                    if (SomethingToSend())
                    {
                        _socket.Send(AppendArrays(_messages[0], _messageEndInBytes));
                        RemoveOldestMessage();
                        SetToListen();
                    }
                }
            }
        }

        private bool TryConnect()
        {
            try
            {
                _socket.Connect(_endPoint);
                InformListenersOnConnectionChange(ConnectionChangedEventArgs.ConnectionState.Connected);
            }
            catch {
                return false;
            }
            return true;
        }
       

        public bool Start()
        {
            if (!TryConnect())
            {
                return false;
            }

            SetThreadToRunning();
            new Thread(new ThreadStart(StartClient)).Start();
            return true;
        }

        private bool Disconnected()
        {
            lock (_runningLock)
            {
                if (!ThreadRunning())
                {
                    return true;
                }

                bool poll = _socket.Poll(1000, SelectMode.SelectRead);
                bool bytesAvailable = _socket.Available == 0;

                return poll && bytesAvailable;
            }
            
        }

        private bool Listening()
        {
            return _listening;
        }

        private void SetToListen()
        {
            _listening = true;
        }

        private void SetToSend()
        {
            _listening = false;
        }

        private bool SomethingToSend()
        {
            return _messages.Count > 0;
        }

        public void AddMessage(byte[] message)
        {
            lock (_messageOperationsLock)
            {
                _messages.Add(message);
            }
        }

        private void RemoveOldestMessage()
        {
            lock (_messageOperationsLock)
            {
                _messages.RemoveAt(0);
            }
        }

        public void ShutDown()
        {
            SetThreadToShutdown();

            _socket.Close();
        }

        private void SetThreadToRunning()
        {
            lock (_runningLock)
            {
                _running = true;
            }
            
        }

        private void SetThreadToShutdown()
        {
            lock (_runningLock)
            {
                _running = false;
            }
            
        }

        private bool ThreadRunning()
        {
            return _running;
        }

        private byte[] AppendArrays(byte[] appendTo, byte[] appendFrom)
        {
            byte[] final = new byte[appendTo.Length + appendFrom.Length];

            appendTo.CopyTo(final, 0);
            appendFrom.CopyTo(final, appendTo.Length);
            return final;
        }

        private bool BytesAvailable()
        {
            return _socket.Available > 0;
        }

        private void AppendReceivedMessage(byte[] message)
        {
            _receivedMessage = AppendArrays(_receivedMessage, message);
        }

        private byte[] GetMessage()
        {
            byte[] message = new byte[_socket.Available];
            _socket.Receive(message);
            return message;
        }

        private bool EndOfMessageReceived()
        {
            
            int counter = 1;
            for (int i = _receivedMessage.Length - 1; i > _receivedMessage.Length - _messageEndInBytes.Length; i--)
            {
                if (_messageEndInBytes[_messageEndInBytes.Length - counter] != _receivedMessage[i])
                {
                    return false;
                }
                counter++;
            }

            return true;
        }

        public void RegisterConnectionChangedListener(EventHandler<ConnectionChangedEventArgs> listener)
        {
            _connectionHandler += listener;
        }

        private void InformListenersOnConnectionChange(ConnectionChangedEventArgs.ConnectionState state)
        {
            _connectionHandler?.Invoke(this, new ConnectionChangedEventArgs(state));
        }
    }
}
