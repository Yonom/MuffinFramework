using MuffinFramework.Platform;
using MuffinFramework.Service;

namespace MuffinFramework.Muffin
{
    public abstract class MuffinPart<TProtocol> : LayerPart<TProtocol, MuffinArgs>
    {
        protected PlatformLoader PlatformLoader;
        protected ServiceLoader ServiceLoader;
        protected MuffinLoader MuffinLoader;

        public override sealed void Enable(MuffinArgs args)
        {
            PlatformLoader = args.PlatformLoader;
            ServiceLoader = args.ServiceLoader;
            MuffinLoader = args.MuffinLoader;

            base.Enable(args);
        }
    }
}