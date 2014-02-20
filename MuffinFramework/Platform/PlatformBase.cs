namespace MuffinFramework.Platform
{
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