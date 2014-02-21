using System.ComponentModel.Composition;

namespace MuffinFramework.Service
{
    [InheritedExport(typeof(IService))]
    public abstract class Service : ServicePart<object>, IService
    {
    }

    [InheritedExport(typeof(IService))]
    public abstract class Service<TProtocol> : ServicePart<TProtocol>, IService
    {
    }
}
