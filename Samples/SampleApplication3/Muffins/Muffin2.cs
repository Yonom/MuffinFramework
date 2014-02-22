using System;
using System.Threading;
using MuffinFramework.Muffin;

namespace SampleApplication3.Muffins
{
    class Muffin2 : Muffin
    {
        private Thread _writeThread;

        public string Text { get; set; }

        protected override void Enable()
        {
            // This is the default text Muffin2 will be writing.
            this.Text = "Hello world";

            // Start a new thread so we are not blocking Muffin1 from changing the text.
            this._writeThread = new Thread(this.RunThread);
            this._writeThread.Start();
        }

        private void RunThread()
        {
            while (true)
            {
                Console.WriteLine(this.Text);
                Thread.Sleep(500);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            // Close the thread.
            this._writeThread.Abort();
        }
    }
}
