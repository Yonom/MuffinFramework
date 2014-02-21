using System.ComponentModel.Composition;

namespace MuffinFramework.Muffin
{
    [InheritedExport(typeof(IMuffin))]
    public abstract class Muffin : MuffinPart<object>, IMuffin
    {
    }

    [InheritedExport(typeof(IMuffin))]
    public abstract class Muffin<TProtocol> : MuffinPart<TProtocol>, IMuffin
    {
    }
}
