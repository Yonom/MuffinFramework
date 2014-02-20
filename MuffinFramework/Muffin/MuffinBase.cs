using System.ComponentModel.Composition;
using MuffinFramework.Platform;
using MuffinFramework.Service;

namespace MuffinFramework.Muffin
{
    [InheritedExport(typeof(MuffinBase))]
    public abstract class MuffinBase : LayerBase<MuffinArgs>
    {
        protected PlatformLoader PlatformLoader;
        protected ServiceLoader ServiceLoader;
        protected MuffinLoader MuffinLoader;

        public override void Enable(MuffinArgs args)
        {
            PlatformLoader = args.PlatformLoader;
            ServiceLoader = args.ServiceLoader;
            MuffinLoader = args.MuffinLoader;

            base.Enable(args);
        }
    }
}