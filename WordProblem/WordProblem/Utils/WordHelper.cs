using System.Collections.Generic;

using WordProblem.Model;

namespace WordProblem.Utils
{
    public static class WordHelper
    {
        public static IList<string> GetUsedWordsInCurrentSolution(SolutionNode solutionNode)
        {
            var words = new List<string>();
            var currentNode = solutionNode;
            while (currentNode != null)
            {
                words.Add(currentNode.Word);
                currentNode = currentNode.ParentSolutionNode;
            }
            return words;
        }

        public static bool IsSolutionComplete(string lastWord, string stop)
        {
            return DifferentLettersBetween(stop, lastWord) == 1;
        }

        public static int DifferentLettersBetween(string word1, string word2)
        {
            var letters1 = word1.ToLower().ToCharArray();
            var letters2 = word2.ToLower().ToCharArray();

            var diff = 0;

            for (int i = 0; i < letters1.Length; i++)
            {
                if (letters1[i] != letters2[i])
                {
                    diff++;
                }
            }

            return diff;
        }         
    }
}