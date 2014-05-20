using System;
using MuffinFramework.Platforms;

namespace SampleApplication2.Platforms
{
    public class ConsolePlatform : Platform
    {
        public delegate void OutputEventHandler(object sender, string output);

        protected override void Enable()
        {
            // Nothing to do here...
        }

        public event OutputEventHandler OutputRecieved;

        public void WriteLine(string text)
        {
            // We call the OutputRecieved event here, this will be used by LogMuffin
            // to get informed of new console outputs.
            OutputEventHandler handler = this.OutputRecieved;
            if (handler != null)
                handler(this, text);


            // Write the recieved text to the console.
            Console.WriteLine(text);
        }
    }
}