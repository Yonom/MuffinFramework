using MuffinFramework.Platform;
using MuffinFramework.Service;

namespace MuffinFramework.Muffin
{
    public class MuffinArgs
    {
        public PlatformLoader PlatformLoader { get; private set; }
        public ServiceLoader ServiceLoader { get; private set; }

        public MuffinArgs(PlatformLoader platformLoader, ServiceLoader serviceLoader)
        {
            PlatformLoader = platformLoader;
            ServiceLoader = serviceLoader;
        }
    }
}