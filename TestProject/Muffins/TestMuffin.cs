using System;
using MuffinFramework.Muffin;

namespace TestProject.Muffins
{
    public class TestMuffin : Muffin<TMuffin>
    {
        protected override void Enable()
        {
            Console.WriteLine("Hello World from TestMuffin!");
            EnablePart<TestMuffinPart>();
        }

        public void RunMe()
        {

        }

        public override void Dispose()
        {
            Console.WriteLine("Disposed");
            base.Dispose();
        }
    }

    public class TMuffin : TestMuffin
    {
        protected override void Enable()
        {

            Console.WriteLine("Hello World from TMuffin!");
        }
    }
}
