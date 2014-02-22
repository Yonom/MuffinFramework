using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Text = "Hello world";

            // Start a new thread so we are not blocking Muffin1 from changing the text.
            _writeThread = new Thread(RunThread);
            _writeThread.Start();
        }

        private void RunThread()
        {
            while (true)
            {
                Console.WriteLine(Text);
                Thread.Sleep(500);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            // Close the thread.
            _writeThread.Abort();
        }
    }
}
