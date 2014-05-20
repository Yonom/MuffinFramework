using System;
using MuffinFramework.Platforms;

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
