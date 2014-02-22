using System;
using MuffinFramework.Service;

namespace SampleApplication1.Services
{
    public class Service1 : Service
    {
        protected override void Enable()
        {
            Console.WriteLine("Hello world from Service1!");
        }
    }
}
