using System;
using MuffinFramework.Platforms;
using MuffinFramework.Services;

namespace MuffinFramework.Muffins
{
    public abstract class MuffinPart<TProtocol> : LayerPart<TProtocol, MuffinArgs>
    {
        private PlatformLoader _platformLoader;
        private ServiceLoader _serviceLoader;
        private MuffinLoader _muffinLoader;

        protected PlatformLoader PlatformLoader
        {
            get
            {
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

        protected MuffinLoader MuffinLoader
        {
            get
            {
                if (!this.IsEnabled)
                    throw new InvalidOperationException("This object has not yet been Enabled.");

                return this._muffinLoader;
            }
            private set { this._muffinLoader = value; }
        }

        public override void Enable(MuffinArgs args)
        {
            this.PlatformLoader = args.PlatformLoader;
            this.ServiceLoader = args.ServiceLoader;
            this.MuffinLoader = args.MuffinLoader;

            base.Enable(args);
        }
    }
}
