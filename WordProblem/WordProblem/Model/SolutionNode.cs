using System;
using System.Collections.Generic;

namespace WordProblem.Model
{
    public class SolutionNode
    {
        public String Word { get; set; }

        public int Depth { get; set; }

        public SolutionNode ParentSolutionNode { get; set; }

        public List<SolutionNode> Children = new List<SolutionNode>();

        public SolutionNode(string word, SolutionNode parentSolutionNode)
        {
            Word = word;
            Children = new List<SolutionNode>();
            this.ParentSolutionNode = parentSolutionNode;

            if (this.ParentSolutionNode != null)
            {
                Depth = parentSolutionNode.Depth + 1;
            }

        }
    }
}