using MuffinFramework.Muffins;

namespace SampleApplication4.Muffins
{
    public class Muffin1 : Muffin
    {
        public Muffin1Part1 Part1 { get; private set; }

        protected override void Enable()
        {
            // To create a new MuffinPart instance, use the EnablePart<TPart, TProtocol>()
            // function. This will create a new instance of that part, set its variables, 
            // call Enable() and also take care of disposing it later. As an optional
            // parameter, you can provide a Host object. If none is provided, 
            // MuffinFramework tries to cast the current class to the given TProtocol
            // type.

            this.Part1 = this.EnablePart<Muffin1Part1, Muffin1>();
        }
    }
}