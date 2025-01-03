using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    public class Koszyk
    {
        private List<Produkt> produkty;
        private bool rabatZastosowany; // Pole do sprawdzania, czy rabat został zastosowany

        public Koszyk()
        {
            produkty = new List<Produkt>();
            rabatZastosowany = false; // Początkowo rabat nie jest zastosowany
        }

        // Dodaj produkt do koszyka
        public void DodajProdukt(Produkt produkt)
        {
            produkty.Add(produkt);
        }

        // Zastosowanie rabatu, jeśli w koszyku są produkty z każdej kategorii
        public void ZastosujRabat()
        {
            bool maLaptopa = false, maTableta = false, maSmartfona = false;

            // Sprawdzamy, czy w koszyku są produkty z każdej kategorii
            foreach (var produkt in produkty)
            {
                if (produkt is Laptop) maLaptopa = true;
                if (produkt is Tablet) maTableta = true;
                if (produkt is Smartfon) maSmartfona = true;
            }

            // Jeśli w koszyku są produkty z każdej kategorii, przyznajemy rabat 10%
            if (maLaptopa && maTableta && maSmartfona)
            {
                foreach (var produkt in produkty)
                {
                    produkt.Rabat = 10; // Rabat 10% dla każdego produktu
                }
                rabatZastosowany = true;
                Console.WriteLine("Zastosowano rabat 10% na wszystkie produkty w koszyku!");
            }
        }

        // Oblicz całkowitą cenę po rabacie
        public double ObliczCalkowitaCene()
        {
            double suma = 0;
            foreach (var produkt in produkty)
            {
                suma += produkt.CenaPoRabacie(); // Zwraca cenę po rabacie
            }
            return suma;
        }

        // Oblicz wartość rabatu w PLN
        public double ObliczWartoscRabatu()
        {
            double sumaRabatu = 0;
            foreach (var produkt in produkty)
            {
                sumaRabatu += produkt.Cena - produkt.CenaPoRabacie(); // Wartość rabatu = cena przed rabatem - cena po rabacie
            }
            return sumaRabatu;
        }

        // Wyświetl zawartość koszyka
        public void WyswietlKoszyk()
        {
            foreach (var produkt in produkty)
            {
                Console.WriteLine(produkt.ToString()); // Wyświetla produkt
            }

            // Wyświetlamy odpowiednią etykietę w zależności od tego, czy rabat został zastosowany
            if (rabatZastosowany)
            {
                Console.WriteLine($"Całkowita cena po rabacie: {ObliczCalkowitaCene():c} (rabat: {ObliczWartoscRabatu():c})"); 
            }
            else
            {
                Console.WriteLine($"Wartość koszyka: {ObliczCalkowitaCene():c}");
            }
        }
    }
}

