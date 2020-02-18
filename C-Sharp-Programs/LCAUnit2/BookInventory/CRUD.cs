using System;
using System.Collections.Generic;
using System.Text;
using static BookInventory.Colors;

namespace BookInventory
{
    class CRUD
    {
        bool noRun = false;
        bool error = false;
        string message = "";
        
        //new instance of the context
        BookContext context = new BookContext();
        public void Start()
        {
            //create a new db if needed
            context.Database.EnsureCreated();
            do
            {
                if (error)//if error change color to red else green
                {
                    Change(Color.Red);
                }
                else
                {
                    Change(Color.Green);
                }
                if (message != "") //if something to display
                {
                    Console.WriteLine($"\n{message}\n");
                    Change(Color.White);
                }
                WhatToDo();
            } while (!noRun);
            Console.Clear();
            Change(Color.Red);
            Console.WriteLine("Good Bye");
            Console.Read();
        }
        public void WhatToDo()
        {
            bool run = true;
            do //ask user what they want to do
            {
                Change(Color.Green);
                Console.WriteLine("What would you like to do?");
                Change(Color.Yellow);
                Console.Write("Option: ");
                Change(Color.Red);
                Console.Write("1 ");
                Change(Color.Yellow);
                Console.WriteLine("= Add a new book");
                Console.Write("Option: ");
                Change(Color.Red);
                Console.Write("2 ");
                Change(Color.Yellow);
                Console.WriteLine("= Edit a book");
                Console.Write("Option: ");
                Change(Color.Red);
                Console.Write("3 ");
                Change(Color.Yellow);
                Console.WriteLine("= Delete a book");
                Console.Write("Option: ");
                Change(Color.Red);
                Console.Write("4 ");
                Change(Color.Yellow);
                Console.WriteLine("= List books");
                Console.Write("Option: ");
                Change(Color.Red);
                Console.Write("5 ");
                Change(Color.Yellow);
                Console.WriteLine("= Exit");
                Change(Color.Green);
                Console.Write("Option: ");
                Change(Color.Red);
                string userInput = Console.ReadLine().Trim();
                Change(Color.White);
                int userNum;
                if (int.TryParse(userInput, out userNum))//test user input
                {
                    switch (userNum) //findout what user wants to do
                    {
                        case 1:
                            AddBook();
                            run = false;
                            break;
                        case 2:
                            EditBook();
                            run = false;
                            break;
                        case 3:
                            DeleteBook();
                            run = false;
                            break;
                        case 4:
                            ListBooks();
                            run = false;
                            break;
                        case 5:
                            noRun = true;
                            run = false;
                            break;
                    }
                }
            } while (run);
            
        }
        void AddBook()
        {
            Console.Clear();
            message = ""; //clear error
            Console.Write("Title: ");
            string userTitle = Console.ReadLine().Trim();
            Console.Write("Author: ");
            string userAuthor = Console.ReadLine().Trim();

            //Create book
            Book newBook = new Book(userTitle, userAuthor); //create new book

            //Add Book
            context.Books.Add(newBook); //add book

            //save
            context.SaveChanges(); //commit changes

            //Message
            error = false; //no error
            message = "Successfully added Book!"; //user feedback
            Console.Clear();
        }
        void EditBook()
        {
            Console.Clear();
            message = ""; //clear message
            ListBooks();
            Console.WriteLine("Please select the ID you want to edit");
            string userEdit = Console.ReadLine().Trim();
            int userNum;
            if (int.TryParse(userEdit, out userNum)) //test user input for int
            {
                Book bookToEdit = context.Books.Find(userNum); //find book to edit
                if (bookToEdit != null)
                {
                    Console.Write("Title: ");
                    string userTitle = Console.ReadLine().Trim();
                    Console.Write("Author: ");
                    string userAuthor = Console.ReadLine().Trim();
                    
                    bookToEdit.Title = userTitle != "" ? userTitle : bookToEdit.Title; //if nothing was entered use existing value

                    bookToEdit.Author = userAuthor != "" ? userAuthor : bookToEdit.Author; //if nothing was entered use existing value

                    context.SaveChanges(); //commit changes

                    error = false; // no error
                    message = "Successfully Edit!"; //feedback
                }
                else
                {
                    error = true; //error
                    message = "Book not found!";//feedback
                }
            }
            else
            {
                error = true; //error
                message = "Book not found!"; //feedback
            }
            Console.Clear();
        }
        void DeleteBook()
        {
            Console.Clear();
            message = ""; //clear message
            ListBooks();
            Console.Write("Book ID to Delete: ");
            string userDelete = Console.ReadLine().Trim();
            int userNum;
            if (int.TryParse(userDelete, out userNum)) //test for int
            {
                Book bookToDelete = context.Books.Find(userNum); // get book
                if (bookToDelete != null)
                {
                    context.Books.Remove(bookToDelete); //remove
                    context.SaveChanges(); //commit change
                    error = false; //no error
                    message = "Successfully Deleted Book!"; //feedback
                }
                else
                {
                    error = true; //error
                    message = "Book not found!"; //feedbackl
                }
            }
            else
            {
                error = true; //error
                message = "Book not found!"; //feedback
            }
            Console.Clear();

        }
        void ListBooks()
        {
            int count = 0;
            message = ""; //clear message
            error = false; //no error
            Console.Clear();
            Change(Color.Green);
            Console.WriteLine("Books");
            foreach (var item in context.Books)
            {
                Change(Color.Yellow);
                Console.Write("ID: ");
                Change(Color.Red);
                Console.Write($"{item.Id}");
                Change(Color.White);
                Console.Write(" | ");
                Change(Color.Yellow);
                Console.Write("Title: ");
                Change(Color.White);
                Console.Write($"{item.Title} | ");
                Change(Color.Yellow);
                Console.Write("Author: ");
                Change(Color.White);
                Console.WriteLine($"{item.Author}");
                count += 1;
            }
            if (count == 0)//No books in database
            {
                error = true;
                message = "No Books Found!";
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
