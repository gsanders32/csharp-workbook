using System;

namespace ManyMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            hello();
            addition();
            catDog();
            oddEvent();
            inches();
            echo();
            killGrams();
            date();
            age();
            guess();
            //keep console open
            Console.Read(); //keep window until key press
        }

        static void hello()
        {
            Console.WriteLine("Hello Whats your Name?"); //Greeting ask question
            string userName = Console.ReadLine(); //get user name
            Console.WriteLine("Hello " + userName); // display user's name
        }

        static void addition()
        {
            Console.WriteLine("Let's add a couple of numbers!"); //let user what we are doing
            Console.WriteLine("Enter the first number"); //ask for first num
            string num01 = Console.ReadLine(); // get your input
            int x = 0;
            while (x == 0)
            {
                try
                {
                    Convert.ToDouble(num01);
                    x++;
                }
                catch
                {
                    Console.WriteLine("You did not enter a number. Please try again");
                    Console.WriteLine("Enter the first number"); //ask for first num
                    num01 = Console.ReadLine(); // get your input
                }
            }
            Console.WriteLine("Enter the second number");
            string num02 = Console.ReadLine();
            x = 0;
            while (x == 0)
            {
                try
                {
                    Convert.ToDouble(num02);
                    x++;
                }
                catch
                {
                    Console.WriteLine("You did not enter a number. Please try again");
                    Console.WriteLine("Enter the second number"); //ask for first num
                    num02 = Console.ReadLine(); // get your input
                }
            }
            double sum = Convert.ToDouble(num01) + Convert.ToDouble(num02);
            Console.WriteLine("The sum is: " + sum.ToString());
        }

        static void catDog()
        {
            Console.WriteLine("Do you prefer Dogs or Cats"); //ask question
            string animal = Console.ReadLine(); //get input
            animal.ToLower(); //make string lower case
            if (animal == "d" || animal == "dog" || animal == "dogs") // check input for dog
            {
                Console.WriteLine("Barks"); // if input is dog display this
            }
            else if (animal == "c" || animal == "cat" || animal == "cats") //check input for cat
            {
                Console.WriteLine("Meows"); //if input is cat display this
            }
            else
            {
                Console.WriteLine("You did not enter a Dog or Cat"); // display if not dog or cat
            }
        }

        static void oddEvent()
        {
            Console.WriteLine("I can tell you if a number is odd or even");
            Console.WriteLine("Enter a number");
            string numEvenOdd = Console.ReadLine(); // get your input
            int x = 0;
            while (x == 0)
            {
                try
                {
                    Convert.ToDouble(numEvenOdd);
                    x++;
                }
                catch
                {
                    Console.WriteLine("You did not enter a number. Please try again");
                    Console.WriteLine("Enter a number"); //ask for first num
                    numEvenOdd = Console.ReadLine(); // get your input
                }
            }
            double evenOrOdd = Convert.ToDouble(numEvenOdd) % 2;
            if (evenOrOdd != 0)
            {
                Console.WriteLine("Number: " + numEvenOdd + " is: Odd");
            }
            else
            {
                Console.WriteLine("Number: " + numEvenOdd + " is: Even");
            }
        }

        static void inches()
        {
            Console.WriteLine("How tall are you in feet");
            string numFeetInput = Console.ReadLine(); // get input
            int x = 0;
            while (x == 0)
            {
                try
                {
                    Convert.ToDouble(numFeetInput);
                    x++;
                }
                catch
                {
                    Console.WriteLine("You did not enter a number. Please try again");
                    Console.WriteLine("Enter a number"); //ask for first num
                    numFeetInput = Console.ReadLine(); // get your input
                }
            }

            string[] nums = numFeetInput.Split('.');

            int numOnlyInches = 0;
            if (nums.Length > 1)
            {
                numOnlyInches = Convert.ToInt32(nums[1]);
            }

            Console.WriteLine("You are " + ((Convert.ToInt32(nums[0]) * 12) + numOnlyInches) + " inches tall");
        }

        static void echo()
        {
            Console.WriteLine("Enter a word");
            string userInputWord = Console.ReadLine();
            Console.WriteLine(userInputWord.ToUpper());
            int i = 0;
            while (i <= 1)
            {
                Console.WriteLine(userInputWord.ToLower());
                i++;
            }
        }

        static void killGrams()
        {
            Console.WriteLine("Enter your weight in pounds");
            string numLBSInput = Console.ReadLine(); // get input
            int x = 0;
            while (x == 0)
            {
                try
                {
                    Convert.ToDouble(numLBSInput);
                    x++;
                }
                catch
                {
                    Console.WriteLine("You did not enter a number. Please try again");
                    Console.WriteLine("Enter a number"); //ask for first num
                    numLBSInput = Console.ReadLine(); // get your input
                }
            }

            string[] nums = numLBSInput.Split('.');

            double numOnlyOunces = 0;
            if (nums.Length > 1)
            {
                numOnlyOunces = Convert.ToDouble(nums[1]) * 0.0283495;
            }

            Console.WriteLine(numLBSInput + " Pounds equals " + Math.Round(((Convert.ToDouble(nums[0]) * 0.453592) + numOnlyOunces), 2) + " Kilogram(s)");
        }

        static void date()
        {
            Console.WriteLine("The Date and Time is: " + DateTime.Now); //date with time
            Console.WriteLine("The Date is: " + DateTime.Now.ToString("dd/MM/yyyy")); //date only
        }

        static void age()
        {
            Console.WriteLine("What year where you born?");
            string userInputYearBorn = Console.ReadLine();
            int x = 0;
            while (x == 0)
            {
                if (userInputYearBorn.Length == 4)
                {
                    try
                    {
                        Convert.ToInt32(userInputYearBorn);
                        x++;
                    }
                    catch
                    {
                        Console.WriteLine("You did not enter a 4 digit Year");
                        Console.WriteLine("What year where you born?"); //ask for year
                        userInputYearBorn = Console.ReadLine(); // get your input
                    }
                }
                else
                {
                    Console.WriteLine("You did not enter a 4 digit Year");
                    Console.WriteLine("What year where you born?"); //ask for year
                    userInputYearBorn = Console.ReadLine(); // get your input
                }
            }

            int currentYear = DateTime.Now.Year;

            int userAge = currentYear - Convert.ToInt32(userInputYearBorn);

            if (userAge == 0)
            {
                userAge = 1;
            }

            Console.WriteLine("You are " + userAge + " year(s) old");
        }

        static void guess()
        {
            Console.WriteLine("Can you guess the secret word? Enter a guess");
            string userguess = Console.ReadLine();
            userguess = userguess.ToLower();
            int x = 0;
            int i = 4;
            while (x != 5)
            {
                if (userguess == "csharp")
                {
                    Console.WriteLine("CORRECT");
                    x = 5;
                }
                else if (i > 0)
                {
                    Console.WriteLine("WRONG!!");
                    Console.WriteLine("You have " + i + " More Guesses! Try again!");
                    userguess = Console.ReadLine();
                    i--;
                    x++;
                }
                else
                {
                    Console.WriteLine("Sorry the secret word was - csharp");
                    x++;
                }
            }
        }
    }
}
