using System;
using System.Diagnostics;
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
            var watch = new Stopwatch();

            do {
                watch.Restart();
                var client = new MuffinClient();
                client.Start();
                watch.Stop();

                Console.WriteLine(Environment.NewLine +
                                  string.Format("Startup time: {0:#.00}ms", watch.Elapsed.TotalMilliseconds) +
                                  Environment.NewLine +
                                  "Press any key to repeat the test! Press the spacebar to exit!" +
                                  Environment.NewLine +
                                  new string('_', Console.BufferWidth));

                client.Dispose();

            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
    }
}
