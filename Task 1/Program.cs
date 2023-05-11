using System;
using System.Diagnostics;
using System.Linq;

namespace Task_1
{
    class Program
    {
        static bool Isanagram(string stringA, string stringB)
        //takes two strings returns a boolean, True if they are anagrams, False if they are not
        {

            Debug.WriteLine("Running anagram check...");
            Debug.WriteLine("stringA: " + stringA);
            Debug.WriteLine("stringB: " + stringB);

            //converts the strings to lowercase, removes anything that isn't a letter, orders alphabetically

            Debug.WriteLine("Sorting anagram...");

            var sortedstringA = new string(stringA.ToLower().Where(Char.IsLetter).OrderBy(c => c).ToArray());
            var sortedstringB = new string(stringB.ToLower().Where(Char.IsLetter).OrderBy(c => c).ToArray());

            Debug.WriteLine("sortedstringA: " + sortedstringA);
            Debug.WriteLine("sortedstringB: " + sortedstringB);

            /*checks if the strings match, returns True/False appropriately*/

            Debug.WriteLine("Anagram? " + sortedstringA.Equals(sortedstringB));

            return sortedstringA.Equals(sortedstringB);
        }
        static void Main()
        {
            //Example for return true if the strings are anagrams
            Isanagram("New York Times", "Monkeys Write");
            //Example for return false if the strings are anagrams
            Isanagram("New York Times", "Spoons");
        }
    }
}
