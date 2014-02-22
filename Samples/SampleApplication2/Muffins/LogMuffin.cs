using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MuffinFramework.Muffin;
using SampleApplication2.Platforms;

namespace SampleApplication2.Muffins
{
    public class LogMuffin : Muffin
    {
        private ConsolePlatform _console;
        protected override void Enable()
        {
            _console = PlatformLoader.Get<ConsolePlatform>();
            _console.OutputRecieved += _console_OutputRecieved;
        }

        void _console_OutputRecieved(object sender, string e)
        {
            // Here, you can log the recieved string
        }

        public override void Dispose()
        {
            base.Dispose();

            // When you bind to an event of another class, this class will keep a 
            // refrence to your class to be able to call the function. This prevents
            // your instance to be garbage colllected, should the other class live
            // longer than yours.
            // It is best to always unbind every event you subscribed to in your Dispose() 
            // function, unless you have control over the object (you created it).
            _console.OutputRecieved -= _console_OutputRecieved;
        }
    }
}
