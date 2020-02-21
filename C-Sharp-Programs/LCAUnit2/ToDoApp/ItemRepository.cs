using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoApp
{
    class ItemRepository
    {
        public static ItemContext context = new ItemContext(); //instantiate instance of context

        public ItemRepository()
        {
            context.Database.EnsureCreated(); //create db file if does not exist
        }

        public static (List<ToDoItem>, int) GetList(string status) //create list and find longest Description - return list and int
        {
            IEnumerable<ToDoItem> itemList; //create list
            if (status != null) //filter status 
            {
                 itemList = context.ToDoItems.Where(x => x.Status == status); //if status is not null return filtered list
            }
            else
            {
                itemList = context.ToDoItems; //if status is null return all items
            }
            int longestString = 0;
            foreach (var item in itemList) // find the longest description string
            {
                if (item.Description.Length > longestString) //if description length is greater than longestString add length
                {
                    longestString = item.Description.Length;
                }
            }
            return (itemList.ToList(), longestString); //return list and int
        }
        public static string AddItem(string item) // add new item
        {
            string result;
            if (item != null) // if item is not null add
            {
                ToDoItem todoItem = new ToDoItem(item); //create new instance of ToDoItem class
                context.Add(todoItem); //adds to db
                context.SaveChanges(); //commits changes
                result = "Item Added!"; //message
            }
            else
            {
                result = "Item not Added!"; //message
            }

            return result; // return message
        }
        public static string DeleteItem(int item) // removes item from db
        {
            string result;
            ToDoItem deleteItem = context.ToDoItems.Where(x => x.Id == item).FirstOrDefault(); //find selected item by id
            if (deleteItem != null) // if found
            { 
                context.Remove(deleteItem); //remove item
                context.SaveChanges(); //commit changes
                result = "Item Deleted!"; //message
            }
            else
            {
                result = "Item not found!"; //message
            }

            return result; //return message
        }
        public static string ChangeStatus(int item) //change status
        {
            string result;
            ToDoItem statusItem = context.ToDoItems.Where(x => x.Id == item).FirstOrDefault(); //find selected item by id
            if (statusItem != null) //if found
            {
                statusItem.Status = statusItem.Status == "Pending" ? "Finished" : "Pending"; //change status if pending then finished or finished then pending
                context.Update(statusItem); //change status
                context.SaveChanges(); // commit changes
                result = "Item Status Changed!"; //message
            }
            else
            {
                result = "Item not found!"; //message
            }

            return result; //return message
        }
    }
}
