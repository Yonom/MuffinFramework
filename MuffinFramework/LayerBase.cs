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
            lock (_lockObj)
            {
                if (IsEnabled)
                    throw new InvalidOperationException("LayerBase has already been enabled.");
                IsEnabled = true;
            }

            _args = args;

            Enable();
        }

        protected abstract void Enable();

        protected TPart EnablePart<TPart, TProtocol>(TProtocol host) where TPart : class, ILayerPart<TProtocol, TArgs>, new()
        {
            var part = new TPart();
            part.Enable(host, _args);
            _parts.Add(part);
            return part;
        }

        protected TPart EnablePart<TPart, TProtocol>() where TPart : class, ILayerPart<TProtocol, TArgs>, new()
        {
            var host = (TProtocol) (object) this;
            return EnablePart<TPart, TProtocol>(host);
        }

        public virtual void Dispose()
        {
            foreach (var part in _parts)
            {
                part.Dispose();
            }
        }
    }
}