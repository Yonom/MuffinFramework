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
        [ImportMany] private TLayer[] _importedLayers = null;

        private readonly List<TLayer> _layers = new List<TLayer>();

        public ReadOnlyCollection<TLayer> Layers
        {
            get { return _layers.ToList().AsReadOnly(); }
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
        }

        public TType Get<TType>() where TType : class, ILayerBase<TArgs>
        {
            foreach (var l in _layers)
            {
                var res = l as TType;
            }
            return null;
        }
    }
}