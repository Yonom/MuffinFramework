namespace MuffinFramework.Service
{
    public abstract class ServicePart<TProtocol> : ServiceBase, ILayerPart<TProtocol, ServiceArgs>
    {
        public TProtocol Host { get; private set; }
        public void Enable(TProtocol host, ServiceArgs args)
        {
            Host = host;

            Enable(args);
        }
    }
}
