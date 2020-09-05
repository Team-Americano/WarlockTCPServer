using System;
using WarlockTCPServer.Managers;

namespace WarlockTCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            NetworkManager.Start();            
        }
    }
}
