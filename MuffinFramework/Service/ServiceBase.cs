using MuffinFramework.Platform;

namespace MuffinFramework.Service
{
    public abstract class ServiceBase : LayerBase<ServiceArgs>
    {
        protected PlatformLoader PlatformLoader;
        protected ServiceLoader ServiceLoader;

        public override void Enable(ServiceArgs args)
        {
            PlatformLoader = args.PlatformLoader;
            ServiceLoader = args.ServiceLoader;

            base.Enable(args);
        }
    }
}