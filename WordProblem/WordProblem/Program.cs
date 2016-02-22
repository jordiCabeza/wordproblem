using System;
using System.IO;

namespace WordProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = File.ReadAllLines(@"C:\Windows\Temp\WordList\WordList.txt");

            Console.Write("Insert 4 letter start word:");
            var start = Console.ReadLine();
            
            Console.Write("Insert 4 letter stop word:");
            var stop = Console.ReadLine();

            var wordSearch = new WordSearch();

            var solution = wordSearch.Resolve(words, start, stop);

            Console.WriteLine("\n\rSolution:");

            if (solution != null)
            {
                foreach (var word in solution)
                {
                    Console.WriteLine(word);
                }
            }
            else
            {
                Console.WriteLine("There is no solution.");
            }

            Console.WriteLine("\n\rPress enter to exit");

            Console.ReadLine();
        }
    }
}
