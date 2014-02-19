using System.ComponentModel.Composition.Primitives;
using MuffinFramework.Platform;
using MuffinFramework.Service;

namespace MuffinFramework.Muffin
{
    public class MuffinLoader : LayerLoader<MuffinBase, MuffinArgs>
    {
        public MuffinLoader(ComposablePartCatalog catalog, PlatformLoader platformLoader, ServiceLoader serviceLoader)
            : base(catalog, new MuffinArgs(platformLoader, serviceLoader))
        {
        }
    }
}