using System;

namespace Hw_1
{
    /// <summary>
    /// Class Lazy which does not guarantee correct work in many threads case;
    /// </summary>
    class Lazy<T> : ILazy<T>
    {
        private Func<T> supplier;

        private T result;

        private bool isCreated = false;

        public Lazy(Func<T> supplier)
        {
            if (supplier == null)
            {
                throw new ArgumentNullException();
            }

            this.supplier = supplier;
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
                supplier = null;
                isCreated = true;
            }

            return result;
        }
    }
}
