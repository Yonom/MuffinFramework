namespace MuffinFramework
{
    public interface ILayerBase<in TArgs>
    {
        void Enable(TArgs args);
    }
}