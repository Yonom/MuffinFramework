using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuffinFramework.Platform;

namespace SampleApplication1.Platforms
{
    public class Platform1 : Platform
    {
        protected override void Enable()
        {
            Console.WriteLine("Hello world from Platform1!");
        }
    }
}
