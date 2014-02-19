namespace MuffinFramework
{
    public abstract class LayerBase<TLoader, TArgs> : ILayerBase<TArgs> where TLoader : ILayerLoader<TArgs>
    {
        protected TArgs Args;
        protected TLoader Loader;

        public void Enable(ILayerLoader<TArgs> loader, TArgs args)
        {
            Loader = (TLoader) loader;
            Args = args;

            Enable();
        }

        protected abstract void Enable();
    }
}