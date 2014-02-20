using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace MuffinFramework
{
    public interface ILayerLoader<TArgs> : IEnumerable<ILayerBase<TArgs>>
    {
        bool Enabled { get; }
        event EventHandler EnableComplete;
        TType Get<TType>() where TType : class, ILayerBase<TArgs>;
    }
}