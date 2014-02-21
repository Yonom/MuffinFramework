using MuffinFramework.Platform;

namespace MuffinFramework.Service
{
    public abstract class ServicePart<TProtocol> : LayerPart<TProtocol, ServiceArgs>
    {
        protected PlatformLoader PlatformLoader;
        protected ServiceLoader ServiceLoader;

        public override sealed void Enable(ServiceArgs args)
        {
            PlatformLoader = args.PlatformLoader;
            ServiceLoader = args.ServiceLoader;

            base.Enable(args);
        }
    }
}