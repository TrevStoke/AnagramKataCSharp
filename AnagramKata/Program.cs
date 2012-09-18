using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnagramKata
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            if ((args.Length >= 1))
            {
                input = args[0];
            }
            else
            {
                Console.Write("Enter a word: ");
                input = Console.ReadLine().Trim();
            }
            
            string inputSorted = sortCharacters(input);
            StringBuilder results = new StringBuilder(input);

            using (StreamReader r = new StreamReader("wordlist.txt"))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string lineSorted = sortCharacters(line.Trim());
                    if(inputSorted.Equals(lineSorted) &&
                        !input.Equals(line.Trim())){
                        results.Append(" ");
                        results.Append(line.Trim());
                    }
                }
                Console.Write(results.ToString());
            }
        }

        static string sortCharacters(string subject)
        {
            char[] chars = subject.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
