using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptManager
{
    public class ConnectionChangedEventArgs : EventArgs
    {
        ConnectionState _state;
        public ConnectionState State
        {
            get { return _state; }
        }

        public ConnectionChangedEventArgs(ConnectionState state)
        {
            _state = state;
        }

        public enum ConnectionState
        {
            None = 0,
            Connected = 1,
            Disconnected = 2,
        }
    }
}
