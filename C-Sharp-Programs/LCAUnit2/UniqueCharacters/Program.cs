using System;
using System.Linq;

namespace UniqueCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            
            do //loop
            {
                Console.Clear();
                Console.WriteLine("Enter a word or phrase");
                string userInput = Console.ReadLine();
                string removeSpaces = userInput.Replace(" ", string.Empty);//remove all spaces
                bool test = removeSpaces.GroupBy(x => x).Any(g => g.Count() > 1); //return true if grouped char count is > than 1

                if (test) //if ture
                {
                    Console.WriteLine($"{userInput}: Contains Duplicates");
                }
                else // false
                {
                    Console.WriteLine($"{userInput}: Does not contain Duplicates");
                }
                Console.WriteLine("Test another word or phrase Y/N");
                string again = Console.ReadLine().ToLower();
                
                if(again != "y" && again !="yes") // check if user wants to enter another word
                {
                    play = false;
                }
            } while (play);
            
        
        }
    }
}
