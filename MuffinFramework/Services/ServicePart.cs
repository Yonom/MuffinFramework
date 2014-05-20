using MuffinFramework.Platforms;

namespace MuffinFramework.Services
{
    public abstract class ServicePart<TProtocol> : LayerPart<TProtocol, ServiceArgs>
    {
        protected PlatformLoader PlatformLoader;
        protected ServiceLoader ServiceLoader;

        public override sealed void Enable(ServiceArgs args)
        {
            this.PlatformLoader = args.PlatformLoader;
            this.ServiceLoader = args.ServiceLoader;

            base.Enable(args);
        }
    }
}