using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;

namespace MuffinFramework
{
    public class LayerLoader<TLayer, TArgs> : ILayerLoader<TArgs>, IDisposable where TLayer : class, ILayerBase<TArgs>
    {
        [ImportMany]
        private TLayer[] _importedLayers = null;

        private CompositionContainer _container;


        public event EventHandler LoadingComplete;

        private void OnLoadingComplete()
        {
            EventHandler handler = LoadingComplete;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private readonly List<TLayer> _layers = new List<TLayer>();

        public ReadOnlyCollection<TLayer> Layers
        {
            get { return _layers.AsReadOnly(); }
        }

        ReadOnlyCollection<ILayerBase<TArgs>> ILayerLoader<TArgs>.Layers
        {
            get { return _layers.Cast<ILayerBase<TArgs>>().ToList().AsReadOnly(); }
        }

        public LayerLoader(ComposablePartCatalog catalog, TArgs args)
        {
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            foreach (var l in _importedLayers)
            {
                l.Enable(this, args);
                _layers.Add(l);
            }

            OnLoadingComplete();
        }

        public TType Get<TType>() where TType : class, ILayerBase<TArgs>
        {
            return _layers.OfType<TType>().FirstOrDefault();
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}