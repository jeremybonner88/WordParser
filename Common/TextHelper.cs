using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Concurrent;

namespace Common
{
    public class TextHelper
    {
        public List<string> OrderedWords { get { return System.IO.File.ReadAllLines("wordlist.txt").Select(w => w.Trim()).OrderByDescending(word => word.Length).ToList(); } }
        public long TotalCount { get; set; }
        public long GetCountOfWordsBuiltFromOtherWords()
        {
            HashSet<String> parallelTrial = new HashSet<String>(OrderedWords); ;
            return OrderedWords.AsParallel().Where(word => IsMadeWithWords(word, parallelTrial)).Count();
        }

        public IEnumerable<string> FindLongestTwoWords()
        {
            if (OrderedWords == null) return new List<string>();
            return OrderedWords.Where(word => IsMadeWithWords(word, new HashSet<String>(OrderedWords))).Take(2);
        }

        private static bool IsMadeWithWords(string word, HashSet<string> sortedWords)
        {
            if (String.IsNullOrEmpty(word)) return false;
            if (word.Length == 1)
            {
                //need more comprehensive solution to handeling plurals
                if (sortedWords.Contains(word) || word == "s")
                {
                    return true;
                }
                else return false;
            }
            var pairs = GenerateWordPairs(word);
            for (int i = 0; i < pairs.Count(); i++)
            {
                if (sortedWords.Contains(pairs[i].Item1))
                {
                    if (sortedWords.Contains(pairs[i].Item2))
                    {
                        return true;
                    }
                    else if (i < pairs.Count - 1 && sortedWords.Contains(pairs[i + 1].Item1))
                    {
                        i++;
                        if (sortedWords.Contains(pairs[i].Item2))
                        {
                            return true;
                        }
                        else
                        {
                            IsMadeWithWords(pairs[i].Item2, sortedWords);
                        }
                    }
                    else
                    {
                        return IsMadeWithWords(pairs[i].Item2, sortedWords);
                    }
                }
            }
            return false;
        }

        private static List<Tuple<string, string>> GenerateWordPairs(string word)
        {
            var output = new List<Tuple<string, string>>();
            for (int i = 1; i < word.Length; i++)
            {
                output.Add(Tuple.Create(word.Substring(0, i), word.Substring(i)));
            }
            return output;
        }
    }
}
