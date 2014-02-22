using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MuffinFramework;

namespace SampleApplication3
{
    class Program
    {
        // Sometimes, it might be necessary for Muffins to communicate with eachother.
        // This sample demonstrates how this can be done.
        //
        // Muffin1 wants to change the text that Muffin2 is writing to the console every
        // 500 miliseconds, but Muffin1 is loaded before Muffin2, so it can't change
        // the Text in its Enable() method.
        static void Main()
        {
            var client = new MuffinClient();
            client.Start();

            Thread.Sleep(4000);

            // Calling Dispose here will abort the separate Thread in Muffin2. By
            // leaving out this line, you can prevent the program from exiting as there
            // is yet another thread running. See how important it is to call Dispose?
            client.Dispose();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
