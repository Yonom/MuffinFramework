namespace MuffinFramework
{
    public interface ILayerBase<in TArgs>
    {
        bool IsEnabled { get; }
        void Enable(TArgs args);
    }
}