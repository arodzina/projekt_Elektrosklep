using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    public class Zamowienie
    {
        // Właściwości
        public int Id { get; set; } // Unikalny identyfikator zamówienia
        public Klient Klient { get; set; } // Klient, który złożył zamówienie
        public List<Produkt> Produkty { get; set; } // Produkty w zamówieniu
        public string Status { get; set; } // Status zamówienia 
        public DateTime DataZamowienia { get; set; } // Data złożenia zamówienia


        // Konstruktory
        public Zamowienie(int id, Klient klient)
        {
            Id = id;
            Klient = klient; // Powiązanie zamówienia z klientem
            Produkty = new List<Produkt>(); // Początkowo brak produktów
            Status = "Nowe"; // Domyślnie zamówienie jest nowe
            DataZamowienia = DateTime.Now; // Data złożenia zamówienia to obecna data
        }


        // Dodaj produkt do zamówienia
        public void DodajProdukt(Produkt produkt)
        {
            Produkty.Add(produkt);
            Console.WriteLine($"Dodano {produkt.Nazwa} do zamówienia.");
        }


        // Oblicz całkowitą cenę zamówienia (wliczając rabaty)
        public double ObliczCalkowitaCene()
        {
            double suma = 0;
            foreach (var produkt in Produkty)
            {
                suma += produkt.CenaPoRabacie(); // Zwraca cenę produktu po rabacie
            }
            return suma;
        }


        // Zaktualizuj status zamówienia
        public void ZaktualizujStatus(string nowyStatus)
        {
            Status = nowyStatus;
            Console.WriteLine($"Status zamówienia zaktualizowano na: {Status}");
        }


        // Wyświetl szczegóły zamówienia
        public void WyswietlSzczegoly()
        {
            Console.WriteLine($"Zamówienie numer {Id}");
            Console.WriteLine($"Data zamówienia: {DataZamowienia}");
            Console.WriteLine($"Status zamówienia: {Status}");
            Console.WriteLine("Produkty w zamówieniu:");

            foreach (var produkt in Produkty)
            {
                Console.WriteLine($"- {produkt.Nazwa}, Cena: {produkt.Cena:c}, Cena po rabacie: {produkt.CenaPoRabacie():c}");
            }

            Console.WriteLine($"Całkowita cena zamówienia: {ObliczCalkowitaCene():c}");
        }
    }
}
