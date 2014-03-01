using System;

namespace MuffinFramework
{
    public interface ILayerBase<in TArgs> : IDisposable
    {
        bool IsEnabled { get; }
        void Enable(TArgs args);
    }
}
