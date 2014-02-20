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
            EventHandler handler = EnableComplete;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private readonly List<TLayer> _layers = new List<TLayer>();
        public ReadOnlyCollection<TLayer> Layers
        {
            get { return _layers.AsReadOnly(); }
        }

        public void Enable(ComposablePartCatalog catalog, TArgs args)
        {
            lock (_lockObj)
            {
                if (IsEnabled)
                    throw new InvalidOperationException("LayerLoader has already been enabled.");
                IsEnabled = true;
            }

            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);

            foreach (var l in _importedLayers)
            {
                l.Enable(args);
                _layers.Add(l);
            }

            OnEnableComplete();
        }

        public TType Get<TType>() where TType : class, ILayerBase<TArgs>
        {
            try
            {
                return _layers.OfType<TType>().First();
            }
            catch (InvalidOperationException ex)
            {
                throw new UnknownLayerException(string.Format("Requested Type was not found: {0}", typeof(TType)), ex);
            }
        }

        public IEnumerator<ILayerBase<TArgs>> GetEnumerator()
        {
            return _layers.Cast<ILayerBase<TArgs>>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Dispose()
        {
            if (_container != null)
                _container.Dispose();
        }
    }
}