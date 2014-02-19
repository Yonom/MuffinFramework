using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;

namespace MuffinFramework
{
    public class LayerLoader<TLayer, TArgs> : ILayerLoader<TArgs> where TLayer : class, ILayerBase<TArgs>
    {
        public event EventHandler LoadingComplete;

        private void OnLoadingComplete()
        {
            EventHandler handler = LoadingComplete;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        [ImportMany] 
        private TLayer[] _importedLayers = null;

        private readonly List<TLayer> _layers = new List<TLayer>();

        public ReadOnlyCollection<TLayer> Layers
        {
            get { return _layers.AsReadOnly(); }
        }

        ReadOnlyCollection<ILayerBase<TArgs>> ILayerLoader<TArgs>.Layers
        {
            get { return _layers.Cast<ILayerBase<TArgs>>().ToList().AsReadOnly(); }
        }

        public LayerLoader(TArgs args)
        {
            var container = new CompositionContainer(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
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
    }
}