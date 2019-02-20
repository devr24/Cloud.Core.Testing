using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Cloud.Core.Testing.Tests
{
    public class LoremTest
    {
        [Fact, IsUnit]
        public void Test_XUnitExtensions_FailPass()
        {
            var sentences = Lorem.Lorem.GetSentences(5);
            var paragraphs = Lorem.Lorem.GetParagraphs(5);


            var paragraphs1 = Lorem.Lorem.GetParagraphs(0);

            var moreParagraphs = Lorem.Lorem.GetParagraphs();
            var noParagraphs = Lorem.Lorem.GetParagraphs(1);
            var words = Lorem.Lorem.GetWords(5);
        }

        [Fact, IsUnit]
        public void Test_Lorem_GetSingleWord()
        {
            var word = Lorem.Lorem.GetWord();
            Assert.Single(word.Split(' '));
        }

        [Fact, IsUnit]
        public void Test_Lorem_GetSingleSentence()
        {
            var sentence = Lorem.Lorem.GetSentence();
            var split = sentence.Split('.').ToList();
            split.RemoveAll(string.IsNullOrEmpty);
            Assert.Single(split);
        }

        [Fact, IsUnit]
        public void Test_Lorem_GetSingleParagraph()
        {
            var paragraph = Lorem.Lorem.GetParagraph(3);

            var split = paragraph.Split('.').ToList();
            split.RemoveAll(string.IsNullOrEmpty);

            Assert.Equal(3, split.Count);
        }
    }
}
