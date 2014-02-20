using System.ComponentModel.Composition;

namespace MuffinFramework.Platform
{
    [InheritedExport(typeof(PlatformBase))]
    public abstract class PlatformBase : LayerBase<PlatformArgs>
    {
        protected PlatformLoader PlatformLoader;

        public override sealed void Enable(PlatformArgs args)
        {
            PlatformLoader = args.PlatformLoader;

            base.Enable(args);
        }
    }
}