using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Peak_Finding_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 2, 5, 7, 8, 9, 5, 13, 11, 5, 3, 15 };
            Stopwatch sw = new Stopwatch();

            // convert to list
            List<int> numbersList = numbers.ToList();

            // Find all peaks
            foreach (var item in FindPeaks(numbersList))
            {
                Console.WriteLine(item);
            }

            // Print all peaks
            Console.WriteLine($"\n Count of peaks: {FindPeaks(numbersList).Count}" );
            Console.WriteLine("\n It took " + sw.Elapsed + " to find the peaks in " + numbersList.Count + " numbers.");

            // Function to find all peaks
            List<int> FindPeaks(List<int> numbers) 
            {
                sw.Start();
                List<int> peaks = new List<int>();

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i==0)
                    {
                        if (numbers[i] >= numbers[i + 1]) 
                        {
                            peaks.Add(numbers[i]);
                        }
                    }
                    if (i > 0 && i < (numbersList.Count - 1))
                    {
                        if (numbers[i] >= numbers[i + 1] && numbers[i] >= numbers[i - 1]) 
                        {
                            peaks.Add(numbers[i]);
                        }
                    }
                    if (i >= numbers.Count - 1) 
                    {
                        if (numbers[i] >= numbers[i - 1]) 
                        {
                            peaks.Add(numbers[i]);
                        }
                    }
                }
                sw.Stop();
                return peaks;
            }
        }
    }
}
