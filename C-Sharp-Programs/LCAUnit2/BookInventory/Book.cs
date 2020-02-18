using System;
using System.Collections.Generic;
using System.Text;

namespace BookInventory
{
    class Book
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }
    }
}
