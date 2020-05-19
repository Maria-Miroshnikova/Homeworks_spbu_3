using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hw_1.Test
{
    [TestClass]
    public class ThreadSafeLazyTest
    {
        private ILazy<int> lazy;

        private Thread[] threads;

        [TestMethod]
        public void ThreadSafeLazyExpectedBehaviorOneThreadTest()
        {
            lazy = LazyFactory<int>.CreateThreadSafeLazy(() => 11 * 12);
            
            for (var i = 0; i < 5; ++i)
            {
                Assert.AreEqual(11 * 12, lazy.Get());
            }
        }

        [TestMethod]
        public void ThreadSafeLazyExpectedBehaviorManyThreadsTest()
        {
            threads = new Thread[5];

            lazy = LazyFactory<int>.CreateThreadSafeLazy(() => 11 * 12);

            for (var i = 0; i < threads.Length; ++i)
            {
                threads[i] = new Thread(() =>
                {
                    Assert.AreEqual(11 * 12, lazy.Get());
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSupplierThreadSafeLazyTest()
        {
            lazy = LazyFactory<int>.CreateThreadSafeLazy(null);
        }

        [TestMethod]
        public void ThreadSafeLazyOneFunctionCallOneThreadsTest()
        {
            int testResult = 0;
            int testAnswer = 1;

            lazy = LazyFactory<int>.CreateThreadSafeLazy(() => ++testResult);

            for (var i = 0; i < 5; ++i)
            {
                Assert.AreEqual(testAnswer, lazy.Get());
            }
        }

        [TestMethod]
        public void ThreadSafeLazyOneFunctionCallManyThreadsTest()
        {
            for (var k = 0; k < 100; ++k)
            {
                threads = new Thread[5];

                int testResult = 0;
                int testAnswer = 1;

                lazy = LazyFactory<int>.CreateThreadSafeLazy(() => ++testResult);

                for (var i = 0; i < threads.Length; ++i)
                {
                    threads[i] = new Thread(() =>
                    {
                        Assert.AreEqual(testAnswer, lazy.Get());
                    });
                }

                foreach (var thread in threads)
                {
                    thread.Start();
                }

                foreach (var thread in threads)
                {
                    thread.Join();
                }
            }
        }
    }
}
