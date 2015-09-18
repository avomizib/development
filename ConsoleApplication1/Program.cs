using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        private static void ValidateNewValue(Int32 value, Int32 low, Int32 top)
        {
            if (value <= low || value >= top)
            {
                throw new OverflowException(string.Format("Value in range [{0}-{1}] expected", low, top));
            }
        }

        static void Main(string[] args)
        {

            int wordCount = Convert.ToInt32(Console.ReadLine());
            try
            {
                ValidateNewValue(wordCount, 1, 5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            SortedDictionary<string, int> words = new SortedDictionary<string, int>();

            for (int i = 0; i < (int)wordCount; i++)
            {
                string[] ReadValue = Regex.Split(Console.ReadLine(), " ");
                words.Add(ReadValue[0], Convert.ToInt32(ReadValue[1]));
            }

            var items = from pair in words
                        orderby pair.Value descending
                        select pair;

            int userStringWordCount = Convert.ToInt32(Console.ReadLine());

            string[] userStringWords = new string[userStringWordCount];

            for (int i = 0; i < userStringWordCount; i++)
            {
                userStringWords[i] = Console.ReadLine();
            }



            foreach (var kvp in items)
            {
                Console.WriteLine(kvp.Key + ": " + kvp.Value.ToString());
            }





            //Thread.Sleep(0);
            Console.Read();
        }

    }
}
