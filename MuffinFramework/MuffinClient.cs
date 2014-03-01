using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using MuffinFramework.Muffins;
using MuffinFramework.Platforms;
using MuffinFramework.Services;

namespace MuffinFramework
{
    public class MuffinClient : IDisposable
    {
        private readonly object _lockObj = new object();

        public bool IsStarted { get; private set; }
        public AggregateCatalog AggregateCatalog { get; private set; }
        public PlatformLoader PlatformLoader { get; private set; }
        public ServiceLoader ServiceLoader { get; private set; }
        public MuffinLoader MuffinLoader { get; private set; }

        public MuffinClient()
        {
            this.AggregateCatalog = new AggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetCallingAssembly()));

            this.InitLoaders();
        }

        public MuffinClient(AggregateCatalog catalog)
        {
            this.AggregateCatalog = catalog;

            this.InitLoaders();
        }

        public MuffinClient(ComposablePartCatalog catalog1, params ComposablePartCatalog[] catalogs) : this(catalogs.Concat(new[] { catalog1 }))
        {
        }

        public MuffinClient(IEnumerable<ComposablePartCatalog> catalogs)
        {
            this.AggregateCatalog = new AggregateCatalog();
            foreach (var catalog in catalogs) {
                this.AggregateCatalog.Catalogs.Add(catalog);
            }

            this.InitLoaders();
        }

        private void InitLoaders()
        {
            this.PlatformLoader = new PlatformLoader();
            this.ServiceLoader = new ServiceLoader();
            this.MuffinLoader = new MuffinLoader();
        }

        public virtual void Start()
        {
            lock (this._lockObj) {
                if (this.IsStarted)
                    throw new InvalidOperationException("MuffinClient has already been started.");

                this.IsStarted = true;
            }

            this.PlatformLoader.Enable(this.AggregateCatalog, new PlatformArgs(this.PlatformLoader));
            this.ServiceLoader.Enable(this.AggregateCatalog, new ServiceArgs(this.PlatformLoader, this.ServiceLoader));
            this.MuffinLoader.Enable(this.AggregateCatalog, new MuffinArgs(this.PlatformLoader, this.ServiceLoader, this.MuffinLoader));
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            this.MuffinLoader.Dispose();
            this.ServiceLoader.Dispose();
            this.PlatformLoader.Dispose();
            this.AggregateCatalog.Dispose();
        }
    }
}
