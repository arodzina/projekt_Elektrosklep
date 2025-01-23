using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    public class Platnosc
    {
        // Właściwości
        public int Id { get; set; } // Unikalny identyfikator płatności
        public Zamowienie Zamowienie { get; set; } // Powiązane zamówienie
        public double Kwota { get; set; } // Kwota do zapłaty
        public string MetodaPlatnosci { get; set; } // Metoda płatności (np. "Karta kredytowa", "Przelew bankowy", "Płatność online")
        public string Status { get; set; } // Status płatności ("Oczekuje", "Zrealizowana", "Nieudana")
        public DateTime DataPlatnosci { get; set; } // Data płatności


        // Konstruktor
        public Platnosc(Zamowienie zamowienie, string metodaPlatnosci)
        {
            Zamowienie = zamowienie;
            Kwota = zamowienie.ObliczCalkowitaCene(); // Kwota do zapłaty to całkowita cena zamówienia
            MetodaPlatnosci = metodaPlatnosci;
            Status = "Oczekuje"; // Domyślnie status płatności to "Oczekuje"
            DataPlatnosci = DateTime.MinValue; // Brak daty przed dokonaniem płatności
        }


        // Dokonaj płatności
        public void DokonajPlatnosci()
        {
            if (Status == "Oczekuje")
            {
                // Symulacja dokonania płatności (można tu dodać logikę integracji z systemem płatności online)
                Console.WriteLine($"Płatność o wartości {Kwota} PLN za zamówienie o numerze {Zamowienie.Id} została pomyślnie zrealizowana.");
                Status = "Zrealizowana";
                DataPlatnosci = DateTime.Now; // Ustawiamy datę dokonania płatności
            }
            else
            {
                Console.WriteLine("Płatność została już dokonana lub wystąpił błąd.");
            }
        }


        // Anulowanie płatności
        public void AnulujPlatnosc()
        {
            if (Status == "Oczekuje")
            {
                Console.WriteLine($"Płatność za zamówienie numerze {Zamowienie.Id} została anulowana.");
                Status = "Nieudana";
                DataPlatnosci = DateTime.MinValue; // Brak daty
            }
            else
            {
                Console.WriteLine("Nie można anulować płatności, ponieważ została już zrealizowana lub anulowana.");
            }
        }


        // Wyświetlanie szczegółów płatności
        public void WyswietlSzczegolyPlatnosci()
        {
            Console.WriteLine($"Płatność ID: {Id}");
            Console.WriteLine($"Zamówienie o numerze {Zamowienie.Id}");
            Console.WriteLine($"Kwota do zapłaty: {Kwota:c}");
            Console.WriteLine($"Metoda płatności: {MetodaPlatnosci}");
            Console.WriteLine($"Status płatności: {Status}");
            if (Status == "Zrealizowana")
            {
                Console.WriteLine($"Data płatności: {DataPlatnosci}");
            }
            else
            {
                Console.WriteLine("Płatność nie została jeszcze zrealizowana.");
            }
        }
    }
}
