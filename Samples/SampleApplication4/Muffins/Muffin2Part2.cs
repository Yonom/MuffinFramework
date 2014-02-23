using MuffinFramework.Muffins;

namespace SampleApplication4.Muffins
{
    public class Muffin2Part2 : MuffinPart<Muffin2>
    {
        protected override void Enable()
        {
            // Part1 is accessed through Muffin1 here
            this.Host.Part1.HelloWorld();
        }
    }
}
