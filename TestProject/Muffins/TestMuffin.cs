using System;
using MuffinFramework.Muffin;

namespace TestProject.Muffins
{
    public class TestMuffin : MuffinBase
    {
        protected override void Enable()
        {
            Console.WriteLine("Hello World from TestMuffin!");
        }
    }
}
