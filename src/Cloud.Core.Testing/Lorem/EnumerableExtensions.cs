namespace System.Collections.Generic
{
    using Linq;

    /// <summary>
    /// Extension methods for enumerable.
    /// </summary>
    internal static class EnumerableExtensions
    {
        private static readonly Random Rng = new Random();

        /// <summary>
        /// Joins the list of items using a separator.
        /// </summary>
        /// <typeparam name="T">Generic type for items.</typeparam>
        /// <param name="items">The items to join.</param>
        /// <param name="separator">The separator used when joining.</param>
        /// <returns>String representation of items joined using separator.</returns>
        public static string Join<T>(this IEnumerable<T> items, string separator)
        {
            return items.Select(i => i.ToString())
                .Aggregate((acc, next) => string.Concat(acc, separator, next));
        }

        /// <summary>
        /// Random item from list of items.
        /// </summary>
        /// <typeparam name="T">Generic type of items.</typeparam>
        /// <param name="items">The list to get a single item from.</param>
        /// <returns>Randomly selected item of type T.</returns>
        public static T Rand<T>(this IEnumerable<T> items)
        {
            var list = items as IList<T> ?? items.ToList();
            return list[Rng.Next(list.Count)];
        }

        /// <summary>
        /// List of random items from a passed in generic list.
        /// </summary>
        /// <typeparam name="T">Generic type of enumerable items.</typeparam>
        /// <param name="items">The items to select from.</param>
        /// <param name="itemsToTake">The number of items to take.</param>
        /// <returns>Randomly selected list of items.</returns>
        public static IEnumerable<T> RandPick<T>(this IEnumerable<T> items, int itemsToTake)
        {
            var list = items as IList<T> ?? items.ToList();

            for (var i = 0; i < itemsToTake; i++)
                yield return list[Rng.Next(list.Count)];
        }

        /// <summary>
        /// Shuffles the specified array.
        /// From here:
        /// http://stackoverflow.com/questions/375351/most-efficient-way-to-randomly-sort-shuffle-a-list-of-integers-in-c
        /// </summary>
        /// <typeparam name="T">Generic type of enumerable items.</typeparam>
        /// <param name="array">The list of items to shuffle.</param>
        /// <returns>List of shuffled items.</returns>
        public static IList<T> Shuffle<T>(this IList<T> array)
        {
            var retArray = new T[array.Count];
            array.CopyTo(retArray, 0);

            for (var i = 0; i < array.Count; i += 1)
            {
                var swapIndex = Rng.Next(i, array.Count);
                if (swapIndex != i)
                {
                    var temp = retArray[i];
                    retArray[i] = retArray[swapIndex];
                    retArray[swapIndex] = temp;
                }
            }

            return retArray;
        }
    }

}
