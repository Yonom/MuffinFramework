using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using MuffinFramework.Muffin;
using MuffinFramework.Platform;
using MuffinFramework.Service;

namespace MuffinFramework
{
    public class MuffinClient : IDisposable
    {
        private readonly object _lockObj = new object();

        public bool IsStarted { get; private set; }
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
            lock (_lockObj)
            {
                if (IsStarted)
                    throw new InvalidOperationException("MuffinClient has already been started.");
                IsStarted = true;
            }

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