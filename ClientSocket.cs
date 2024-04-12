using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TestConsole
{
    public class ClientSocket
    {
        Socket _socket;
        IPAddress _ipAddress;
        IPEndPoint _endPoint;
        bool _isShutdown;
        SocketType _socketType;
        ProtocolType _protocolType;
        private int _bytesAvailable;
        private Thread _thread;
        private bool _isPolling;
        string _messageEnd;

        public int BytesAvailable
        {
            get { return _bytesAvailable; }
        }

        public bool IsPolling
        {
            get { return _isPolling; }
        }
        public ClientSocket(IPAddress ip, int port,  SocketType socketType, ProtocolType protocolType, string messageEnd)
        {
            _ipAddress = ip;
            _endPoint = new IPEndPoint(_ipAddress, port);
            _socketType = socketType;
            _protocolType = protocolType;
            _socket = new Socket(_endPoint.AddressFamily, _socketType, _protocolType);
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            _socket.Connect(_endPoint);
            _bytesAvailable = 0;
            _thread = new Thread(new ThreadStart(CheckBytes));
            _isShutdown = false;
            _isPolling = false;
            _messageEnd = messageEnd;
        }

        public bool SendMessage(string message)
        {
            if (!_socket.Connected)
            {
                _socket.Connect(_endPoint);
                if (!_socket.Connected)
                {
                    return false;
                }
                
            }
            byte[] messageInBytes = Encoding.UTF8.GetBytes(message + _messageEnd);
            _socket.Send(messageInBytes);
            
            return true;
        }

        public void StartPollingMessage(string message)
        {
            

            SetPollingON();
            new Thread(new ThreadStart(() =>
            {
                while (_isPolling)
                {
                    SendMessage(message);
                    Thread.Sleep(500);
                }
            })).Start();
        }

        private void CheckBytes()
        {
            while (!_isShutdown)
            {
                _bytesAvailable = _socket.Available;
                Thread.Sleep(100);
            }
            
        }

        public void StartCheckingForBytes()
        {
            _thread.Start();
        }

        public void ShutDown()
        {
            SetShutdownON();
            SetPollingOFF();
            //Thread.Sleep(400);
            //_socket.Disconnect(false);
        }


        public void Receive(byte[] buffer)
        {
            _socket.Receive(buffer);
        }


        private void SetPollingON()
        {
            _isPolling = true;
        }

        private void SetPollingOFF()
        {
            _isPolling = false;
        }

        private void SetShutdownON()
        {
            _isShutdown = true;
        }

        private void SetShutdownOFF()
        {
            _isShutdown = false;
        }
       
    }
}
