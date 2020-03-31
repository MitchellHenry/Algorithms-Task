using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;
            List<int> UnsortedNumbers = new List<int>();
         var st = File.ReadAllLines("unsorted_numbers.csv");
            while (count < st.Length)
            {
                UnsortedNumbers.Add(int.Parse(st[count]));
                count++;
            }
            Console.WriteLine("Insertion or Shell sort? Or Neither?");
            string r = Console.ReadLine();
            if (r == "Insertion")
            {
                for (int i = 1; i < UnsortedNumbers.Count - 1; i++)
                {
                    for (int j = i + 1; j > 0; j--)
                    {
                        if (UnsortedNumbers[j - 1] > UnsortedNumbers[j])
                        {
                            int temp = UnsortedNumbers[j - 1];
                            UnsortedNumbers[j - 1] = UnsortedNumbers[j];
                            UnsortedNumbers[j] = temp;
                        }
                    }
                }
            }
            if (r == "Shell")
            {
                int i, j, inc, temp;
                inc = 3;
                while (inc > 0)
                {
                    for (i = 0; i < UnsortedNumbers.Count; i++)
                    {
                        j = i;
                        temp = UnsortedNumbers[i];
                        while ((j >= inc) && (UnsortedNumbers[j - inc] > temp))
                        {
                            UnsortedNumbers[j] = UnsortedNumbers[j - inc];
                            j = j - inc;
                        }
                        UnsortedNumbers[j] = temp;
                    }
                    if (inc / 2 != 0)
                        inc = inc / 2;
                    else if (inc == 1)
                        inc = 0;
                    else
                        inc = 1;
                }
            }
            Console.WriteLine("What number do you what to search for?");
            int NumToSearchFor = int.Parse(Console.ReadLine());
            Console.WriteLine("Linear or Binary Search?");
               r = Console.ReadLine();
            if(r == "Linear")
            {
                int LoopCount = 0;
                 int i = 0;
                while(i < UnsortedNumbers.Count - 1)
                {
                    if(UnsortedNumbers[i] == NumToSearchFor)
                    {
                        LoopCount++;
                        Console.WriteLine(UnsortedNumbers[i] + " is at Postion:" + i);
                        Console.WriteLine("Num Searched for: " + UnsortedNumbers[i]);
                        Console.WriteLine("Num of Loops: " + LoopCount);
                        i = UnsortedNumbers.Count - 1;                 
                    }
                    else
                    {
                        LoopCount++;
                        i++;
                    }
                } 
            }
            if(r == "Binary")
            {
                int min = 0;
                int LoopCount = 0;
                int max = UnsortedNumbers.Count - 1;
                while (min <= max)
                {
                    int mid = (min + max) / 2;
                    if (NumToSearchFor == UnsortedNumbers[mid])
                    {
                        LoopCount++;
                        Console.WriteLine("Found at Postion:" + mid);
                        Console.WriteLine("Number searched for: " + UnsortedNumbers[mid]);
                        Console.WriteLine("Num of Loops: " + LoopCount);
                        min = max + 1;
                    }
                    else if (NumToSearchFor < UnsortedNumbers[mid])
                    {
                        LoopCount++;
                        max = mid - 1;
                    }
                    else
                    {
                        LoopCount++;
                        min = mid + 1;
                    }
                }
            } 
            Console.ReadKey(true);

        }
    }
}
