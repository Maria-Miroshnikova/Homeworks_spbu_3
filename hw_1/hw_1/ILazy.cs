using System;
using System.Collections.Generic;

namespace hw_1
{
    /// <summary>
    /// Interface for lazy evalutation;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILazy<T>
    {
        /// <summary>
        /// Calculate result of function if
        /// it is not calculated already and returns it; 
        /// </summary>
        T Get();
    }
}
