using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TCPServer
{
    class TServer
    {
        TcpListener serverSocket;

        public TServer()
        {
            serverSocket = new TcpListener(IPAddress.Loopback, 12345);
            serverSocket.Start();
        }

        public async Task<string> waitConnection()
        {
            TcpClient client = await serverSocket.AcceptTcpClientAsync();
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[256];
            int len = await stream.ReadAsync(buffer, 0, 256);
            //stream.Read(buffer, 0, 256);
            string data = System.Text.Encoding.ASCII.GetString(buffer,0, len);

            client.Close();

            return data;
        }
    }
}
