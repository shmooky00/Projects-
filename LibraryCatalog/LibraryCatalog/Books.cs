using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public string Year { get; set; }

    // needed to hold the information for the books

    public Book(string title, string author, string year, string isbn)
    {
        Title = title;

        Author = author;

        Year = year;

        ISBN = isbn;
        
    }
}
