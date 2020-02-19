using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    class ItemRepository
    {
        public static ItemContext context = new ItemContext();

        public ItemRepository()
        {
            //create database if does exist
            context.Database.EnsureCreated();
        }
    }
}
