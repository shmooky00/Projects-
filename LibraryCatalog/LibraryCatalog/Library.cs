using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Library
{
    public List<Book> Books = new List<Book>();  

    public void AddBook(Book book)
    {
        Books.Add(book);
        
        Console.WriteLine($"The book [{book.Title} - {book.ISBN}] was successfully added. \n" );
    }

    public void AddBooks(List<Book> books)
    {
        var addedBooks = new List<string>();

        foreach (var book in books)
        {
            Books.Add(book);

            addedBooks.Add($"[{book.Title} - {book.ISBN}]");
        }

        if (addedBooks.Count > 0)
        {
            // this was needed in order to incorporate both books onto one line and in the same operation
            Console.WriteLine($"{addedBooks.Count} books were successfully added. {string.Join(", ", addedBooks)} \n");
        }
    }

    public void RemoveBook(Book book)
    {
        if (Books.Remove(book))
        {
                       
            Console.WriteLine($"The book [{book.Title} - {book.ISBN}] was successfully removed. \n");
        }
        else
        {
            Console.WriteLine("No books in the library. \n");
        }
    }

    public void RemoveByISBN(string isbn)
    {
        Book bookToRemove = Books.FirstOrDefault(b => b.ISBN == isbn);

        if (bookToRemove != null)
        {
            RemoveBook(bookToRemove);
        }
        else
        {
            Console.WriteLine($"Book not found.\n");
        }
    }

    public Memento Save()
    {
        return new Memento(Books);
    }


    public void Restore(Memento memento)
    {
        Books = new List<Book>(memento.Books);
    }

    public void PrintBooks()
    {
        
        
        if (Books.Count == 0)
        {
            Console.WriteLine("No books in the library. \n" );
            
        }

        var bookList = string.Join(", ", Books.Select(book => book.Title));

        Console.WriteLine(bookList);
    }

       
    public void GetBooksBy(string prefix) // prefix allows me to specify what i want to sort by on my program class, so its a 3 in one for this project
    {
        
        var books = Books.ToList(); // here i converted the stack into a list to iterate

        var sortedB = new List<Book>(); 

       
        foreach (var book in books)
        {
            if (book.Title.StartsWith(prefix, StringComparison.Ordinal))
            {
                sortedB.Add(book); // this is what actually lists books by the prefix, whatever will be in the ("")
            }
        }

        if (sortedB.Count == 0)
        {
            Console.WriteLine("No matching books found.");
        }
        else
        {
            sortedB = sortedB.OrderBy(b => b.Title).ToList(); // sorts the books by alphabet when called blank

            foreach (var book in sortedB)
            {
                Console.WriteLine($"{book.Title} - {book.ISBN}"); // this displays the called books with title and isbn
            }
        }
    }

}


