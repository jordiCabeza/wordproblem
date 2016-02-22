using System.Collections.Generic;
using System.Linq;

using WordProblem.Model;
using WordProblem.Utils;

namespace WordProblem
{
    public class WordSearch
    {
        private SolutionNode _solution;
        private Dictionary<string, SolutionNode> _usedWords;
        public IList<string> Resolve(string[] dictionary, string start, string stop)
        {
            this._solution = null;
            _usedWords = new Dictionary<string, SolutionNode>();

            if (start == stop || WordHelper.DifferentLettersBetween(start, stop) == 1)
            {
                return new List<string> { start, stop };
            }

            var root = new SolutionNode(start, null);


            this.FindSolution(root, dictionary, start, stop);


            if (this._solution == null)
            {
                return null;    
            }

            var usedWords = WordHelper.GetUsedWordsInCurrentSolution(this._solution);

            return usedWords.Reverse().ToList();
        }

        private void FindSolution(SolutionNode parent, string[] dictionary, string start, string stop)
        {
            foreach (var word in dictionary)
            {
                if (word != start && word != stop && !WordHelper.GetUsedWordsInCurrentSolution(parent).Contains(word))
                {
                    var differenceStartInSolution = WordHelper.DifferentLettersBetween(word, parent.Word);
                                                             
                    if (differenceStartInSolution == 1)
                    {
                        var node = new SolutionNode(word, parent);

                        if (_usedWords.ContainsKey(word) && _usedWords[word].Depth < node.Depth)
                        {
                            return;
                        }

                        _usedWords.Remove(word);
                        _usedWords.Add(word, node);

                        parent.Children.Add(node);

                        if (WordHelper.IsSolutionComplete(word, stop))
                        {
                            var solutionNode = new SolutionNode(stop, node);
                            if (_solution == null)
                            {
                                _solution = solutionNode;                                                  
                            }

                            if (_solution.Depth > solutionNode.Depth)
                            {
                                _solution = solutionNode;
                            }

                            return;
                        }
                        
                        if (_solution != null && node.Depth >= _solution.Depth)
                        {
                            return;
                        }

                        this.FindSolution(node, dictionary, start, stop);
                    }
                }
            }
        }
    }
}
