using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MuffinFramework.Tests.LayerPart;

namespace MuffinFramework.Tests.LayerBase
{
    [TestClass]
    public class LayerBaseTests
    {
        [TestMethod]
        public void EnableTest()
        {
            // arrange
            var layerBase = new LayerBaseTester<object>();

            // act
            layerBase.Enable(null);

            // assert
            Assert.IsTrue(layerBase.IsEnabled);
            Assert.IsTrue(layerBase.EnableWasCalled);
        }

        public void DoubleEnableTest()
        {
            // arrange
            InvalidOperationException expectedException = null;
            var layerBase = new LayerBaseTester<object>();
            layerBase.Enable(null);

            // act
            try
            {
                // try to start the LayerBase a second time...
                layerBase.Enable(null);
            }
            catch (InvalidOperationException ex)
            {
                expectedException = ex;
            }


            // assert
            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void EnablePartTest()
        {
            // arrange
            var layerBase = new LayerBaseTester<object>();
            layerBase.Enable(null);
            var host = new object();

            // act
            var layerPart = layerBase.TestEnablePart<LayerPartTester<object, object>, object>(host);

            // assert
            Assert.IsTrue(layerPart.IsEnabled);
            Assert.AreSame(host, layerPart.Host);
        }

        [TestMethod]
        public void EnablePartTest2()
        {
            // arrange
            var layerBase = new LayerBaseTester<object>();
            layerBase.Enable(null);

            // act
            var layerPart = layerBase.TestEnablePart<LayerPartTester<LayerBaseTester<object>, object>, LayerBaseTester<object>>();

            // assert
            Assert.AreSame(layerBase, layerPart.Host);
        }
    }
}
