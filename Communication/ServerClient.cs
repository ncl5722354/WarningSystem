using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Communication
{
    public class ServerClient
    {
        public TcpClient client;
        public byte[] receive_byte = new byte[8192];
        public ServerClient(TcpClient myclient)
        {
            client = myclient;
        }
    }
}
