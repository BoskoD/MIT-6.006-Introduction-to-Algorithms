using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Document_Distance_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = ReadData("http://courses.csail.mit.edu/6.006/fall07/data/t1.verne.txt");
            string second = ReadData("http://courses.csail.mit.edu/6.006/fall07/data/t1.verne.txt");

            string firstStringCleaned = RemoveWhitespace(first);
            string secondStringCleaned = RemoveWhitespace(second);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int levDist = LevenshteinMatrix(firstStringCleaned, secondStringCleaned);
            sw.Stop();

            Console.WriteLine($"Document distance: {levDist}.");
            Console.WriteLine($"Time elapsed: {sw.Elapsed.TotalSeconds} seconds.");
        }
        static int LevenshteinMatrix(string first, string second)
        {
            int firstStringLength = first.Length;
            int secondStringLength = second.Length;

            int[,] matrix = new int[firstStringLength + 1, secondStringLength + 1];

            // check if strings are empty
            if (firstStringLength == 0)
            {
                return secondStringLength;
            }
            if (secondStringLength == 0)
            {
                return firstStringLength;
            }

            // initialize the matrix
            for (int i = 0; i <= firstStringLength; i++)
                matrix[i, 0] = i;
            for (int j = 0; j <= secondStringLength; j++)
                matrix[0, j] = j;

            for (int j = 1; j <= secondStringLength; j++)
                for (int i = 1; i <= firstStringLength; i++)
                    if (first[i - 1] == second[j - 1])
                        matrix[i, j] = matrix[i - 1, j - 1];  //no operation
                    else
                        matrix[i, j] = Math.Min(Math.Min(
                            matrix[i - 1, j] + 1,    //a deletion
                            matrix[i, j - 1] + 1),   //an insertion
                            matrix[i - 1, j - 1] + 1 //a substitution
                            );
            return matrix[firstStringLength, secondStringLength];
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
        static string RemoveWhitespace(string t) 
        {
            string cleanup = Regex.Replace(t, @"\s+", "");
            return cleanup;
        }
    }
}
