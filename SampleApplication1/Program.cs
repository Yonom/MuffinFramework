using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuffinFramework;

namespace SampleApplication1
{
    class Program
    {
        // This sample demonstrates how easy it is to get started with MuffinFramework.
        // Each layer contains a simple hello world class. Note that these classes are 
        // not refrenced anywhere in this code and will be loaded dynamically.
        //
        // The classes will be loaded in the following order:
        // Platform1 -> Service1 -> Muffin1
        static void Main()
        {
            var client = new MuffinClient();
            client.Start();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
