using System.Threading;
using MuffinFramework;

namespace TestProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new MuffinClient();
            client.Start();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
