using System;
using System.Collections.ObjectModel;

namespace MuffinFramework
{
    public interface ILayerLoader<TArgs>
    {
        event EventHandler LoadingComplete;
        ReadOnlyCollection<ILayerBase<TArgs>> Layers { get; }
        TType Get<TType>() where TType : class, ILayerBase<TArgs>;
    }
}