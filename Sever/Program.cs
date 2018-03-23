using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Sever
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int recv;
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(ipep);
            Console.WriteLine("doi thang client...");
            IPEndPoint sender = ipep;
            EndPoint Remote = (EndPoint)ipep;
            recv = sock.ReceiveFrom(data, ref Remote);
            Console.WriteLine("tin nhan tu {0}:", Remote.ToString());
            while (true)
            {
                data = new byte[1024];
                recv = sock.ReceiveFrom(data, ref Remote);
                string k = Encoding.ASCII.GetString(data, 0, recv);
                if (k == "1") Console.WriteLine("{0} chon bua ", Remote.ToString());
                if (k == "2") Console.WriteLine("{0} chon keo ", Remote.ToString());
                if (k == "1") Console.WriteLine("{0} chon bao ", Remote.ToString());
                int n = rd.Next(1, 4);
                if (n == 1) Console.WriteLine("ban chon Búa");
                if (n == 2) Console.WriteLine("ban chon kéo ");
                if (n == 3) Console.WriteLine("ban chon bao ");
                sock.SendTo(Encoding.ASCII.GetBytes(n.ToString()), recv, SocketFlags.None, Remote);
            }

        }
    }
}
