using MuffinFramework.Muffins;
using MuffinFramework.Platforms;
using MuffinFramework.Services;

namespace MuffinFramework.Tests.Muffins
{
    class MuffinTester : Muffin
    {
        public MuffinLoader TestMuffinLoader
        {
            get { return this.MuffinLoader; }
        }

        public ServiceLoader TestServiceLoader
        {
            get { return this.ServiceLoader; }
        }

        public PlatformLoader TestPlatformLoader
        {
            get { return this.PlatformLoader; }
        }

        protected override void Enable()
        {
        }
    }
}
