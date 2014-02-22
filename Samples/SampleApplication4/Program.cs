using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuffinFramework;

namespace SampleApplication4
{
    class Program
    {
        // Not every Muffin/Service/Protocol has basic tasks to do, some of them might
        // need to be split in smaller separate parts that work together. 
        // This sample contains three examples for how to use Parts to have multiple 
        // classes work together.
        static void Main()
        {
            var client = new MuffinClient();
            client.Start();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

            // Calling Dispose here will also dispose all loaded MuffinParts 
            // automatically. There is no need to dispose them manually.
            client.Dispose();
        }
    }
}
