using Elektrosklep;

internal class Program
{
    private static void Main(string[] args)
    {
        // Tworzymy przykładowe produkty
        var laptop1 = new Laptop(1, "Laptop Dell XPS", 5000, "Laptop Dell z procesorem Intel i 16 GB RAM", "Intel Core i7", 16, 512, "NVIDIA GTX 1650");
        var tablet1 = new Tablet(2, "Tablet Samsung Galaxy Tab", 2000, "Tablet z ekranem 10 cali", 10.1, "Android", true);
        var smartfon1 = new Smartfon(3, "Smartfon Samsung Galaxy", 2500, "Smartfon z aparatem 48 MP i baterią 4000 mAh", 6.5, "48 MP", 4000, "Exynos 2100");

        // Tworzymy koszyk
        var koszyk = new Koszyk();

        // Dodajemy produkty do koszyka
        koszyk.DodajProdukt(laptop1);
        koszyk.DodajProdukt(tablet1);
        koszyk.DodajProdukt(smartfon1);

        // Zastosowanie rabatu (jeśli produkty z każdej kategorii są w koszyku)
        koszyk.ZastosujRabat();

        // Wyświetlamy zawartość koszyka i obliczoną cenę po rabacie
        Console.WriteLine("Zawartość koszyka:");
        koszyk.WyswietlKoszyk();

        Console.WriteLine("\n");


        // Tworzymy magazyn
        var magazyn = new Magazyn();

        // Dodajemy produkty do magazynu
        magazyn.DodajProdukt(laptop1, 10);
        magazyn.DodajProdukt(tablet1, 20);
        magazyn.DodajProdukt(smartfon1, 15);

        // Wyświetlamy produkty w magazynie
        magazyn.WyswietlProdukty();

        // Sprawdzamy dostępność produktu
        magazyn.SprawdzDostepnosc(1); // Laptop Dell XPS

        // Zaktualizuj ilość produktu
        magazyn.ZaktualizujIloscProduktu(1, 12);

        // Usuwamy produkt z magazynu
        magazyn.UsunProdukt(3); // Usuwamy Smartfon Samsung Galaxy

        // Wyświetlamy produkty po zmianach
        magazyn.WyswietlProdukty();

        Console.WriteLine("\n");

        // Tworzymy przykładowego klienta
        Klient klient = new Klient(1, "Jan", "Kowalski", "jan.kowalski@email.com", "123-456-789");

        // Dodajemy adresy do klienta
        klient.DodajAdres("ul. Przykładowa 1, Warszawa");
        klient.DodajAdres("ul. Inna 2, Kraków");

        // Tworzymy przykładowe zamówienie
        Zamowienie zamowienie = new Zamowienie(1, klient);
        zamowienie.DodajProdukt(new Laptop(1, "Laptop Dell XPS", 5000, "Laptop Dell z procesorem Intel i 16 GB RAM", "Intel Core i7", 16, 512, "NVIDIA GTX 1650"));
        zamowienie.DodajProdukt(new Tablet(2, "Tablet Samsung Galaxy Tab", 2000, "Tablet z ekranem 10 cali", 10.1, "Android", true));

        // Dodajemy zamówienie do historii klienta
        klient.DodajZamowienie(zamowienie);

        // Wyświetlamy historię zamówień klienta
        klient.WyswietlHistorieZamowien();

        

        // Dodajemy produkty do zamówienia
        zamowienie.DodajProdukt(laptop1);
        zamowienie.DodajProdukt(tablet1);
        zamowienie.DodajProdukt(smartfon1);

        // Wyświetlamy szczegóły zamówienia
        zamowienie.WyswietlSzczegoly();

        // Zaktualizowanie statusu zamówienia
        zamowienie.ZaktualizujStatus("W realizacji");

        Console.WriteLine("\n");


        var platnosc = new Platnosc(zamowienie, "Karta kredytowa");

        // Wyświetlamy szczegóły płatności przed jej realizacją
        platnosc.WyswietlSzczegolyPlatnosci();

        // Dokonujemy płatności
        platnosc.DokonajPlatnosci();

        // Wyświetlamy szczegóły płatności po realizacji
        platnosc.WyswietlSzczegolyPlatnosci();
    }
}
