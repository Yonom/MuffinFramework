using System.ComponentModel.Composition;

namespace MuffinFramework.Platforms
{
    [InheritedExport(typeof(IPlatform))]
    public abstract class Platform : PlatformPart<object>, IPlatform
    {
    }

    [InheritedExport(typeof(IPlatform))]
    public abstract class Platform<TProtocol> : PlatformPart<TProtocol>, IPlatform
    {
    }
}
