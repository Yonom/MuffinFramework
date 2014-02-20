using System;
using System.Collections.Generic;

namespace MuffinFramework
{
    public interface ILayerLoader<TArgs> : IEnumerable<ILayerBase<TArgs>>
    {
        bool Enabled { get; }
        event EventHandler EnableComplete;
        TType Get<TType>() where TType : class, ILayerBase<TArgs>;
    }
}