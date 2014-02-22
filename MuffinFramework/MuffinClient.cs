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
            this.Catalog = new AggregateCatalog();
            this.Catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetCallingAssembly()));

            this.PlatformLoader = new PlatformLoader();
            this.ServiceLoader = new ServiceLoader();
            this.MuffinLoader = new MuffinLoader();
        }

        public void Start()
        {
            lock (this._lockObj)
            {
                if (this.IsStarted)
                    throw new InvalidOperationException("MuffinClient has already been started.");
                this.IsStarted = true;
            }

            this.PlatformLoader.Enable(this.Catalog, new PlatformArgs(this.PlatformLoader));
            this.ServiceLoader.Enable(this.Catalog, new ServiceArgs(this.PlatformLoader, this.ServiceLoader));
            this.MuffinLoader.Enable(this.Catalog, new MuffinArgs(this.PlatformLoader, this.ServiceLoader, this.MuffinLoader));
        }

        public virtual void Dispose()
        {
            this.MuffinLoader.Dispose();
            this.ServiceLoader.Dispose();
            this.PlatformLoader.Dispose();
            this.Catalog.Dispose();
        }
    }
}