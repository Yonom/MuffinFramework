using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MuffinFramework.Muffin;

namespace SampleApplication4.Muffins
{
    public class Muffin2 : Muffin<Muffin2>
    {
        public Muffin2Part1 Part1 { get; private set; }
        public Muffin2Part2 Part2 { get; private set; }

        protected override void Enable()
        {
            // In this example the base class Muffin<TProtocol> is used instead of the
            // non-generic version. Now we can call EnablePart<TPart> instead of having
            // to provide the TProtocol type every time.

            Part1 = EnablePart<Muffin2Part1>();
            Part2 = EnablePart<Muffin2Part2>();
        }
    }
}
