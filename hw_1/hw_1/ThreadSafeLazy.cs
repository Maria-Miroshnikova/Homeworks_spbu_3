using System;

namespace Hw_1
{
    /// <summary>
    /// Class Lazy which guarantees correct work in many threads case;
    /// </summary>
    class ThreadSafeLazy<T> : ILazy<T>
    {
        private Func<T> supplier;

        private bool isCreated = false;

        private T result;

        private readonly object locker = new object();

        public ThreadSafeLazy(Func<T> supplier)
        {
            this.supplier = supplier;
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Calculate result of function if
        /// it is not calculated already and returns it; 
        /// </summary>
        public T Get()
        {
            if (!isCreated)
            {
                result = supplier();
                isCreated = true;
            }

            return result;
        }
    }
}
