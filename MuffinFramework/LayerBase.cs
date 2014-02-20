namespace MuffinFramework
{
    public abstract class LayerBase<TArgs> : ILayerBase<TArgs>
    {
        protected TArgs Args;

        public void Enable(TArgs args)
        {
            Args = args;
            Enable();
        }

        protected abstract void Enable();
    }
}