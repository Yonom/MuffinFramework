using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuffinFramework.Platform;

namespace SampleApplication1.Platforms
{
    public class HostPlatform : Platform
    {
        // This will be set by Program.cs and called by Muffin1
        public Func<string[]> GetArgsCallback { get; set; }

        protected override void Enable()
        {
        }
    }
}
