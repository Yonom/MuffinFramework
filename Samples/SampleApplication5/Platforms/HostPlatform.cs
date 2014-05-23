using System;
using MuffinFramework.Platforms;

namespace SampleApplication5.Platforms
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
