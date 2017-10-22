using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Bai3_DHCP_Server
{
    class dhcpd
    {
        private TcpListener server;
        private TcpClient client;
        private NetworkStream netStream;
        private byte[] dataSend, dataReceive;

        byte start, end;
        List<bool> available;
        string lease = "192.168.1.";

        public dhcpd(byte start, byte end)
        {
            Console.WriteLine("Server init components...");
            this.start = start;
            this.end = end;
            this.available = new List<bool>();
            for (int i = 0; i < 255; i++)
            {
                available.Add(true);
            }

            dataReceive = new byte[1024];
            dataSend = new byte[1024];

            server = new TcpListener(IPAddress.Any, 1724);
        }

        public void startListening()
        {
            Console.WriteLine("Server listening...");
            server.Start();
            client = server.AcceptTcpClient();
            netStream = client.GetStream();
            Console.WriteLine("Server accepted a client...");

            int dataSize = netStream.Read(dataReceive, 0, 1024);
            string data = Encoding.ASCII.GetString(dataReceive, 0, dataSize);
            if (data == "DISCOVER")
            {
                string ret = dhcpRequest();
                dataSend = Encoding.ASCII.GetBytes(ret);
                netStream.Write(dataSend, 0, ret.Length);
                Console.WriteLine("Server offered:" + ret);
            }
            dataSize = netStream.Read(dataReceive, 0, 1024);
            data = Encoding.ASCII.GetString(dataReceive, 0, dataSize);
            if (data == "FYN")
            {
                client.Close();
                netStream.Close();
                Console.WriteLine("Server disconnected a client...");
            }
        }

        private string dhcpRequest()
        {
            for (int i = 0; i < end - start; i++)
                if (available[i + start])
                {
                    available[i + start] = false;
                    return lease + (i + start).ToString();
                }
            return lease + "0";
        }
    }
}
