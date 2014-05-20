using System;
using MuffinFramework.Muffins;

namespace SampleApplication4.Muffins
{
    // The type parameter TProtocol here defines the type of MuffinPart.Host that will
    // be available to this part so it can communicate with its parent.
    public class Muffin2Part1 : MuffinPart<Muffin2>
    {
        protected override void Enable()
        {
        }

        public void HelloWorld()
        {
            Console.WriteLine("Hello world from Muffin2Part1!");
        }
    }
}
