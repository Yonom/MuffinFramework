using System.ComponentModel.Composition;

namespace MuffinFramework.Platform
{
    [InheritedExport(typeof(PlatformBase))]
    public abstract class Platform : PlatformBase
    {
    }
}
