namespace MuffinFramework.Platform
{
    public class PlatformArgs
    {
        public PlatformLoader PlatformLoader { get; private set; }

        public PlatformArgs(PlatformLoader platformLoader)
        {
            PlatformLoader = platformLoader;
        }
    }
}