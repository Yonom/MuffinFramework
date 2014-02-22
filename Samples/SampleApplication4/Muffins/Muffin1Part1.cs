using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MuffinFramework.Muffin;

namespace SampleApplication4.Muffins
{
    public class Muffin1Part1 : MuffinPart<Muffin1>
    {
        protected override void Enable()
        {
            Console.WriteLine("Hello world from Muffin1Part1!");
        }
    }
}
