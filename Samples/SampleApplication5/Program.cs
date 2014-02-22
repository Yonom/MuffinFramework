using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuffinFramework;
using SampleApplication1.Platforms;

namespace SampleApplication5
{
    class Program
    {
        // In bigger applications, there might be the need to pass data to a Muffin.
        // In this sample, the command line arguments are passed to Muffin1 using
        // HostPlatform as a way of communication.
        //
        // The executable will be executed with the following commandline arguments:
        // "SOME USELESS COMMANDLINE ARGUMENTS"
        static void Main(string[] args)
        {
            _args = args;

            _client = new MuffinClient();
            _client.PlatformLoader.EnableComplete += PlatformLoader_EnableComplete;
            _client.Start();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

            _client.Dispose();
        }

        private static MuffinClient _client;
        private static string[] _args;

        private static string[] GetArgs()
        {
            return _args;
        }

        static void PlatformLoader_EnableComplete(object sender, EventArgs e)
        {
            var hostPlatform = _client.PlatformLoader.Get<HostPlatform>();
            hostPlatform.GetArgsCallback = GetArgs;
        }
    }
}
