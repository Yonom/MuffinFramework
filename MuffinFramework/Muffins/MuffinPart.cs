using MuffinFramework.Platforms;
using MuffinFramework.Services;

namespace MuffinFramework.Muffins
{
    public abstract class MuffinPart<TProtocol> : LayerPart<TProtocol, MuffinArgs>
    {
        protected PlatformLoader PlatformLoader;
        protected ServiceLoader ServiceLoader;
        protected MuffinLoader MuffinLoader;

        public override sealed void Enable(MuffinArgs args)
        {
            this.PlatformLoader = args.PlatformLoader;
            this.ServiceLoader = args.ServiceLoader;
            this.MuffinLoader = args.MuffinLoader;

            base.Enable(args);
        }
    }
}
