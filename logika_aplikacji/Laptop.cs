using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    public class Laptop : Produkt
    {
        public string Procesor { get; set; }
        public int RAM { get; set; }
        public int Dysk { get; set; }
        public string KartaGraficzna { get; set; }

        public Laptop( string nazwa, double cena, string opis, string procesor, int ram, int dysk, string kartaGraficzna)
            : base( nazwa, cena, opis)
        {
            Procesor = procesor;
            RAM = ram;
            Dysk = dysk;
            KartaGraficzna = kartaGraficzna;
        }
        public Laptop() { }
        // Implementacja metody abstrakcyjnej
        public override void WyswietlSzczegoly()
        {
            Console.WriteLine($"Laptop {Nazwa} - Cena: {Cena:c}");
            Console.WriteLine($"Opis: {Opis}");
            Console.WriteLine($"Procesor: {Procesor}, RAM: {RAM} GB, Dysk: {Dysk} GB, Karta Graficzna: {KartaGraficzna}");
        }
    }
}

