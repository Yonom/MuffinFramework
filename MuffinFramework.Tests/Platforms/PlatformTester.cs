using MuffinFramework.Platforms;

namespace MuffinFramework.Tests.Platforms
{
    class PlatformTester : Platform
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
