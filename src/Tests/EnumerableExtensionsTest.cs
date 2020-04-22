using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    [IsUnit]
    public class EnumerableExtensionsTest
    {
        /// <summary>Check words are randomly selected as expected using extension method.</summary>
        [Fact]
        public void Test_Enumerable_RandPick()
        {
            // Act
            var testCollection = new List<string> { "one", "two", "three", "four", "five" };

            // Arrange
            var rand = testCollection.RandPick(3);

            // Assert
            Assert.Equal(3, rand.Count());
        }

        /// <summary>Check words are joined as expected using extension method.</summary>
        [Fact]
        public void Test_Enumerable_Join()
        {
            // Act
            var testCollection = new List<string> { "one", "two", "three", "four", "five" };

            // Arrange
            var joined = testCollection.Join(" ");

            // Assert
            Assert.Equal("one two three four five", joined);
        }

        /// <summary>Check words are randomly selected from the source list as expected.</summary>
        [Fact]
        public void Test_Enumerable_Rand()
        {
            // Act
            var testCollection = new List<string> { "one", "two", "three", "four", "five" };

            // Arrange
            var rand = testCollection.Rand();

            // Assert
            Assert.NotEmpty(testCollection.Where(i => i == rand));
        }

        /// <summary>Check words are randomly shuffled as expected.</summary>
        [Fact]
        public void Test_Enumerable_Shuffle()
        {
            // Act
            var testCollection = new List<string> { "one", "two", "three", "four", "five" };

            // Arrange
            var shuffleCollection = testCollection.Shuffle();

            // Assert
            Assert.NotEqual(testCollection, shuffleCollection);
        }
    }
}
