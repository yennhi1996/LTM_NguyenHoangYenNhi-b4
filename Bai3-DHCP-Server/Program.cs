using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3_DHCP_Server
{
    class Program
    {
        private static dhcpd dhcpd;

        static void Main(string[] args)
        {
            dhcpd = new dhcpd(100, 150);
            while (true)
                dhcpd.startListening();
        }
    }
}
