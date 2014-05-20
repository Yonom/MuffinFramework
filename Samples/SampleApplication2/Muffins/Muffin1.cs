using System.Threading;
using MuffinFramework.Muffins;
using SampleApplication2.Services;

namespace SampleApplication2.Muffins
{
    public class Muffin1 : Muffin
    {
        private ConsoleOutputService _output;

        protected override void Enable()
        {
            // ServiceLoader contains all services currently loaded.
            // There are also PlatformLoader and MuffinLoader.

            this._output = this.ServiceLoader.Get<ConsoleOutputService>();

            this._output.WriteLine("Started working");

            Thread.Sleep(2000);
            this._output.WriteLine("Task 1 complete.");

            Thread.Sleep(5000);
            this._output.WriteLine("Task 2 complete.");
        }
    }
}