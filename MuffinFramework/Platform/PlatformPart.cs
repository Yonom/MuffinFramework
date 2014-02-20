namespace MuffinFramework.Platform
{
    public abstract class PlatformPart<TProtocol> : PlatformBase, ILayerPart<TProtocol, PlatformArgs>
    {
        public TProtocol Host { get; private set; }
        public void Enable(TProtocol host, PlatformArgs args)
        {
            Host = host;

            Enable(args);
        }
    }
}
