using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hw_1.Test
{
    [TestClass]
    public class LazyTest
    {
        private ILazy<int> lazy;

        [TestMethod]
        public void LazyExpectedBehaviorTest()
        {
            lazy = LazyFactory<int>.CreateLazy(() => 11 * 12);

            for (var i = 0; i < 5; ++i)
            {
                Assert.AreEqual(11 * 12, lazy.Get());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSupplierLazyTest()
        {
            lazy = LazyFactory<int>.CreateLazy(null);
        }

        [TestMethod]
        public void LazyOneFunctionCallTest()
        {
            int testResult = 0;
            int testAnswer = 1;

            lazy = LazyFactory<int>.CreateLazy(() => ++testResult);

            for (var i = 0; i < 5; ++i)
            {
                Assert.AreEqual(testAnswer, lazy.Get());
            }
        }
    }
}
