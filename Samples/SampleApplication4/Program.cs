using System;
using MuffinFramework;

namespace SampleApplication4
{
    internal class Program
    {
        // Not every Muffin/Service/Protocol has basic tasks to do, some of them might
        // need to be split in smaller separate parts that work together. 
        // This sample contains three examples for how to use Parts to have multiple 
        // classes work together.
        private static void Main()
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