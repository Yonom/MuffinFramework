using System.ComponentModel.Composition;

namespace MuffinFramework.Platform
{
    [InheritedExport(typeof(PlatformBase))]
    public abstract class PlatformBase : LayerBase<PlatformArgs>
    {
    }
}