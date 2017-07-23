using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPClient
{
    class TClient
    {
        TcpClient client;
        IPEndPoint ep;
        NetworkStream stream;
        public TClient()
        {
            ep = new IPEndPoint(IPAddress.Loopback, 12345);
        }

        private bool Connect()
        {

            try
            {
                client = new TcpClient();
                client.Connect(ep);
                stream = client.GetStream();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        private void Close()
        {
            client.Close();
        }

        public bool SendMessage(string msg)
        {
            if (!Connect())
            {
                return false;
            }
            stream.Write(Encoding.ASCII.GetBytes(msg), 0, msg.Length);
            stream.Close();
            Close();
            return true;
        }
    }
}
