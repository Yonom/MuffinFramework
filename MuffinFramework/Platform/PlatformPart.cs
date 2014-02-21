namespace MuffinFramework.Platform
{
    public abstract class PlatformPart<TProtocol> : LayerPart<TProtocol, PlatformArgs>
    {
        protected PlatformLoader PlatformLoader;

        public override sealed void Enable(PlatformArgs args)
        {
            PlatformLoader = args.PlatformLoader;

            base.Enable(args);
        }
    }
}