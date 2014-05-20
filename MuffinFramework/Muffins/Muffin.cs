using System.ComponentModel.Composition;

namespace MuffinFramework.Muffins
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