using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        // Virtual method to override in derived classes
        public virtual string GetInfo()
        {
            return $"Title: {Title}, Author: {Author}, ISBN: {ISBN}";
        }

    }

    class EBook : Book
    {
        public double FileSize { get; set; } // in MB

        public EBook(string title, string author, string isbn, double fileSize)
            : base(title, author, isbn)
        {
            FileSize = fileSize;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", File Size: {FileSize} MB";
        }
    }


    class PrintedBook : Book
    {
        public int PageCount { get; set; }

        public PrintedBook(string title, string author, string isbn, int pageCount)
            : base(title, author, isbn)
        {
            PageCount = pageCount;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Pages: {PageCount}";
        }
    }


}
