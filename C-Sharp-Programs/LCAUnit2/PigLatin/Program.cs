using System;
using System.Collections.Generic;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            PigLatinCode(); // call method 
            Console.Read(); //wait for key press
        }

        public static void PigLatinCode()
        {
            Console.WriteLine("Enter a word or phrase"); //ask for input
            string userInput = Console.ReadLine(); //get user input
            var x = 0; //make new var with value of 0
            while (x == 0) // run loop while x is equal to zero
            {
                if (userInput.Length == 0) // check to see if user enter something
                {
                    Console.WriteLine("Enter a word or phrase"); //ask for input
                    userInput = Console.ReadLine(); //get user input
                }
                else
                {
                    x++; //if use enter something add 1 to x and stop the loop
                }
            } //exit while loop

            string output = userInput.Trim(); //remove any leading or trailing spaces
            string[] words = output.Split(' '); //array for user input split on space
            char[] vowels = new char[] { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' }; // array for vowels
            List<string> pigLatinString = new List<string>(); // list to store convertrd words
            foreach (var item in words) //loop for each word the user entered 
            {

                string itemStart = item.Substring(0, 1); //get first letter
                string itemEnd = item.Substring(item.Length - 1, 1); //get last letter
                
                if (itemStart.IndexOfAny(vowels) >=0) // check if first letter is a vowel
                {
                    if(itemEnd.IndexOfAny(vowels) >= 0) // check if last letter is a vowel
                    {
                        pigLatinString.Add(item + "yay"); // if both first and last letter is vowel add yay to end
                    }
                    else
                    {
                        pigLatinString.Add(item + "ay"); // if first is vowel last is not add ay to end
                    }
                }
                else if (item.IndexOfAny(vowels) == -1) //check for no vowels
                {
                    pigLatinString.Add(item + "ay"); //if not vowels add ay to end
                }
                else
                {
                    int itemVowelLocation = item.IndexOfAny(vowels); //find location of first vowel
                    string move01 = item.Substring(0, itemVowelLocation); // letters before first vowel
                    string move02 = item.Substring(itemVowelLocation); //get letters after first vowel

                    pigLatinString.Add(move02+move01+"ay"); //build new string 
                } //exit if statement
            } // exit while loop

            string displayString = ""; //make new empty string var
            foreach (var word in pigLatinString) // loop through all converted words
            {
                displayString += word + " "; //build string with words
            } //exit foreach loop

            Console.WriteLine(displayString); //display string to user
            
            Console.Read(); //wait for key press
        }

    }
}