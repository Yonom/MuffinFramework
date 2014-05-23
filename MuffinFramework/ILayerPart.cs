namespace MuffinFramework
{
    public interface ILayerPart<in TProtocol, in TArgs> : ILayerBase<TArgs>
    {
        void Enable(TProtocol host, TArgs args);
    }
}
