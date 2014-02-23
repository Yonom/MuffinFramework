using MuffinFramework.Platforms;
using MuffinFramework.Services;

namespace MuffinFramework.Tests.Services
{
    class ServiceTester : Service
    {
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
