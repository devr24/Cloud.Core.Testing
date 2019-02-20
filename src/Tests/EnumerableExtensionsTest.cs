using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    public class EnumerableExtensionsTest
    {
        [Fact, IsUnit]
        public void Test_Enumerable_RandPick()
        {
            var testCollection = new List<string> { "one", "two", "three", "four", "five" };
            var rand = testCollection.RandPick(3);

            Assert.Equal(3, rand.Count());
        }

        [Fact, IsUnit]
        public void Test_Enumerable_Join()
        {
            var testCollection = new List<string> { "one", "two", "three", "four", "five" };
            var joined = testCollection.Join(" ");

            Assert.Equal("one two three four five", joined);
        }

        [Fact, IsUnit]
        public void Test_Enumerable_Rand()
        {
            var testCollection = new List<string> { "one", "two", "three", "four", "five" };
            var rand = testCollection.Rand();

            Assert.NotEmpty(testCollection.Where(i => i == rand));
        }

        [Fact, IsUnit]
        public void Test_Enumerable_Shuffle()
        {
            var testCollection = new List<string> { "one", "two", "three", "four", "five" };
            var shuffleCollection = testCollection.Shuffle();

            Assert.NotEqual(testCollection, shuffleCollection);
        }
    }
}
