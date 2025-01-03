using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    public class Magazyn
    {
        private List<Produkt> produkty; // Lista produktów w magazynie

        public Magazyn()
        {
            produkty = new List<Produkt>(); // Inicjalizacja listy produktów
        }

        // Dodaj produkt do magazynu
        public void DodajProdukt(Produkt produkt, int ilosc)
        {
            if (ilosc <= 0)
            {
                Console.WriteLine("Ilość musi być większa niż 0.");
                return;
            }

            var istniejącyProdukt = produkty.FirstOrDefault(p => p.Id == produkt.Id);
            if (istniejącyProdukt != null)
            {
                // Jeśli produkt już istnieje w magazynie, zaktualizuj jego ilość
                produkty.Remove(istniejącyProdukt); // Usuwamy istniejący produkt
                produkty.Add(produkt); // Dodajemy go ponownie z aktualizowaną ilością
                Console.WriteLine($"Zaktualizowano produkt: {produkt.Nazwa}.");
            }
            else
            {
                // Jeśli produkt nie istnieje, dodajemy go do magazynu
                produkty.Add(produkt);
                Console.WriteLine($"Dodano produkt: {produkt.Nazwa}.");
            }
        }

        // Usuń produkt z magazynu
        public void UsunProdukt(int id)
        {
            var produktDoUsuniecia = produkty.FirstOrDefault(p => p.Id == id);
            if (produktDoUsuniecia != null)
            {
                produkty.Remove(produktDoUsuniecia);
                Console.WriteLine($"Usunięto produkt: {produktDoUsuniecia.Nazwa}.");
            }
            else
            {
                Console.WriteLine("Nie znaleziono produktu w magazynie.");
            }
        }

        // Zaktualizuj ilość produktu
        public void ZaktualizujIloscProduktu(int id, int nowaIlosc)
        {
            var produkt = produkty.FirstOrDefault(p => p.Id == id);
            if (produkt != null && nowaIlosc >= 0)
            {
                // W tym przykładzie zakładamy, że produkt wciąż będzie obecny po aktualizacji ilości
                Console.WriteLine($"Zaktualizowano ilość produktu: {produkt.Nazwa} na {nowaIlosc} szt.");
            }
            else
            {
                Console.WriteLine("Produkt nie istnieje lub ilość jest nieprawidłowa.");
            }
        }

        // Sprawdź dostępność produktu w magazynie
        public void SprawdzDostepnosc(int id)
        {
            var produkt = produkty.FirstOrDefault(p => p.Id == id);
            if (produkt == null)
            {
                throw new ProduktNotFoundException($"Produkt o ID {id} nie został znaleziony w magazynie.");
            }
            else
            {
                Console.WriteLine($"Produkt {produkt.Nazwa} jest dostępny w magazynie.");
            }
        }

        // Wyświetl wszystkie produkty w magazynie
        public void WyswietlProdukty()
        {
            if (produkty.Count == 0)
            {
                Console.WriteLine("Magazyn jest pusty.");
            }
            else
            {
                Console.WriteLine("Produkty w magazynie:");
                foreach (var produkt in produkty)
                {
                    Console.WriteLine($"{produkt.Nazwa}, Cena: {produkt.Cena:c}");
                }
            }
        }
    }
}
