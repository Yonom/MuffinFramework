using System;
using MuffinFramework.Muffin;

namespace SampleApplication4.Muffins
{
    public class Muffin3 : Muffin<Muffin3.Protocol>
    {
        public Muffin3Part1 Part1 { get; private set; }

        protected override void Enable()
        {
            // In this example, we have a MuffinPart which wants to call the HelloWorld()
            // function in the main Muffin class, but we want to avoid passing the main
            // class down to the Parts. Instead we use a Protocol object which handles
            // the communication between parts and the main class.

            var protocol = new Protocol(this);

            this.Part1 = this.EnablePart<Muffin3Part1>(protocol);
        }
        public void HelloWorld()
        {
            Console.WriteLine("Hello world from Muffin3!");
        }

        public class Protocol
        {
            private readonly Muffin3 _parent;

            public Protocol(Muffin3 parent)
            {
                this._parent = parent;
            }

            public void HelloWorld()
            {
                this._parent.HelloWorld();
            }
        }
    }
}
