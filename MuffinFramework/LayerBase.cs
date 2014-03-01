using System;
using System.Collections.Generic;

namespace MuffinFramework
{
    public abstract class LayerBase<TArgs> : ILayerBase<TArgs>
    {
        private readonly object _lockObj = new object();

        private readonly List<ILayerBase<TArgs>> _parts = new List<ILayerBase<TArgs>>();
        private TArgs _args;

        public bool IsEnabled { get; private set; }

        public virtual void Enable(TArgs args)
        {
            lock (this._lockObj) {
                if (this.IsEnabled)
                    throw new InvalidOperationException("LayerBase has already been enabled.");

                this.IsEnabled = true;
            }

            this._args = args;
            this.Enable();
        }

        protected abstract void Enable();

        protected TPart EnablePart<TPart, TProtocol>(TProtocol host) where TPart : class, ILayerPart<TProtocol, TArgs>, new()
        {
            var part = new TPart();
            part.Enable(host, this._args);
            this._parts.Add(part);
            return part;
        }

        protected TPart EnablePart<TPart, TProtocol>() where TPart : class, ILayerPart<TProtocol, TArgs>, new()
        {
            var host = (TProtocol) (this as object);
            return this.EnablePart<TPart, TProtocol>(host);
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            foreach (var part in this._parts) {
                part.Dispose();
            }
        }
    }
}
