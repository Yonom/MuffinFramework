using System.ComponentModel.Composition.Primitives;

namespace MuffinFramework.Platform
{
    public class PlatformLoader : LayerLoader<PlatformBase, PlatformArgs>
    {
        public PlatformLoader(ComposablePartCatalog catalog)
            : base(catalog, new PlatformArgs())
        {
        }
    }
}