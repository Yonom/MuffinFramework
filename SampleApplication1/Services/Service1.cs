using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
