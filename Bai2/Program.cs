using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            string ipAddress;
            int port;
            string protocol;
            Console.Write("Nhap Host IP: ");
            ipAddress = Console.ReadLine();
            Console.Write("Nhap Host Port: ");
            port = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap protocol: ");
            protocol = Console.ReadLine();

            switch (protocol)
            {
                case "TCP":
                    IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                    TcpClient client = new TcpClient();
                    try
                    {
                        client.Connect(ip);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Host: {0}:{1} is close", ipAddress, port);
                        Console.WriteLine(ex);
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Host: {0}:{1} is open", ipAddress, port);
                    break;
                case "UDP":
                    IPEndPoint ipudp = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                    UdpClient clientudp = new UdpClient();
                    try
                    {
                        clientudp.Connect(ipudp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Host: {0}:{1} is close", ipAddress, port);
                        Console.WriteLine(ex);
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Host: {0}:{1} is open", ipAddress, port);
                    break;
            }
        }
    }
}

