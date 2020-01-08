using System;

namespace ManyMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello();
            Console.WriteLine("Press any key for next program"); //display text
            Console.ReadKey(); //wait for key press 
            Console.Clear(); //clear console
            Addition();
            Console.WriteLine("Press any key for next program"); //display text
            Console.ReadKey(); //wait for key press 
            Console.Clear(); //clear console
            CatDog();
            Console.WriteLine("Press any key for next program"); //display text
            Console.ReadKey(); //wait for key press 
            Console.Clear(); //clear console
            OddEvent();
            Console.WriteLine("Press any key for next program"); //display text
            Console.ReadKey(); //wait for key press 
            Console.Clear(); //clear console
            Inches();
            Console.WriteLine("Press any key for next program"); //display text
            Console.ReadKey(); //wait for key press 
            Console.Clear(); //clear console
            Echo();
            Console.WriteLine("Press any key for next program"); //display text
            Console.ReadKey(); //wait for key press 
            Console.Clear(); //clear console
            KillGrams();
            Console.WriteLine("Press any key for next program"); //display text
            Console.ReadKey(); //wait for key press 
            Console.Clear(); //clear console
            Date();
            Console.WriteLine("Press any key for next program"); //display text
            Console.ReadKey(); //wait for key press 
            Console.Clear(); //clear console
            Age();
            Console.WriteLine("Press any key for next program"); //display text
            Console.ReadKey(); //wait for key press 
            Console.Clear(); //clear console
            Guess();
            Console.WriteLine("That was the last Program"); //display text
            Console.Read(); //keep window until key press
        }

        static void Hello()
        {
            Console.WriteLine("Hello Whats your Name?"); //Greeting ask question
            string userName = Console.ReadLine(); //get user name
            Console.WriteLine("Hello " + userName); // display user's name
        }

        static void Addition()
        {
            Console.WriteLine("Let's add a couple of numbers!"); //let user what we are doing
            Console.WriteLine("Enter the first number"); //ask for first num
            string num01 = Console.ReadLine(); // get your input
            int x = 0; //create new var and set to zero
            while (x == 0) //run while x is zero
            {
                try // test
                {
                    Convert.ToDouble(num01); //check if user input is num
                    x++; //pass add one to x
                }
                catch //fail
                {
                    Console.WriteLine("You did not enter a number. Please try again"); //tell user whats wrong
                    Console.WriteLine("Enter the first number"); //ask for first num
                    num01 = Console.ReadLine(); // get your input
                }
            }
            Console.WriteLine("Enter the second number"); // ask for second num
            string num02 = Console.ReadLine(); // get user input
            x = 0; //create new var and set to zero
            while (x == 0) //run while x is zero
            {
                try //test
                {
                    Convert.ToDouble(num02); //check input for num
                    x++; //pass add one to x
                }
                catch //fail
                {
                    Console.WriteLine("You did not enter a number. Please try again"); //tell user whats wrong
                    Console.WriteLine("Enter the second number"); //ask for first num
                    num02 = Console.ReadLine(); // get your input
                }
            }
            double sum = Convert.ToDouble(num01) + Convert.ToDouble(num02); //cal the two nums
            Console.WriteLine("The sum is: " + sum.ToString()); // display sum to user
        }

        static void CatDog()
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

        static void OddEvent()
        {
            Console.WriteLine("I can tell you if a number is odd or even");// display text to user
            Console.WriteLine("Enter a number"); //ask user for input
            string numEvenOdd = Console.ReadLine(); // get your input
            int x = 0; //create new var and set to zero
            while (x == 0) //run while x is equal to zero
            {
                try //test
                {
                    Convert.ToDouble(numEvenOdd); //check user input for num only
                    x++; //pass add one to x
                }
                catch //fail
                {
                    Console.WriteLine("You did not enter a number. Please try again"); // tell user whats wrong
                    Console.WriteLine("Enter a number"); //ask for first num
                    numEvenOdd = Console.ReadLine(); // get your input
                }
            }
            double evenOrOdd = Convert.ToDouble(numEvenOdd) % 2; //get remainder
            if (evenOrOdd != 0) //if remainder is not zero 
            {
                Console.WriteLine("Number: " + numEvenOdd + " is: Odd"); //display text odd
            }
            else
            {
                Console.WriteLine("Number: " + numEvenOdd + " is: Even"); //display text even
            }
        }

        static void Inches()
        {
            Console.WriteLine("How tall are you in feet"); //ask user question
            string numFeetInput = Console.ReadLine(); // get input
            int x = 0; //create var and set to zero
            while (x == 0) //run while x is equal to zero
            {
                try //test
                {
                    Convert.ToDouble(numFeetInput); //convert user input to int
                    x++; //if pass add one to x
                }
                catch //fail
                {
                    Console.WriteLine("You did not enter a number. Please try again"); //tell user whats wrong
                    Console.WriteLine("Enter a number"); //ask for first num
                    numFeetInput = Console.ReadLine(); // get your input
                }
            }

            string[] nums = numFeetInput.Split('.'); //if user entered inches split on "." 

            int numOnlyInches = 0; // create var and set to zero
            if (nums.Length > 1) //check if user entered inches
            {
                numOnlyInches = Convert.ToInt32(nums[1]); //get inches
            }

            Console.WriteLine("You are " + ((Convert.ToInt32(nums[0]) * 12) + numOnlyInches) + " inches tall"); // cal total inches and display
        }

        static void Echo()
        {
            Console.WriteLine("Enter a word"); //ask user question
            string userInputWord = Console.ReadLine(); //get user input
            Console.WriteLine(userInputWord.ToUpper()); //convert text to upper case and display
            int i = 0; //create new var and set to zero
            while (i <= 1) //do while i is less than or equal one run two times
            {
                Console.WriteLine(userInputWord.ToLower()); //convert text to lower case and display
                i++; //add one to i
            }
        }

        static void KillGrams()
        {
            Console.WriteLine("Enter your weight in pounds"); //ask user to enter weight is LBS
            string numLBSInput = Console.ReadLine(); // get input
            int x = 0; //create new var equal to zero
            while (x == 0) //run while x is equal to zero
            {
                try //test if user entered a num
                {
                    Convert.ToDouble(numLBSInput); //convert user text to num
                    x++; // if pass add one to x and stop the loop
                }
                catch // if convert fails
                {
                    Console.WriteLine("You did not enter a number. Please try again"); //display error text
                    Console.WriteLine("Enter a number"); //ask for first num
                    numLBSInput = Console.ReadLine(); // get your input
                }
            }

            string[] nums = numLBSInput.Split('.'); //if the user enters ounces split and add to array

            double numOnlyOunces = 0; //create new var set to zero
            if (nums.Length > 1) //check to see if user entered ounces
            {
                numOnlyOunces = Convert.ToDouble(nums[1]) * 0.0283495; //cal ounces to kg
            }

            Console.WriteLine(numLBSInput + " Pounds equals " + Math.Round(((Convert.ToDouble(nums[0]) * 0.453592) + numOnlyOunces), 2) + " Kilogram(s)");// display and cal kg
        }

        static void Date()
        {
            Console.WriteLine("The Date and Time is: " + DateTime.Now); //date with time
            Console.WriteLine("The Date is: " + DateTime.Now.ToString("dd/MM/yyyy")); //date only
        }

        static void Age()
        {
            //!------------the text book ask the user to enter birth year and not full date I will make sure the user enters a four digit year-----------!\\
            Console.WriteLine("What year where you born?"); //display text to the user
            string userInputYearBorn = Console.ReadLine(); //gets user input
            int x = 0; //create new var equal to zero
            while (x == 0) //loop run while x is zero
            {
                if (userInputYearBorn.Length == 4) // check for 4 digit date 
                {
                    try //test user input
                    {
                        Convert.ToInt32(userInputYearBorn); //check to see if the user enter a number
                        x++; // adds one to x
                    }
                    catch
                    {
                        Console.WriteLine("You did not enter a 4 digit Year"); //tells the user whats wrong
                        Console.WriteLine("What year where you born?"); //ask for year
                        userInputYearBorn = Console.ReadLine(); // get your input
                    }
                }
                else
                {
                    Console.WriteLine("You did not enter a 4 digit Year"); //tells the user whats wrong
                    Console.WriteLine("What year where you born?"); //ask for year
                    userInputYearBorn = Console.ReadLine(); // get your input
                }
            }

            int currentYear = DateTime.Now.Year; //get current year from system

            int userAge = currentYear - Convert.ToInt32(userInputYearBorn); //convert user input to int and cals age

            if (userAge == 0) // because the text book ask the user for their birth year and not full date
            {
                Console.WriteLine("You are less than a year old"); //display text
            }
            else
            {
                Console.WriteLine("You are " + userAge + " year(s) old"); //display text
            }

            
        }

        static void Guess()
        {
            Console.WriteLine("Can you guess the secret word? Enter a guess"); //ask user a question
            string userguess = Console.ReadLine(); //get user input
            userguess = userguess.ToLower(); // convert to lower case
            int x = 0; //create new var equal to 0 for while loop run 5 times
            int i = 4; //create new var equal to 4 for user guesses count remaining
            while (x != 5) //loop to no more than run five times
            {
                if (userguess == "csharp") //check if user guessed the correct word
                {
                    Console.WriteLine("CORRECT"); //display correct to user
                    x = 5; // set x to 5 and stop the loop
                }
                else if (i > 0) //checks to see if the user has any guesses left
                {
                    Console.WriteLine("WRONG!!"); // display text to user
                    Console.WriteLine("You have " + i + " More Guesses! Try again!"); //tells the userr how many guesses remain ask the user to try again
                    userguess = Console.ReadLine(); //gets user input
                    i--; // removes one from the remaining guesses
                    x++; // adds one to the total loop count
                }
                else
                {
                    Console.WriteLine("Sorry the secret word was - csharp"); // if the guess count is zero then it displays the answer
                    x++; //adds one to the total loop count 
                }
            }
        }
    }
}
