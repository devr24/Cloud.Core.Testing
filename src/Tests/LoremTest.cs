using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Cloud.Core.Testing.Tests
{
    public class LoremTest
    {
        [Fact, IsUnit]
        [LogExecutionTime]
        public void Test_XUnitExtensions_FailPass()
        {
            Console.WriteLine("TESTER");
            var sentences = Lorem.Lorem.GetSentences(5);
            var paragraphs = Lorem.Lorem.GetParagraphs(5);


            var paragraphs1 = Lorem.Lorem.GetParagraphs(0);

            var moreParagraphs = Lorem.Lorem.GetParagraphs();
            var noParagraphs = Lorem.Lorem.GetParagraphs(1);
            var words = Lorem.Lorem.GetWords(5);
        }

        [Fact, IsUnit]
        [LogExecutionTime]
        public void Test_Lorem_GetSingleWord()
        {
            var word = Lorem.Lorem.GetWord();
            Assert.Single(word.Split(' '));
        }

        [Fact, IsUnit]
        [LogExecutionTime]
        public void Test_Lorem_GetSingleSentence()
        {
            var sentence = Lorem.Lorem.GetSentence();
            var split = sentence.Split('.').ToList();
            split.RemoveAll(string.IsNullOrEmpty);
            Assert.Single(split);
        }

        [Fact, IsUnit]
        [LogExecutionTime]
        public void Test_Lorem_GetSingleParagraph()
        {
            var paragraph = Lorem.Lorem.GetParagraph(3);

            var split = paragraph.Split('.').ToList();
            split.RemoveAll(string.IsNullOrEmpty);

            Assert.Equal(3, split.Count);
        }

        [Fact, IsUnit]
        [LogExecutionTime]
        public void Test_Lorem_GetMultipleParagraphs()
        {
            var paragraph = Lorem.Lorem.GetParagraphs(5);
            paragraph.Count().Should().Be(5);
        }
    }
}
