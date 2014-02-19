namespace MuffinFramework
{
    public interface ILayerLoader<TArgs>
    {
        TType Get<TType>() where TType : class, ILayerBase<TArgs>;
    }
}