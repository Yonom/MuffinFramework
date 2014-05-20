using MuffinFramework.Platforms;

namespace MuffinFramework.Tests.Platforms
{
    internal class PlatformTester : Platform
    {
        public PlatformLoader TestPlatformLoader
        {
            get { return this.PlatformLoader; }
        }

        protected override void Enable()
        {
        }
    }
}