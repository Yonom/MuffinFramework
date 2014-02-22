using System;
using MuffinFramework.Service;
using SampleApplication2.Platforms;

namespace SampleApplication2.Services
{
    public class ConsoleOutputService : Service
    {
        private ConsolePlatform _console;
        protected override void Enable()
        {
            // This gets the ConsolePlatform instance created by MuffinFramework.
            // It can throw an exception if the class is not loaded, but we are not
            // concerned here, as all Platforms are loaded first before a service is.

            this._console = this.PlatformLoader.Get<ConsolePlatform>();
        }

        public void WriteLine(string text)
        {
            string time = DateTime.Now.ToLongTimeString();

            this._console.WriteLine(string.Format("[{0}] {1}", time, text));
        }
    }
}
