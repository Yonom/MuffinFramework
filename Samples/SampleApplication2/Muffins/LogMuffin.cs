using System;
using MuffinFramework.Muffins;
using SampleApplication2.Platforms;

namespace SampleApplication2.Muffins
{
    public sealed class LogMuffin : Muffin
    {
        private ConsolePlatform _console;
        protected override void Enable()
        {
            this._console = this.PlatformLoader.Get<ConsolePlatform>();
            this._console.OutputRecieved += this._console_OutputRecieved;
        }

        void _console_OutputRecieved(object sender, string e)
        {
            // Here, you can log the recieved string
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (!disposing) return;

            base.Dispose();

            // When you bind to an event of another class, this class will keep a 
            // refrence to your class to be able to call the function. This prevents 
            // your instance to be garbage colllected, should the other class live 
            // longer than yours.
            // It is best to always unbind every event you subscribed to in your Dispose() 
            // function, unless you have control over the object (you created it).
            this._console.OutputRecieved -= this._console_OutputRecieved;
        }
    }
}
