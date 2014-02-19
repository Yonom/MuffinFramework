using System;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using MuffinFramework.Muffin;
using MuffinFramework.Platform;
using MuffinFramework.Service;

namespace MuffinFramework
{
    public class MuffinClient : IDisposable
    {
        public AggregateCatalog Catalog { get; private set; }
        public PlatformLoader PlatformLoader { get; private set; }
        public ServiceLoader ServiceLoader { get; private set; }
        public MuffinLoader MuffinLoader { get; private set; }

        public MuffinClient()
        {
            Catalog = new AggregateCatalog();
            Catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetCallingAssembly()));
        }

        public void Start()
        {
            PlatformLoader = new PlatformLoader(Catalog);
            ServiceLoader = new ServiceLoader(Catalog, PlatformLoader);
            MuffinLoader = new MuffinLoader(Catalog, PlatformLoader, ServiceLoader);
        }

        public void Dispose()
        {
            Catalog.Dispose();
            PlatformLoader.Dispose();
            ServiceLoader.Dispose();
            MuffinLoader.Dispose();
        }
    }
}