using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lib = new Library();

            Caretaker caretaker = new Caretaker(lib); // i found this as an easier method of saving states, specifically for the undo and redo

            Console.WriteLine("-----------------Phase 1---------------------");

            Console.WriteLine("\nScenario 1.1");
            var book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "1995", "1111");
            lib.AddBook(book1);

            caretaker.Save();

            Console.WriteLine("Scenario 1.2");
            var book2 = new Book("Jane Eyre", "Charlotte Brontë", "1847", "2222");
            lib.AddBook(book2);
            
            caretaker.Save();

            Console.WriteLine("Scenario 1.3");
            List<Book> batchBooks = new List<Book> // made a list to add two books at once
            {
                new Book("To Kill a Mockingbird", "Harper Lee", "1960", "3333"),

                new Book("The Jungle", "Upton Sinclair", "1906", "4444")
            };

            lib.AddBooks(batchBooks);

            caretaker.Save();

            Console.WriteLine("Scenario 1.4");
            lib.PrintBooks();

            Console.WriteLine("\nScenario 1.5");
            Console.WriteLine($"{lib.Books.Count} \n");
            

            Console.WriteLine("Scenario 1.6");
            lib.RemoveByISBN("1111");

            Console.WriteLine("Scenario 1.7");
            lib.RemoveByISBN("1114");

            ///////// scenario 2
            Console.WriteLine("-----------------Phase 2---------------------");

            Console.WriteLine("\nScenario 2.1");
            lib.GetBooksBy("T");

            Console.WriteLine("\nScenario 2.2");
            caretaker.Undo(book1);

            Console.WriteLine("\nScenario 2.3");
            lib.GetBooksBy("The");

            Console.WriteLine("\nScenario 2.4");
            caretaker.Redo(book1);

            Console.WriteLine("\nScenario 2.5");
            Console.WriteLine($"{lib.Books.Count} \n");

            Console.WriteLine("Scenario 2.6");
            lib.GetBooksBy(""); // this sorts the books by alphabetical order. all you have to do is leave it blank.
                                // if you wish to sort it any other way, write the string within ("")
                                // this is also acting as my ListBooksBy method so hopefully that is alright 

        }
      

    }
}
