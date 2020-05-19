
namespace Hw_1
{
    /// <summary>
    /// Interface for lazy evalutation;
    /// </summary>
    public interface ILazy<T>
    {
        /// <summary>
        /// Calculate result of function if
        /// it is not calculated already and returns it; 
        /// </summary>
        T Get();
    }
}
