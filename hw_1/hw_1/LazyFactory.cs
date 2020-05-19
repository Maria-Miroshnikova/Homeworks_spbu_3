using System;

namespace Hw_1
{
    /// <summary>
    /// Class which provides two different types of lazy evaluation;
    /// </summary>
    public class LazyFactory<T>
    {
        /// <summary>
        /// Returns lazy evaluation which does not guarantee correct work in many threads case;
        /// </summary>
        public static ILazy<T> CreateLazy(Func<T> supplier) => new Lazy<T>(supplier);

        /// <summary>
        /// Returns lazy evaluation which guarantees correct work in many threads case;
        /// </summary>
        public static ILazy<T> CreateThreadSafeLazy(Func<T> supplier) => new ThreadSafeLazy<T>(supplier);
    }
}
