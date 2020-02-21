using System;
using System.Collections.Generic;
using System.Text;
using static ToDoApp.Colors;
using static ToDoApp.ConsoleUtils;
using static ToDoApp.ItemRepository;

namespace ToDoApp
{
    class App
    {
        private ItemRepository itemRepository;
        public ConsoleUtils consoleUtils;

        public App()
        {
            itemRepository = new ItemRepository();
            consoleUtils = new ConsoleUtils();
        }
        public void Start()
        {
            bool stopRunning = false;
            do // do until user enters quit
            {
                DisplayMenu(); //display main menu
                string action = UserMenuInput(); //get user action
                switch (action) //find what user want to do
                {
                    case "addItem":
                        Add(UserAddItem()); //call method
                        break;
                    case "deleteItem":
                        DisplayItems(GetList(null).Item1, GetList(null).Item2); //call method
                        Delete(UserDeleteItem()); //call method
                        break;
                    case "listItems":
                        DisplayItems(GetList(null).Item1, GetList(null).Item2); //call method
                        break;
                    case "changeStatus":
                        DisplayItems(GetList(null).Item1, GetList(null).Item2); //call method
                        Status(UserUpdateStatus()); //call method
                        break;
                    case "finishedItems":
                        DisplayItems(GetList("Finished").Item1, GetList("Finished").Item2); //call method
                        break;
                    case "pendingItems":
                        DisplayItems(GetList("Pending").Item1, GetList("Pending").Item2); //call method
                        break;
                    case "quit":
                        stopRunning = true; //stop program
                        break;
                }
                
            } while (!stopRunning);
            DisplayQuit(); // call when user enters quit
        }

        public void Add(string item)
        {
            DisplayMessage(ItemRepository.AddItem(item)); //call add method and display returned string "Message" 
        }
        public void Delete(int item)
        {
            DisplayMessage(ItemRepository.DeleteItem(item)); //call delete method and display returned string "Message" 
        }
        public void Status(int item)
        {
            DisplayMessage(ItemRepository.ChangeStatus(item)); //call status change method and display returned string "Message" 
        }
    }
}
