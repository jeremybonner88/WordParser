using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordParser
{
    class Program
    {
        static void Main(string[] args)
        {
            TextHelper textImporter = new TextHelper();
            var topTwoWords = textImporter.FindLongestTwoWords().ToList();
            var result = new WordResult()
            {
                TopWord = topTwoWords.First(),
                SecondWord = topTwoWords.Skip(1).First(),
                Count = textImporter.GetCountOfWordsBuiltFromOtherWords()
            };
            result.ToOutput();
            //To persist the Console box
            Console.ReadKey();
        }
    }
}
