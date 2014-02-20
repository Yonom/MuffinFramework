using System.Threading;
using MuffinFramework;

namespace TestProject
{
    public class Program
    {
        private static void Main()
        {
            var client = new MuffinClient();
            client.Start();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
