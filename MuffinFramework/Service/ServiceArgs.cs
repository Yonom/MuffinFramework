using MuffinFramework.Platform;

namespace MuffinFramework.Service
{
    public class ServiceArgs
    {
        public PlatformLoader PlatformLoader { get; private set; }
        public ServiceLoader ServiceLoader { get; private set; }

        public ServiceArgs(PlatformLoader platformLoader, ServiceLoader serviceLoader)
        {
            this.PlatformLoader = platformLoader;
            this.ServiceLoader = serviceLoader;
        }
    }
}