using MuffinFramework.Platform;
using MuffinFramework.Service;

namespace MuffinFramework.Muffin
{
    public class MuffinLoader : LayerLoader<MuffinBase, MuffinArgs>
    {
        public MuffinLoader(PlatformLoader platformLoader, ServiceLoader serviceLoader)
            : base(new MuffinArgs(platformLoader, serviceLoader))
        {
        }
    }
}