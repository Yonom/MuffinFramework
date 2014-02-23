namespace MuffinFramework.Platforms
{
    public class PlatformArgs
    {
        public PlatformLoader PlatformLoader { get; private set; }

        public PlatformArgs(PlatformLoader platformLoader)
        {
            this.PlatformLoader = platformLoader;
        }
    }
}