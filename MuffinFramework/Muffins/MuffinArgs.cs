using MuffinFramework.Platforms;
using MuffinFramework.Services;

namespace MuffinFramework.Muffins
{
    public class MuffinArgs
    {
        public PlatformLoader PlatformLoader { get; private set; }
        public ServiceLoader ServiceLoader { get; private set; }
        public MuffinLoader MuffinLoader { get; private set; }

        public MuffinArgs(PlatformLoader platformLoader, ServiceLoader serviceLoader, MuffinLoader muffinLoader)
        {
            this.PlatformLoader = platformLoader;
            this.ServiceLoader = serviceLoader;
            this.MuffinLoader = muffinLoader;
        }
    }
}
