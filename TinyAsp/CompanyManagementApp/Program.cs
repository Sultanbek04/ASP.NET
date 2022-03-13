using System;
using TinyAsp.App.Core;

namespace CompanyManagementApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var listeningPort = 15100;

            var tinyAspInstance = new TinyAspApp(listeningPort);
            tinyAspInstance.Run();

            Console.ReadLine();
        }
    }
}
