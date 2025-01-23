using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Configuration;
using System.Data.SqlClient;

namespace Elektrosklep
{

   
    public class Magazyn
    {
        // Właściwości
        public virtual List<Produkt> produkty { get; set; }// Lista produktów w magazynie


        // Konstruktory
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


        // Metoda do pobierania produktów według kategorii
        public List<Produkt> PobierzProduktyZKategorii(string kategoria)
        {
            // Filtruje produkty według kategorii
            return produkty.Where(p => p.GetType().Name == kategoria).ToList();
        }


        // Metoda zapisująca magazyn do pliku XML
        public void ZapiszDoXml(string sciezka)
        {
            try
            {
                // Używamy XmlSerializer do serializacji listy produktów
               
                using StreamWriter sw = new(sciezka);
                XmlSerializer xs = new(typeof(Magazyn),new Type[] {typeof(Laptop),typeof(Smartfon),typeof(Tablet)});
                xs.Serialize(sw,this);
                Console.WriteLine("Magazyn został zapisany do pliku XML.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zapisu do pliku XML: {ex.Message}");
            }
        }


        // Wczytaj magazyn z pliku XML
        public static Magazyn? OdczytXml(string sciezka)
        {
            try
            {
                XmlSerializer xs = new(typeof(Magazyn), new Type[] { typeof(Laptop), typeof(Smartfon), typeof(Tablet) });

                using (FileStream fs = new FileStream(sciezka,FileMode.Open))
                {
                    Magazyn magazynOdczytany=(Magazyn)xs.Deserialize(fs);
                    return magazynOdczytany;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas wczytywania z pliku XML: {ex.Message}");
                return null;
            }
        }


        // Metoda zapisująca produkty do bazy danych
        public void ZapiszDoBazy()

        {
            // Wczytanie łańcucha połączenia z App.config 
            string connectionString = ConfigurationManager.ConnectionStrings["ElektrosklepDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var context = new MagazynContext())
                {
                    // Dodajemy wszystkie produkty do bazy danych
                    context.Produkty.AddRange(produkty);
                    context.SaveChanges(); // Zapisujemy zmiany do bazy

                    Console.WriteLine("Produkty zostały zapisane do bazy danych.");
                }
                Console.WriteLine("Połączenie z bazą danych zostało nawiązane.");
            }
           
        }

    }

    // Klasa do zapisu do bazy danych
    public class MagazynContext : DbContext
    {
        public DbSet<Produkt> Produkty { get; set; }

        public MagazynContext() : base("name=ElektrosklepDB") { }
    }


}
