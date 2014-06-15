using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace MuffinFramework
{
    public class LayerLoader<TLayer, TArgs> : ILayerLoader<TArgs> where TLayer : ILayerBase<TArgs>
    {
        private readonly object _lockObj = new object();

        [ImportMany]
        private TLayer[] _importedLayers = null;
        private CompositionContainer _container;

        public bool IsEnabled { get; private set; }

        public event EventHandler EnableComplete;
        private void OnEnableComplete()
        {
            var handler = this.EnableComplete;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private TArgs _args;
        private readonly Dictionary<Type, TLayer> _layers = new Dictionary<Type, TLayer>();

        public ReadOnlyCollection<TLayer> Layers
        {
            get { return new ReadOnlyCollection<TLayer>(this._layers.Values.ToList()); }
        }

        public void Enable(ComposablePartCatalog catalog, TArgs args)
        {
            this._args = args;

            lock (this._lockObj) {
                if (this.IsEnabled)
                    throw new InvalidOperationException("LayerLoader has already been enabled.");

                this.IsEnabled = true;
            }

            this._container = new CompositionContainer(catalog);
            this._container.ComposeParts(this);

            foreach (var l in this._importedLayers) {
                l.Enable(args);
                this._layers.Add(l.GetType(), l);
            }

            this.OnEnableComplete();
        }

        public TType Load<TType>() where TType : TLayer, new()
        {
            var t = typeof(TType);
            if (this._layers.ContainsKey(t))
                throw new InvalidOperationException("The given type is already loaded.");

            var l = new TType();
            l.Enable(this._args);
            this._layers.Add(t, l);
            return l;
        }

        public TType Get<TType>() where TType : ILayerBase<TArgs>
        {
            Type t = typeof(TType);

            try
            {
                if (this._layers.ContainsKey(t))
                    return (TType)(object)this._layers[t];

                // If no type defined explictly as the defined type was found, try casting one
                var foundTypes = this._layers.Values.OfType<TType>().ToList();
                if (foundTypes.Count() > 1)
                    throw new InvalidOperationException("Multiple matching types were found.");
                return foundTypes.First();

            } catch (InvalidOperationException ex) {
                throw new KeyNotFoundException(string.Format("Requested Type was not found: {0}", t), ex);
            }
        }

        public IEnumerator<ILayerBase<TArgs>> GetEnumerator()
        {
            return this._layers.Values.Cast<ILayerBase<TArgs>>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (this._container != null)
                this._container.Dispose();
        }
    }
}
