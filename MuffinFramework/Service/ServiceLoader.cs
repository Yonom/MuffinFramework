using MuffinFramework.Platform;

namespace MuffinFramework.Service
{
    public class ServiceLoader : LayerLoader<ServiceBase, ServiceArgs>
    {
        public ServiceLoader(PlatformLoader platformLoader)
            : base(new ServiceArgs(platformLoader))
        {
        }
    }
}