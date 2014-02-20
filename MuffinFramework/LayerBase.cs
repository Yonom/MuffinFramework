using System;

namespace MuffinFramework
{
    public abstract class LayerBase<TArgs> : ILayerBase<TArgs>
    {
        private readonly object _lockObj = new object();

        public bool IsEnabled { get; private set; }

        public virtual void Enable(TArgs args)
        {
            lock (_lockObj)
            {
                if (IsEnabled)
                    throw new InvalidOperationException("LayerBase has already been enabled.");
                IsEnabled = true;
            }

            Enable();
        }

        protected abstract void Enable();
    }
}