using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Memento
{
    public List<Book> Books { get; set; }

    public Memento(List<Book> books)
    {
        Books = new List<Book>(books); // this creates a copy of the library
    }
}
