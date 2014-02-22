using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuffinFramework;

namespace SampleApplication2
{
    class Program
    {
        // This sample shows how a Muffin can consume a Platform / Service
        //
        // ConsolePlatform is used to write to the console and Muffins should use it  
        // instead of directly calling the console class. Now if we want to log all 
        // console output, it can be done very easily.
        //
        // ConsoleOutputService adds a Timestamp to each message to make the console 
        // output easier to read.
        // 
        // Muffin1 does some tasks and reports its state to the console.
        // LogMuffin has the responsbility to log all the console output.
        static void Main()
        {
            var client = new MuffinClient();
            client.Start();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
