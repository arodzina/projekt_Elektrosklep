using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    public class InvalidPaymentException : Exception
    {
        // Konstruktor bez argumentów
        public InvalidPaymentException()
            : base("Płatność nie została zrealizowana z powodu błędu.")
        {
        }

        // Konstruktor z komunikatem
        public InvalidPaymentException(string message)
            : base(message)
        {
        }

        // Konstruktor z komunikatem i wyjątkiem wewnętrznym
        public InvalidPaymentException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
