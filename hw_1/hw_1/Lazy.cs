using System;
using System.Collections.Generic;

namespace hw_1
{
    /// <summary>
    /// Class Lazy which does not guarantee correct work in many threads case;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Lazy<T> : ILazy<T>
    {
        private Func<T> supplier;

        private T result;

        private bool isCreated = false;

        public Lazy(Func<T> supplier)
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
