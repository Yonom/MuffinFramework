namespace MuffinFramework.Muffin
{
    public abstract class MuffinPart<TProtocol> : MuffinBase, ILayerPart<TProtocol, MuffinArgs>
    {
        public TProtocol Host { get; private set; }
        public void Enable(TProtocol host, MuffinArgs args)
        {
            Host = host;

            Enable(args);
        }
    }
}
