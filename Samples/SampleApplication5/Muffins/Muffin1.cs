using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MuffinFramework.Muffin;
using SampleApplication1.Platforms;

namespace SampleApplication5.Muffins
{
    public class Muffin1 : Muffin
    {
        protected override void Enable()
        {
            var hostPlatform = PlatformLoader.Get<HostPlatform>();
            var args = hostPlatform.GetArgsCallback();

            Console.WriteLine("Commandline arguemnts: " + string.Join(" ", args));
        }
    }
}
