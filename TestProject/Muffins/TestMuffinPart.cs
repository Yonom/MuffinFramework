using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuffinFramework.Muffin;

namespace TestProject.Muffins
{
    public class TestMuffinPart : MuffinPart<TestMuffin>
    {
        protected override void Enable()
        {
            Console.WriteLine(Host.ToString());
        }

        public override void Dispose()
        {
            Console.WriteLine("Disposed 2");
            base.Dispose();
        }
    }
}
