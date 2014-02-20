using System;
using MuffinFramework.Muffin;

namespace TestProject.Muffins
{
    public class TestMuffin : Muffin
    {
        protected override void Enable()
        {
            Console.WriteLine("Hello World from TestMuffin!");
        }
    }
}
