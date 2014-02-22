using System;
using MuffinFramework.Muffin;

namespace SampleApplication1.Muffins
{
    public class Muffin1 : Muffin
    {
        protected override void Enable()
        {
            Console.WriteLine("Hello world from Muffin1!");
        }
    }
}
