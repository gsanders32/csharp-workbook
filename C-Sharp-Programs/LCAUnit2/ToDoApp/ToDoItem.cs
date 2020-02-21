using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    class ToDoItem
    {
        //Properties
        public int Id { get; private set; } 
        public string Description { get; set; }
        public string Status { get; set; }

        public ToDoItem() //empty constructor
        {

        }
        public ToDoItem(string Description) //constructor
        {
            this.Description = Description; // set description
            Status = "Pending"; //set status
        }
    }
}
