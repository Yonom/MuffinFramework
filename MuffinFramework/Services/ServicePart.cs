using System;
using MuffinFramework.Platforms;

namespace MuffinFramework.Services
{
    public abstract class ServicePart<TProtocol> : LayerPart<TProtocol, ServiceArgs>
    {
        private PlatformLoader _platformLoader;
        private ServiceLoader _serviceLoader;

        protected PlatformLoader PlatformLoader
        {
            get { 
                if (!this.IsEnabled)
                    throw new InvalidOperationException("This object has not yet been Enabled.");

                return this._platformLoader; 
            }
            private set { this._platformLoader = value; }
        }

        protected ServiceLoader ServiceLoader
        {
            get
            {
                if (!this.IsEnabled)
                    throw new InvalidOperationException("This object has not yet been Enabled.");

                return this._serviceLoader;
            }
            private set { this._serviceLoader = value; }
        }

        public override void Enable(ServiceArgs args)
        {
            this.PlatformLoader = args.PlatformLoader;
            this.ServiceLoader = args.ServiceLoader;

            base.Enable(args);
        }
    }
}
