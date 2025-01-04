using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    public class Smartfon : Produkt
    {
        public double PrzekatnaEkranu { get; set; } // Rozmiar ekranu w calach
        public string Aparat { get; set; } // Opis aparatu
        public int PojemnoscBaterii { get; set; } // Pojemność baterii w mAh
        public string Procesor { get; set; }

        public Smartfon( string nazwa, double cena, string opis, double przekatnaEkranu, string aparat, int pojemnoscBaterii, string procesor)
            : base( nazwa, cena, opis)
        {
            PrzekatnaEkranu = przekatnaEkranu;
            Aparat = aparat;
            PojemnoscBaterii = pojemnoscBaterii;
            Procesor = procesor;
        }
        public Smartfon() { }
        // Implementacja metody abstrakcyjnej
        public override void WyswietlSzczegoly()
        {
            Console.WriteLine($"Smartfon {Nazwa} - Cena: {Cena:c}");
            Console.WriteLine($"Opis: {Opis}");
            Console.WriteLine($"Przekątna ekranu: {PrzekatnaEkranu} cala, Aparat: {Aparat}, Bateria: {PojemnoscBaterii} mAh, Procesor: {Procesor}");
        }
    }
}
