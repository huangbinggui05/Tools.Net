using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HBG.Examples.Socket.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            new SocketClient().Run();

            while (true)
            {
                Thread.Sleep(30 * 1000);
            }
        }
    }
}
