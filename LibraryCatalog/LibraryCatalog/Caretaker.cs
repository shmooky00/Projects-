using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Caretaker
{

    public Stack<Memento> UndoStack = new Stack<Memento>();
    public Stack<Memento> RedoStack = new Stack<Memento>();
    public Library Library;
    public List<Book> Books = new List<Book>();

    public Caretaker(Library library)
    {
        Library = library;
    }

    public void Save()
    {
        UndoStack.Push(Library.Save());

        RedoStack.Clear(); 
    }

    public void Undo(Book book) // i got it to work finally once i added Book book in the title line. 
        //when i call undo in the code you must specify which book you want to redo, so it wokrs as a redo but almost as a remove
    {
        if (UndoStack.Count > 0)
        {
            RedoStack.Push(Library.Save()); // saves current state before undo
            
            Library.Restore(UndoStack.Pop()); // this replaces the book list 

            Console.WriteLine($"Undo - Remove operation of [{book.Title} - {book.ISBN}] has been undone.");
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }

    public void Redo(Book book)
    {
        if (RedoStack.Count > 0)
        {
            UndoStack.Push(Library.Save()); 
            
            Library.Restore(RedoStack.Pop());
            
            Console.WriteLine($"Redo - Remove operation of [{book.Title} - {book.ISBN} has been redone.");
        }
        else
        {
            Console.WriteLine("Nothing to redo.");
        }
    }

    // https://stackoverflow.com/questions/1915907/best-practice-for-undo-redo-implementation-in-c-sharp
}