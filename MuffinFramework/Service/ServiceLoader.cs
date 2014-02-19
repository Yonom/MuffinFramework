using System.ComponentModel.Composition.Primitives;
using MuffinFramework.Platform;

namespace MuffinFramework.Service
{
    public class ServiceLoader : LayerLoader<ServiceBase, ServiceArgs>
    {
        public ServiceLoader(ComposablePartCatalog catalog, PlatformLoader platformLoader)
            : base(catalog, new ServiceArgs(platformLoader))
        {
        }
    }
}