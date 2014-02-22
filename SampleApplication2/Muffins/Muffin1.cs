using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MuffinFramework.Muffin;
using SampleApplication2.Services;

namespace SampleApplication2.Muffins
{
    public class Muffin1 : Muffin
    {
        private ConsoleOutputService _output;

        protected override void Enable()
        {
            _output = ServiceLoader.Get<ConsoleOutputService>();

            _output.WriteLine("Started working");

            Thread.Sleep(2000);
            _output.WriteLine("Task 1 complete.");

            Thread.Sleep(5000);
            _output.WriteLine("Task 2 complete.");
        }
    }
}
