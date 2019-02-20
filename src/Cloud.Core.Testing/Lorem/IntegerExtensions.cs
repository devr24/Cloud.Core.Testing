namespace System
{
    using Collections.Generic;

    /// <summary>
    /// Extension methods for integers
    /// </summary>
    internal static class IntegerExtensions
    {
        /// <summary>
        /// List of integers within the "to" and "from" range.
        /// </summary>
        /// <param name="from"><see cref="int"/> range from.</param>
        /// <param name="to"><see cref="int"/> range to.</param>
        /// <returns>Enumerable list of integers within the from and to range.</returns>
        public static IEnumerable<int> To(this int from, int to)
        {
            if (to >= from)
            {
                for (var i = from; i <= to; i++)
                {
                    yield return i;
                }
            }
            else
            {
                for (var i = from; i >= to; i--)
                {
                    yield return i;
                }
            }
        }
    }
}
