using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostName = Dns.GetHostName();
            Console.WriteLine(hostName);
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            Console.WriteLine("Dia chi IP cua may la:" + myIP);
            Console.ReadKey();
        }
    }
}
