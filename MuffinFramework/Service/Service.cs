using System.ComponentModel.Composition;

namespace MuffinFramework.Service
{
    [InheritedExport(typeof(ServiceBase))]
    public abstract class Service : ServiceBase
    {
    }
}
