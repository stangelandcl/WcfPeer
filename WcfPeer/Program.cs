using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace WcfPeer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args[0] == "server")
            {
                MultiServiceHost.Default.Add<PingService>();
                MultiServiceHost.Default.Open();
                Thread.Sleep(Timeout.Infinite);
            }
            else if (args[0] == "client")
            {
                var client = ClientFactory.Default.New<IPingService>("localhost");
                var sw = Stopwatch.StartNew();
                var result = client.Ping(new byte[10000]);
                Console.WriteLine("Received " + result.Length + " " + sw.Elapsed);
            }
        }
    }
}
