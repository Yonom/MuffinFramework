namespace MuffinFramework
{
    public interface ILayerBase<TArgs>
    {
        void Enable(ILayerLoader<TArgs> loader, TArgs args);
    }
}