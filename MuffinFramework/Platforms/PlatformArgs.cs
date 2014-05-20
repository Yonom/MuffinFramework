namespace MuffinFramework.Platforms
{
    public class PlatformArgs
    {
        public PlatformArgs(PlatformLoader platformLoader)
        {
            this.PlatformLoader = platformLoader;
        }

        public PlatformLoader PlatformLoader { get; private set; }
    }
}