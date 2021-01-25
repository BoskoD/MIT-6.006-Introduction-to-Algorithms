// REF: http://courses.csail.mit.edu/6.006/spring11/lectures/lec01.pdf

// Algorithm:
//  1.Read each document
//  2.Split each document into words. A valid word is at least 3 characters long.
//  3.Count word frequencies (document vectors) for each document
//  4.Compute dot product for doc 1 and 2
//  5.Compute document distance . 0=identical, 1.57= completely different


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Document_Distance_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file1 = ReadData("http://courses.csail.mit.edu/6.006/fall07/data/t1.verne.txt");
            string file2 = ReadData("http://courses.csail.mit.edu/6.006/fall07/data/t2.bobsey.txt");

            var firstFrequencies = ComputeFrequency(file1);
            var secondFrequencies = ComputeFrequency(file2);

            var distance = ComputeDistance(firstFrequencies, secondFrequencies);

            Console.WriteLine($"The distance is: {distance}");
            
        }

        private static Dictionary<string, int> ComputeFrequency(string data)
        {
            Dictionary<string, int> dictionaryWordCound = new Dictionary<string, int>();

            // convert all non-alphabet and non-number characters into spaces.
            Regex regex = new Regex(@"[/W_]+");
            string result = regex.Replace(data, " ");

            // parse words from text
            var words = Regex.Matches(result, @"\w{3,}", RegexOptions.IgnoreCase)
                .OfType<Match>()
                .Select(m => m.Groups[0].Value)
                .ToArray();

            // get word count for each word in array
            dictionaryWordCound = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (dictionaryWordCound.ContainsKey(word))
                {
                    dictionaryWordCound[word] += 1;
                }
                else
                {
                    dictionaryWordCound.Add(word, 1);
                }
            }
            return dictionaryWordCound;
        }

        public static double ComputeDistance(Dictionary<string, int> first, Dictionary<string, int> second)
        {
            var numerator = GetInnerProduct(first, second);
            var denominator = Math.Sqrt(GetInnerProduct(first, first) * GetInnerProduct(second, second));
            return Math.Acos(numerator / denominator);
        }

        private static int GetInnerProduct(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            int total, count1, count2,  finalTotal = 0;

            foreach (KeyValuePair<string, int> pair in dict1)
            {
                string word = pair.Key;
                count1 = pair.Value;

                if (dict2.ContainsKey(word))
                {
                    count2 = dict2[word];
                    total = count1 * count2;
                    finalTotal += total;
                }
            }
            return finalTotal;
        }

        public static string ReadData(string url)
        {
                // Create a request for the URL.
                WebRequest request = WebRequest.Create(url);

                // Get the response.
                using WebResponse response = request.GetResponse();
                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                return responseFromServer;
            
        }
    }
}
