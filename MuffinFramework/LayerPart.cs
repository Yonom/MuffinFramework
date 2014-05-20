using System;

namespace MuffinFramework
{
    public abstract class LayerPart<TProtocol, TArgs> : LayerBase<TArgs>, ILayerPart<TProtocol, TArgs>
    {
        private readonly object _lockObj = new object();

        public TProtocol Host { get; private set; }

        public void Enable(TProtocol host, TArgs args)
        {
            lock (this._lockObj) {
                if (this.IsEnabled)
                    throw new InvalidOperationException("LayerPart has already been enabled.");

                this.Host = host;
                this.Enable(args);
            }
        }

        protected TPart EnablePart<TPart>(TProtocol host) where TPart : class, ILayerPart<TProtocol, TArgs>, new()
        {
            return this.EnablePart<TPart, TProtocol>(host);
        }

        protected TPart EnablePart<TPart>() where TPart : class, ILayerPart<TProtocol, TArgs>, new()
        {
            return this.EnablePart<TPart, TProtocol>();
        }
    }
}
