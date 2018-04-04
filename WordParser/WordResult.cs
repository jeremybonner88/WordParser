using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordParser
{
    public class WordResult
    {
        public string TopWord { get; set; }
        public string SecondWord { get; set; }
        public long Count { get; set; }
    }
    public static class WordResultExtensions
    {
        public static void ToOutput(this WordResult result)
        {
            Console.WriteLine("The top word created is: {0}", result.TopWord);
            Console.WriteLine("The second highest word created is: {0}", result.SecondWord);
            Console.WriteLine("Total count of how many of the words in the list can be constructed of other words in the list: {0}", result.Count);
        }
    }
}
