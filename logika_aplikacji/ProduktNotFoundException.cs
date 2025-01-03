using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    // Klasa wyjątków dla nieznalezionego produktu
    public class ProduktNotFoundException : Exception
    {
        // Konstruktor bez argumentów
        public ProduktNotFoundException()
            : base("Produkt nie został znaleziony w magazynie.")
        {
        }

        // Konstruktor z komunikatem
        public ProduktNotFoundException(string message)
            : base(message)
        {
        }

        // Konstruktor z komunikatem i wyjątkiem wewnętrznym
        public ProduktNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
