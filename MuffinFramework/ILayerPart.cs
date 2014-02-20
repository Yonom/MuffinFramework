using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuffinFramework
{
    public interface ILayerPart<TProtocol, in TArgs> : ILayerBase<TArgs>
    {
        TProtocol Host { get; }
        void Enable(TProtocol host, TArgs args);
    }
}
