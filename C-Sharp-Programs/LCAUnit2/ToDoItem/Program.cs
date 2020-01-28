using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoItem
{
    class Program
    {
        static List<ToDoItem> ToDoItemList = new List<ToDoItem>(); // create list
        static void Main(string[] args)
        {
            Console.Title = "To Do List";
            Console.ForegroundColor = ConsoleColor.White;
            AddItem(); // call add
        }
        static void AddItem()
        {
            string itemDescription, itemDueDate, itemPriority;
            int itemDisplayOrder;
            do
            {
                Console.WriteLine("Would like to Enter a Item? Yes/No");
                string addItem = Console.ReadLine().ToLower();
                if (addItem == "y" || addItem == "yes") //check for yes
                {
                    do //input check
                    {
                        Console.WriteLine("Enter Description");
                        itemDescription = Console.ReadLine().Trim();//remove white space
                        if (itemDescription.Length > 0) //check to make sure something was entered
                        {
                            break;
                        }
                        else //error
                        {
                            ChangeColor();
                            Console.WriteLine("You didn't enter anything!\nTry again");
                            ChangeColor();
                        }
                    } while (true);
                    do //input check
                    {
                        DateTime dateValue;
                        Console.WriteLine("Enter Due Date");
                        itemDueDate = Console.ReadLine().Trim();//remove white space
                        if (DateTime.TryParse(itemDueDate, out dateValue)) //check for date
                        {
                            itemDueDate = dateValue.ToString("MM/dd/yyyy"); //convert to date
                            break;
                        }
                        else //error
                        {
                            ChangeColor();
                            Console.WriteLine("You did not enter a date!\nTry MM/dd/yyyy\n");
                            ChangeColor();
                        }
                    } while (true);
                    do //input check
                    {
                        Console.WriteLine("Enter Priority: High, Normal, or Low");
                        itemPriority = Console.ReadLine().ToLower().Trim(); //remove white space
                        if (itemPriority == "h" || itemPriority == "high") 
                        {
                            itemPriority = "High"; 
                            itemDisplayOrder = 1; //for sorting
                            break;
                        }
                        else if (itemPriority == "n" || itemPriority == "normal")
                        {
                            itemPriority = "Normal";
                            itemDisplayOrder = 2;
                            break;
                        }
                        else if (itemPriority == "l" || itemPriority == "low")
                        {
                            itemPriority = "Low";
                            itemDisplayOrder = 3;
                            break;
                        }
                        else //error
                        {
                            ChangeColor();
                            Console.WriteLine("You did not enter a Priority");
                            ChangeColor();
                        }
                    } while (true);
                    ToDoItemList.Add(new ToDoItem(itemDescription, itemDueDate, itemPriority, itemDisplayOrder)); //add to list
                    Console.Clear();
                }
                else // no
                {
                    if (ToDoItemList.Count == 0) //list is empty error
                    {
                        ChangeColor();
                        Console.WriteLine("You did not enter anything!");
                        Console.WriteLine("Good Bye");
                        ChangeColor();
                        Console.ReadKey();
                        break;
                        
                    }
                    else
                    {
                        ShowList();
                        break;
                    }

                }
            } while (true);
        }
        public static void ShowList()
        {
            Console.Clear();
            //----------------Make header
            for (int i = 0; i < 11; i++)
            {
                Console.Write("  ");
            }
            Console.Write(" Description");
            for (int i = 0; i < 11; i++)
            {
                Console.Write("  ");
            }
            Console.Write("|  Due Date  | Priority \n");

            for (int i = 0; i < 56; i++)
            {
                Console.Write("_");
            }
            Console.Write("|");
            for (int i = 0; i < 12; i++)
            {
                Console.Write("_");
            }
            Console.Write("|");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("_");
            }
            Console.Write("\n");
            //-------------End Header
            foreach (var item in ToDoItemList.OrderBy(x => x.displayOrder)) //sort h, n ,and l
            {
                if (item.description.Length <= 56) //if input is < 56
                {
                    int currentLength = 56 - item.description.Length; //get string len
                    Console.Write($"{item.description}");
                    for (int i = 0; i < currentLength; i++)//fill with white space up to 56
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine($"| {item.dueDate} | {item.priority}");
                }
                else //string longer than 56
                {
                    int count = 0;
                    string test = item.description;
                    var result = test.Select((x, i) => i) //break string into lengths of 53 
                                  .Where(i => i % 53 == 0)
                                  .Select(i => test.Substring(i, test.Length - i >= 53 ? 53: test.Length - i));
                    foreach (var item01 in result) //loop though result
                    {
                        if (count == 0) //add first line with 3dots then add date and priorty
                        {
                            Console.WriteLine($"{item01}...| {item.dueDate} | {item.priority}");
                            count++;
                        } else if (item01.Length == 53) //check if full line and add 3 dots
                        {
                            Console.WriteLine($"{item01}...|            |");
                        }
                        else //add white space if needed
                        {
                            int currentLength = 56 - item01.Length;
                            Console.Write(item01);
                            for (int i = 0; i < currentLength; i++)
                            {
                                Console.Write(" ");
                            }
                            Console.WriteLine("|            |");
                        } 
                    }
                }
            }
            Console.ReadKey(); //wait on user
        }
        public class ToDoItem // add data
        {
            public string description;
            public string dueDate;
            public string priority;
            public int displayOrder;

            public ToDoItem(string itemDescription, string itemDueDate, string itemPriority, int itemDisplayOrder)
            {
                description = itemDescription;
                dueDate = itemDueDate;
                priority = itemPriority;
                displayOrder = itemDisplayOrder;
            }
        }
        static void ChangeColor()
        {
            if (Console.ForegroundColor == ConsoleColor.White)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
