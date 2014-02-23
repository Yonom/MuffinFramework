using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MuffinFramework.Tests.LayerPart
{
    [TestClass]
    public class LayerPartTests
    {
        [TestMethod]
        public void EnableTest()
        {
            // arrange
            var layerPart = new LayerPartTester<object, object>();
            var host = new object();

            // act
            layerPart.Enable(host, null);

            // assert
            Assert.AreSame(host, layerPart.Host);
            Assert.IsTrue(layerPart.IsEnabled);
            Assert.IsTrue(layerPart.EnableWasCalled);
        }

        public void DoubleEnableTest()
        {
            // arrange
            InvalidOperationException expectedException = null;
            var layerPart = new LayerPartTester<object, object>();
            layerPart.Enable(new object(), null);

            // act
            try
            {
                // try to start the LayerPart a second time...
                layerPart.Enable(null, null);
            }
            catch (InvalidOperationException ex)
            {
                expectedException = ex;
            }


            // assert
            Assert.IsNotNull(expectedException);
            Assert.IsNotNull(layerPart.Host);
        }

        [TestMethod]
        public void EnablePartTest()
        {
            // arrange
            var layerPart1 = new LayerPartTester<object, object>();
            layerPart1.Enable(null, null);
            var host = new object();

            // act
            var layerPart2 = layerPart1.TestEnablePart<LayerPartTester<object, object>>(host);

            // assert
            Assert.IsTrue(layerPart2.IsEnabled);
            Assert.AreSame(host, layerPart2.Host);
        }

        [TestMethod]
        public void EnablePartTest2()
        {
            // arrange
            var layerPart1 = new LayerPartTester2<object>();

            // act
            layerPart1.Enable(null, null);
            var layerPart2 = layerPart1.TestEnablePart<LayerPartTester<LayerPartTester2<object>, object>>();

            // assert
            Assert.AreSame(layerPart1, layerPart2.Host);
        }
    }
}
