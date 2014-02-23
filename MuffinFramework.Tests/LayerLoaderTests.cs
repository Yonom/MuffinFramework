using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MuffinFramework.Tests
{
    [TestClass]
    public class LayerLoaderTests
    {
        [TestMethod]
        public void DoubleEnableTest()
        {
            // arrange
            InvalidOperationException expectedException = null;
            var loader = new LayerLoader<ILayerBase<object>, object>();
            loader.Enable(null, null);

            // act
            try
            {
                // try to start the loader a second time...
                loader.Enable(null, null);
            }
            catch (InvalidOperationException ex)
            {
                expectedException = ex;
            }


            // assert
            Assert.IsNotNull(expectedException);
        }

        [TestMethod]
        public void UnknownLayerTest()
        {
            // arrange
            KeyNotFoundException expectedException = null;
            var loader = new LayerLoader<ILayerBase<object>, object>();
            loader.Enable(null, null);

            // act
            try
            {
                loader.Get<ILayerBase<object>>();
            }
            catch (KeyNotFoundException ex)
            {
                expectedException = ex;
            }


            // assert
            Assert.IsNotNull(expectedException);
        }
    }
}
