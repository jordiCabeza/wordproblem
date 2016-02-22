using System.Collections.Generic;

using NUnit.Framework;
using NUnit.Framework.Interfaces;

using WordProblem.Model;
using WordProblem.Utils;

namespace WordProblem.Tests.Utils
{
    [TestFixture]
    public class UtilsTest
    {
        [TestCase("word", "word", 0)]
        [TestCase("word", "ward", 1)]
        [TestCase("word", "wars", 2)]
        [TestCase("word", "mars", 3)]
        [TestCase("word", "mass", 4)]
        public void ShouldGetNumberOfDifferenceBetweenTwoWords( string word1, string word2, int expectNumberOfDifferences)
        {            
            // Act
            var numberOfDifference = WordHelper.DifferentLettersBetween(word1, word2);
            
            // Assert
            Assert.That(numberOfDifference, Is.EqualTo(expectNumberOfDifferences));
        }

        [TestCase("word", "word", false)]
        [TestCase("word", "ward", true)]
        [TestCase("word", "wars", false)]
        [TestCase("word", "mars", false)]
        [TestCase("word", "mass", false)]
        public void ShouldCheckIfSolutionIsComplete(string lastWord, string stop, bool expectedIsCompleted)
        {
            // Act
            var isCompleted = WordHelper.IsSolutionComplete(lastWord, stop);
            
            // Assert
            Assert.That(isCompleted, Is.EqualTo(expectedIsCompleted));
        }


        [Test]
        public void ShouldGetUsedWordsInCurrentSolution()
        {
            // Arrange
            var root = new SolutionNode("root", null);
            var node1 = new SolutionNode("w1", root);
            var node2 = new SolutionNode("w2", root);
            var node3 = new SolutionNode("w3", node1);

            root.Children = new List<SolutionNode> { node1, node2 };
            node1.Children = new List<SolutionNode> { node3 };            
            
            // Act
            var solution = WordHelper.GetUsedWordsInCurrentSolution(node3);

            // Assert
            Assert.IsNotNull(solution);
            
            Assert.That(solution.Count, Is.EqualTo(3));
            
            Assert.That(solution[2], Is.EqualTo(root.Word));
            Assert.That(solution[1], Is.EqualTo(node1.Word));
            Assert.That(solution[0], Is.EqualTo(node3.Word));
        }
    }
}