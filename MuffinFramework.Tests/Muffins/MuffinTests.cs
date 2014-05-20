using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MuffinFramework.Tests.Muffins
{
    /// <summary>
    ///     Summary description for MuffinTests
    /// </summary>
    [TestClass]
    public class MuffinTests
    {
        [TestMethod]
        public void LoadMuffinTest()
        {
            // arrange
            var client = new MuffinClient(new TypeCatalog(typeof(MuffinTester)));

            // act
            client.Start();

            // assert
            Assert.IsTrue(client.MuffinLoader.OfType<MuffinTester>().Any());
        }

        [TestMethod]
        public void MuffinArgsTest()
        {
            // arrange
            var client = new MuffinClient(new TypeCatalog(typeof(MuffinTester)));
            client.Start();

            // act
            var muffin = client.MuffinLoader.Get<MuffinTester>();

            // assert
            Assert.IsNotNull(muffin.TestMuffinLoader);
            Assert.IsNotNull(muffin.TestServiceLoader);
            Assert.IsNotNull(muffin.TestPlatformLoader);
        }
    }
}