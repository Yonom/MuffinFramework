using System;

namespace MuffinFramework.Platforms
{
    public abstract class PlatformPart<TProtocol> : LayerPart<TProtocol, PlatformArgs>
    {
        private PlatformLoader _platformLoader;

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

        public override void Enable(PlatformArgs args)
        {
            this.PlatformLoader = args.PlatformLoader;

            base.Enable(args);
        }
    }
}
