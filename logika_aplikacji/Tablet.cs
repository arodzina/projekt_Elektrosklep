using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    public class Tablet : Produkt
    {
        public double Wyswietlacz { get; set; } // Rozmiar wyświetlacza w calach
        public string SystemOperacyjny { get; set; }
        public bool CzyRysik { get; set; } // Czy obsługuje rysik

        public Tablet( string nazwa, double cena, string opis, double wyswietlacz, string systemOperacyjny, bool czyRysik)
            : base( nazwa, cena, opis)
        {
            Wyswietlacz = wyswietlacz;
            SystemOperacyjny = systemOperacyjny;
            CzyRysik = czyRysik;
        }

        public Tablet() { }
        // Implementacja metody abstrakcyjnej
        public override void WyswietlSzczegoly()
        {
            Console.WriteLine($"Tablet {Nazwa} - Cena: {Cena:c}");
            Console.WriteLine($"Opis: {Opis}");
            Console.WriteLine($"Wyświetlacz: {Wyswietlacz} cala, System operacyjny: {SystemOperacyjny}, Rysik: {(CzyRysik ? "Tak" : "Nie")}");
        }
    }
}

