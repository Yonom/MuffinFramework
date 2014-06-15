using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;

namespace MuffinFramework
{
    public interface ILayerLoader<TArgs> : IEnumerable<ILayerBase<TArgs>>, IDisposable
    {
        bool IsEnabled { get; }
        event EventHandler EnableComplete;
        void Enable(ComposablePartCatalog catalog, TArgs args);
        TType Get<TType>() where TType : ILayerBase<TArgs>;
    }
}
