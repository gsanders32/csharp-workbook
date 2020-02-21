using System;
using System.Collections.Generic;
using System.Text;
using static ToDoApp.Colors;

namespace ToDoApp
{
    class ConsoleUtils
    {
        public static void DisplayMenu()
        {
            //display user menu with different colors
            Change(Color.Blue);
            Console.WriteLine("---- To Do List ----");
            Change(Color.Red);
            Console.Write("[Add] ");
            Change(Color.Black);
            Console.WriteLine("to add item:");
            Change(Color.Red);
            Console.Write("[Delete] ");
            Change(Color.Black);
            Console.WriteLine("to delete item:");
            Change(Color.Red);
            Console.Write("[List] ");
            Change(Color.Black);
            Console.WriteLine("to display all items:");
            Change(Color.Red);
            Console.Write("[Status] ");
            Change(Color.Black);
            Console.WriteLine("to mark item finished or Pending:");
            Change(Color.Red);
            Console.Write("[Finished] ");
            Change(Color.Black);
            Console.WriteLine("to display finished items:");
            Change(Color.Red);
            Console.Write("[Pending] ");
            Change(Color.Black);
            Console.WriteLine("to display pending items:");
            Change(Color.Red);
            Console.Write("[Quit] ");
            Change(Color.Black);
            Console.WriteLine("to quit:");
        }
        public static void DisplayItems(List<ToDoItem> list, int item2)
        {
            int itemSpace = item2; //set item2 "longestString" to itemSpace
            Change(Color.Blue);
            Console.Write("ID");
            Change(Color.Black);
            Console.Write("    | ");
            Change(Color.Blue);
            Console.Write("Description");

            //dynamic space for header and rows
            int headerSpace;
            if (itemSpace < 14) //longest string is less than 14 chars
            {
                headerSpace = 2;
                itemSpace = 12;
            }
            else
            {
                headerSpace = itemSpace - 10;
            }
            for (int i = 0; i < headerSpace; i++) //pad with spaces if needed
            {
                Console.Write(" ");
            }
            Change(Color.Black);
            Console.Write("| ");
            Change(Color.Blue);
            Console.WriteLine("Status");
            Change(Color.Black);
            if (item2 > 1) //check for empty list
            {
                foreach (var item in list) //display list items
                {
                    string id = item.Id.ToString();//need this to find length for dynamic row spacing
                    Console.Write(id);
                    for (int i = id.Length; i < 6; i++) //pad with spaces if needed
                    {
                        Console.Write(" ");
                    }
                    string des = item.Description; //need this to find length for dynamic row spacing
                    Console.Write($"| {des}");
                    for (int i = des.Length-1; i < itemSpace; i++) //pad with spaces if needed
                    {
                        Console.Write(" ");
                    }
                    Console.Write("| ");
                    Change(item.Status == "Pending" ? Color.Red : Color.Green); //set colors for status
                    Console.WriteLine(item.Status);
                    Change(Color.Black);
                }
            }
            else //empty list message
            {
                Change(Color.Red);
                Console.WriteLine("No Records Found!");
                Change(Color.Black);
            }
            Console.WriteLine();
        }
        public static void DisplayMessage(string item)
        {
            Change(Color.Red); //display return message in red font color
            Console.WriteLine($"\n{item}\n");
        }
        public static void DisplayQuit()
        {
            Change(Color.Red);
            Console.WriteLine("Good Bye!");
            Change(Color.Black);
            Console.Read();//stop program auto closing
        }
        public static string UserMenuInput()
        {
            bool gooodInput = false;
            string userInput;
            string result = "";
            do // run until good input is recieved
            {
                Change(Color.Red);
                Console.Write("\nWhat would you like to do?: "); //question
                userInput = Console.ReadLine().ToLower().Trim(); //get user input trimmed and lower case
                switch (userInput) // find user selection 
                {
                    case "add":
                    case "a":
                        result = "addItem";
                        gooodInput = true;
                        break;
                    case "delete":
                    case "d":
                        result = "deleteItem";
                        gooodInput = true;
                        break;
                    case "list":
                    case "l":
                        result = "listItems";
                        gooodInput = true;
                        break;
                    case "status":
                    case "s":
                        result = "changeStatus";
                        gooodInput = true;
                        break;
                    case "finished":
                    case "f":
                        result = "finishedItems";
                        gooodInput = true;
                        break;
                    case "pending":
                    case "p":
                        result = "pendingItems";
                        gooodInput = true;
                        break;
                    case "quit":
                    case "q":
                        result = "quit";
                        gooodInput = true;                       
                        break;
                    default: //error display message
                        Change(Color.Red);
                        Console.WriteLine("\nInvaid Option!");
                        break;
                }

            } while (!gooodInput);
            Console.Clear(); //clear screen after good input
            return result; //return selected action
        }
        public static string UserAddItem()
        {
            bool vaild = false;
            string result = null;
            Change(Color.Blue);
            Console.WriteLine("Lets add an Item to the list");
            do //do while invaild input
            {
                Change(Color.Black);
                Console.Write("Description: ");
                string userInput = Console.ReadLine().Trim();
                if(userInput == "")
                {
                    Change(Color.Red);
                    Console.WriteLine("You did not enter anything!");
                }
                else
                {
                    result = userInput;
                    vaild = true;
                }
            } while (!vaild);
            return result; //return item description
        }
        public static int UserDeleteItem()
        {
            bool vaild = false;
            int result = 0;
            Change(Color.Red);
            Console.WriteLine("Delete an item from the list. Please enter the Id of the item.");
            do // do while invaild input
            {
                Change(Color.Black);
                Console.Write("ID: ");
                string userInput = Console.ReadLine().Trim();
                //bool success = int.TryParse(userInput);
                if (!int.TryParse(userInput, out result)) //test if user entered a number
                {
                    Change(Color.Red);
                    Console.WriteLine("You did not enter Number!"); //error message
                }
                else
                { 
                    vaild = true;
                }
            } while (!vaild);
            return result; //return Id
        }
        public static int UserUpdateStatus()
        {
            bool vaild = false;
            int result = 0;
            Change(Color.Red);
            Console.WriteLine("Change the status of a todo item. Please enter the Id of the item.");
            do // do while invaild input
            {
                Change(Color.Black);
                Console.Write("ID: ");
                string userInput = Console.ReadLine().Trim();
                //bool success = int.TryParse(userInput);
                if (!int.TryParse(userInput, out result))//test if user entered a number
                {
                    Change(Color.Red);
                    Console.WriteLine("You did not enter Number!"); //error message
                }
                else
                {
                    vaild = true;
                }
            } while (!vaild);
            return result; //return Id
        }
    }
}
