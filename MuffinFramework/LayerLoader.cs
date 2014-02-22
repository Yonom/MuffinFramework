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
    public class LayerLoader<TLayer, TArgs> : ILayerLoader<TArgs> where TLayer : class, ILayerBase<TArgs>
    {
        private readonly object _lockObj = new object();
        [ImportMany]
        private TLayer[] _importedLayers = null;
        private CompositionContainer _container;

        public bool IsEnabled { get; private set; }

        public event EventHandler EnableComplete;
        private void OnEnableComplete()
        {
            EventHandler handler = this.EnableComplete;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private readonly List<TLayer> _layers = new List<TLayer>();
        public ReadOnlyCollection<TLayer> Layers
        {
            get { return new ReadOnlyCollection<TLayer>(this._layers); }
        }

        public void Enable(ComposablePartCatalog catalog, TArgs args)
        {
            lock (this._lockObj)
            {
                if (this.IsEnabled)
                    throw new InvalidOperationException("LayerLoader has already been enabled.");
                this.IsEnabled = true;
            }

            this._container = new CompositionContainer(catalog);
            this._container.ComposeParts(this);

            foreach (var l in this._importedLayers)
            {
                l.Enable(args);
                this._layers.Add(l);
            }

            this.OnEnableComplete();
        }

        public TType Get<TType>() where TType : class, ILayerBase<TArgs>
        {
            try
            {
                return this._layers.OfType<TType>().First();
            }
            catch (InvalidOperationException ex)
            {
                throw new KeyNotFoundException(string.Format("Requested Type was not found: {0}", typeof(TType)), ex);
            }
        }

        public IEnumerator<ILayerBase<TArgs>> GetEnumerator()
        {
            return this._layers.Cast<ILayerBase<TArgs>>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public virtual void Dispose()
        {
            if (this._container != null)
                this._container.Dispose();
        }
    }
}