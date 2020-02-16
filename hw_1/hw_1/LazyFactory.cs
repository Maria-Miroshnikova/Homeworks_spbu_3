using System;
using System.Collections.Generic;

namespace hw_1
{
    /// <summary>
    /// Class which provides two different types of lazy evaluation;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LazyFactory<T>
    {
        /// <summary>
        /// Returns lazy evaluation which does not guarantee correct work in many threads case;
        /// </summary>
        /// <param name="supplier"></param>
        public static ILazy<T> CreateLazy(Func<T> supplier) => new Lazy<T>(supplier);

        /// <summary>
        /// Returns lazy evaluation which guarantees correct work in many threads case;
        /// </summary>
        /// <param name="supplier"></param>
        public static ILazy<T> CreateThreadSafeLazy(Func<T> supplier) => new ThreadSafeLazy<T>(supplier);
    }
}
