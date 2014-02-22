using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using MuffinFramework;
using SampleApplication6.Muffins;

namespace SampleApplication6
{
    class Program
    {
        // This sample demonstrates how you can load classes that are not located in the
        // main assembly of your program. This requires you to refrence 
        // System.ComponentModel.Composition.
        // Muffin1 is stored in SampleApplication6.Muffins.dll assembly and should be 
        // loaded from SampleApplication6.exe.
        static void Main()
        {
            var client = new MuffinClient();

            // Get the MuffinsAssembly and add it to the clients catalog
            Assembly muffinsAssembly = typeof(Muffin1).Assembly;
            client.Catalog.Catalogs.Add(new AssemblyCatalog(muffinsAssembly));

            client.Start();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();

            client.Dispose();
        }
    }
}
