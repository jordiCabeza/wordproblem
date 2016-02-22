using NUnit.Framework;

namespace WordProblem.Tests
{
    [TestFixture]
    public class WordSearchTests
    {
        [Test]
        public void ShouldResolveWhenStartStopAreTheSame()
        {
            // Arrange
            var start = "AAAA";
            var stop = "AAAA";
            var wordSearch = new WordSearch();

            // Act
            var solution = wordSearch.Resolve(new[] { "AAAA" }, start, stop);

            // Assert
            Assert.IsNotNull(solution);
            Assert.That(solution.Count, Is.EqualTo(2));

            Assert.That(solution[0], Is.EqualTo(start));
            Assert.That(solution[1], Is.EqualTo(stop));
        }


        [Test]
        public void ShouldResolveWhenStartStopHaveOnly1Difference()
        {
            // Arrange
            var start = "AAAA";
            var stop = "AAAZ";
            var wordSearch = new WordSearch();

            // Act
            var solution = wordSearch.Resolve(new[] { "AAAA", "AAAB", "AAAZ" }, start, stop);

            // Assert
            Assert.IsNotNull(solution);
            Assert.That(solution.Count, Is.EqualTo(2));

            Assert.That(solution[0], Is.EqualTo(start));
            Assert.That(solution[1], Is.EqualTo(stop));
        }


        [Test]
        public void ShouldResolveWhenStartStopHaveMoreTHan1Difference()
        {
            // Arrange
            var start = "AAAA";
            var stop = "AAZZ";
            var wordSearch = new WordSearch();

            // Act
            var dictionary = new[] { "ABAA", "AAAA", "ABZA", "ABZZ", "AAZZ" };            


            var solution = wordSearch.Resolve(dictionary, start, stop);

            // Assert
            Assert.IsNotNull(solution);
            Assert.That(solution.Count, Is.EqualTo(5));

            Assert.That(solution[0], Is.EqualTo(start));
            Assert.That(solution[1], Is.EqualTo("ABAA"));
            Assert.That(solution[2], Is.EqualTo("ABZA"));
            Assert.That(solution[3], Is.EqualTo("ABZZ"));
            Assert.That(solution[4], Is.EqualTo("AAZZ"));
        }
    }
}