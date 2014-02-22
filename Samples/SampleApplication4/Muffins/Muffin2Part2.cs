using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MuffinFramework.Muffin;

namespace SampleApplication4.Muffins
{
    public class Muffin2Part2 : MuffinPart<Muffin2>
    {
        protected override void Enable()
        {
            // Part1 is accessed through Muffin1 here
            Host.Part1.HelloWorld();
        }
    }
}
