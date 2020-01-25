using System;
using System.Linq;

namespace LongestWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "  This is for your own personal journey. May you have excellent navigation as a developer using your own compass.  ";
            //string userInput = Console.ReadLine();

            string wordsNoPun = new string(userInput.Where(c => !char.IsPunctuation(c)).ToArray()); //Remove Punctuation

            string wordsTrim = wordsNoPun.Trim(); // Rmove leading and trailing spaces

            string[] words = wordsTrim.Split(' '); // Split words on space and add to array

            int wordLen = 0;
            string longestWord = "";
            foreach (string test in words)//loop through each item in the array words
            {
                if (test.Length > wordLen) //check if len of word is greater than the var wordlen
                {
                    wordLen = test.Length; //add new length to var wordLen
                    longestWord = test; // add the new longest word to var longestWord
                }

            }
            Console.WriteLine($"The longest word is {longestWord}: with {wordLen} chars"); //display longest word and char count
            Console.ReadKey();
        }
    }
}
