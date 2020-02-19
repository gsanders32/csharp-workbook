using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ToDoApp
{
    class ItemContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\DataBase\ToDoItem.db";
            //connection string
            optionsBuilder.UseSqlite($"Data Source={path}");
        }

    }
}
