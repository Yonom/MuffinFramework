namespace MuffinFramework
{
    public interface ILayerPart<TProtocol, in TArgs> : ILayerBase<TArgs>
    {
        TProtocol Host { get; }
        void Enable(TProtocol host, TArgs args);
    }
}