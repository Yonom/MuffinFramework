using System;
using MuffinFramework;

namespace SampleApplication2
{
    internal class Program
    {
        // This sample shows how a Muffin can consume a Platform / Service
        //
        // ConsolePlatform is used to write to the console and Muffins should use it  
        // instead of directly calling the Console class. Now if we want to log all 
        // console output, it can be accomplished very easily.
        //
        // ConsoleOutputService adds a Timestamp to each message to make the console 
        // output easier to read.
        // 
        // Muffin1 does some tasks and reports its state to the console.
        // LogMuffin has the responsbility to log all the console output.
        private static void Main()
        {
            var client = new MuffinClient();
            client.Start();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

            // Disposing the client also calls Dispose() in every loaded Muffin, Service
            // and Platform so they can clean up their resources. To avoid memory leaks, 
            // always call MuffinClient.Dispose to make sure all resources are cleaned up.
            client.Dispose();
        }
    }
}