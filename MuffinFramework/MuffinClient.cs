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

            PlatformLoader = new PlatformLoader();
            ServiceLoader = new ServiceLoader();
            MuffinLoader = new MuffinLoader();
        }

        public void Start()
        {
            PlatformLoader.Enable(Catalog, new PlatformArgs(PlatformLoader));
            ServiceLoader.Enable(Catalog, new ServiceArgs(PlatformLoader, ServiceLoader));
            MuffinLoader.Enable(Catalog, new MuffinArgs(PlatformLoader, ServiceLoader, MuffinLoader));
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