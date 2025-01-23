using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektrosklep
{
    public class Klient
    {
        // Właściwości
        public int Id { get; set; } // Unikalny identyfikator klienta
        public string Imie { get; set; } // Imię klienta
        public string Nazwisko { get; set; } // Nazwisko klienta
        public string Email { get; set; } // E-mail klienta
        public string NumerTelefonu { get; set; } // Numer telefonu klienta
        public List<string> Adresy { get; set; } // Lista adresów klienta (do wysyłki)        
        public List<Zamowienie> HistoriaZamowien { get; set; } // Lista zamówień klienta (historia zakupów)


        // Konstruktor
        public Klient(int id, string imie, string nazwisko, string email, string numerTelefonu)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
            NumerTelefonu = numerTelefonu;
            Adresy = new List<string>(); // Początkowo brak adresów
            HistoriaZamowien = new List<Zamowienie>(); // Początkowo brak zamówień
        }


        // Dodaj adres do klienta
        public void DodajAdres(string adres)
        {
            Adresy.Add(adres);
            Console.WriteLine($"Adres {adres} został dodany do konta klienta {Imie} {Nazwisko}.");
        }


        // Dodaj zamówienie do historii klienta
        public void DodajZamowienie(Zamowienie zamowienie)
        {
            HistoriaZamowien.Add(zamowienie);
            Console.WriteLine($"Zamówienie ID {zamowienie.Id} zostało dodane do historii klienta {Imie} {Nazwisko}.");
        }


        // Wyświetl historię zamówień
        public void WyswietlHistorieZamowien()
        {
            if (HistoriaZamowien.Count == 0)
            {
                Console.WriteLine("Brak historii zamówień.");
            }
            else
            {
                Console.WriteLine($"Historia zamówień dla klienta {Imie} {Nazwisko}:");
                foreach (var zamowienie in HistoriaZamowien)
                {
                    Console.WriteLine($"Zamówienie ID: {zamowienie.Id}, Data: {zamowienie.DataZamowienia}, Status: {zamowienie.Status}");
                }
            }
        }
    }
}
