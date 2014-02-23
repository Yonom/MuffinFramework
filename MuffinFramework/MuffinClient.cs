using System;
using System.ComponentModel.Composition.Hosting;
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

            this.PlatformLoader = new PlatformLoader();
            this.ServiceLoader = new ServiceLoader();
            this.MuffinLoader = new MuffinLoader();
        }

        public virtual void Start()
        {
            lock (this._lockObj)
            {
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
            this.MuffinLoader.Dispose();
            this.ServiceLoader.Dispose();
            this.PlatformLoader.Dispose();
            this.AggregateCatalog.Dispose();
        }
    }
}