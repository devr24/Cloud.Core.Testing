using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    [IsUnit]
    public class LoremTest
    {
        /// <summary>Check a single word is generated as expected.</summary>
        [Fact]
        public void Test_Lorem_GetSingleWord()
        {
            // Arrange/Act
            var word = Lorem.Lorem.GetWord();  // single word.

            // Assert
            Assert.Single(word.Split(' '));
        }

        /// <summary>Check multiple words are generated as expected.</summary>
        [Fact]
        public void Test_Lorem_MultipleWords()
        {
            // Arrange/Act
            var words = Lorem.Lorem.GetWords(5); // multiple words.

            // Assert
            words.Count().Should().Be(5);
        }

        /// <summary>Check single sentence is generated as expected.</summary>
        [Fact]
        public void Test_Lorem_GetSingleSentence()
        {
            // Arrange/Act
            var sentence = Lorem.Lorem.GetSentence(); // multiple words in a single sentence.
            var split = sentence.Split('.', StringSplitOptions.RemoveEmptyEntries).ToList();

            // Assert
            Assert.Single(split);
        }

        /// <summary>Check multiple sentences are generated as expected when default is used.</summary>
        [Fact]
        public void Test_Lorem_GetMultipleSentencesDefault()
        {
            // Arrange/Act
            var sentences = Lorem.Lorem.GetSentences();  // get multiple sentences default.

            // Assert
            sentences.Count().Should().BeGreaterThan(0);
        }

        /// <summary>Check single paragraph is generated as expected.</summary>
        [Fact]
        public void Test_Lorem_GetSingleParagraph()
        {
            // Arrange/Act
            var paragraph = Lorem.Lorem.GetParagraph(5);  // get single paragraph, multiple sentences.

            var split = paragraph.Split('.', StringSplitOptions.RemoveEmptyEntries).ToList();

            // Assert
            Assert.Equal(5, split.Count);
        }

        /// <summary>Check multiple paragraphs are generated as expected.</summary>
        [Fact]
        public void Test_Lorem_GetMultipleParagraphs()
        {
            // Arrange/Act
            var paragraph = Lorem.Lorem.GetParagraphs(5); // get multiple paragraphs.

            // Assert
            paragraph.Count().Should().Be(5);
        }

        /// <summary>Check multiple paragraphs are generated as expected when default is used.</summary>
        [Fact]
        public void Test_Lorem_GetParagraphsDefault()
        {
            // Arrange/Act
            var paragraphs = Lorem.Lorem.GetParagraphs(); // get paragraphs default.

            // Assert
            paragraphs.Count().Should().BeGreaterThan(0);
        }
    }
}
