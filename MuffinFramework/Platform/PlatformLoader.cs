namespace MuffinFramework.Platform
{
    public class PlatformLoader : LayerLoader<PlatformBase, PlatformArgs>
    {
        public PlatformLoader()
            : base(new PlatformArgs())
        {
        }
    }
}