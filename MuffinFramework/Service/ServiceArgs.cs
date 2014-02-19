using MuffinFramework.Platform;

namespace MuffinFramework.Service
{
    public class ServiceArgs
    {
        public PlatformLoader PlatformLoader { get; private set; }

        public ServiceArgs(PlatformLoader platformLoader)
        {
            PlatformLoader = platformLoader;
        }
    }
}