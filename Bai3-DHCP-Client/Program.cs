
namespace Bai3_DHCP_Client
{
    class Program
    {
        private static dhcClient client;
        static void Main(string[] args)
        {
            client = new dhcClient();
            System.Console.WriteLine("Received: " + client.requestAddress());
            System.Console.ReadKey();
        }
    }
}
