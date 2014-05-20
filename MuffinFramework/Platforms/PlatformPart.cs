namespace MuffinFramework.Platforms
{
    public abstract class PlatformPart<TProtocol> : LayerPart<TProtocol, PlatformArgs>
    {
        protected PlatformLoader PlatformLoader;

        public override sealed void Enable(PlatformArgs args)
        {
            this.PlatformLoader = args.PlatformLoader;

            base.Enable(args);
        }
    }
}