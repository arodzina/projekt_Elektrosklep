using Elektrosklep;

internal class Program
{
    private static void Main(string[] args)
    {
        // Tworzymy magazyn
        Magazyn magazyn = new Magazyn();

        //Tworzymy produkty
        /*Laptop laptop1 = new Laptop("Laptop Dell XPS 13", 4999.99, "Elegancki laptop o wysokiej wydajności", "Intel i7", 16, 512, "Intel Iris Xe");
        Laptop laptop2 = new Laptop("Laptop HP Spectre x360", 6999.99, "Laptop 2w1 z ekranem dotykowym", "Intel i7", 16, 1000, "Intel Iris Plus");
        Laptop laptop3 = new Laptop("Laptop Apple MacBook Air M1", 5799.99, "Lekki laptop z chipem M1 i długą żywotnością baterii", "Apple M1", 8, 256, "Apple GPU");
        Laptop laptop4 = new Laptop("Laptop Lenovo ThinkPad X1 Carbon", 8499.99, "Wydajny laptop biznesowy z ekranem 14 cali", "Intel i7", 16, 512, "Intel Iris Xe");
        Laptop laptop5 = new Laptop("Laptop Asus ROG Zephyrus G14", 7999.99, "Laptop gamingowy z procesorem AMD Ryzen 9", "AMD Ryzen 9", 32, 1000, "NVIDIA GeForce RTX 3060");
        Laptop laptop6 = new Laptop("Laptop Acer Swift 3", 3799.99, "Ultrabook z procesorem AMD Ryzen 7", "AMD Ryzen 7", 8, 512, "AMD Radeon Vega");
        Laptop laptop7 = new Laptop("Laptop MSI GS66 Stealth", 9999.99, "Laptop gamingowy z ekranem 15.6 cali i RTX 3080", "Intel i9", 32, 1000, "NVIDIA GeForce RTX 3080");
        Laptop laptop8 = new Laptop("Laptop Razer Blade 15", 10999.99, "Laptop gamingowy z procesorem Intel Core i7 i RTX 3070", "Intel i7", 16, 512, "NVIDIA GeForce RTX 3070");
        Laptop laptop9 = new Laptop("Laptop Dell Alienware M15", 12999.99, "Laptop gamingowy z procesorem Intel i9 i RTX 3080 Ti", "Intel i9", 32, 1000, "NVIDIA GeForce RTX 3080 Ti");
        Laptop laptop10 = new Laptop("Laptop HP Omen 15", 7999.99, "Laptop gamingowy z procesorem AMD Ryzen 9", "AMD Ryzen 9", 16, 512, "NVIDIA GeForce RTX 3070");
        Laptop laptop11 = new Laptop("Laptop LG Gram 17", 7999.99, "Lekki laptop 17 cali z procesorem Intel i7", "Intel i7", 16, 1000, "Intel Iris Xe");
        Laptop laptop12 = new Laptop("Laptop ASUS VivoBook 15", 2899.99, "Laptop 15 cali z procesorem Intel i5", "Intel i5", 8, 512, "Intel UHD Graphics");


        Tablet tablet1 = new Tablet("iPad Pro 11\"", 3499.99, "Tablet z wyświetlaczem 11 cali", 11, "iOS", true);
        Tablet tablet2 = new Tablet("Samsung Galaxy Tab S8", 3799.99, "Tablet z wyświetlaczem 11 cali i systemem Android", 11, "Android", false);
        Tablet tablet3 = new Tablet("Microsoft Surface Pro 8", 7499.99, "Tablet 2w1 z systemem Windows i ekranem 13 cali", 13, "Windows", true);
        Tablet tablet4 = new Tablet("Lenovo Tab P11 Pro", 2999.99, "Tablet z wyświetlaczem OLED 11 cali", 11, "Android", false);
        Tablet tablet5 = new Tablet("Amazon Fire HD 10", 699.99, "Tablet 10 cali z systemem Android", 10, "Fire OS", false);
        Tablet tablet6 = new Tablet("Huawei MatePad Pro", 3599.99, "Tablet z ekranem 12.6 cali i systemem Android", 12.6, "HarmonyOS", true);
        Tablet tablet7 = new Tablet("Xiaomi Pad 5", 1699.99, "Tablet 11 cali z wyświetlaczem 2.5K i systemem Android", 11, "Android", false);
        Tablet tablet8 = new Tablet("iPad Air", 3299.99, "Tablet z wyświetlaczem 10.9 cala i procesorem M1", 10.9, "iOS", true);
        Tablet tablet9 = new Tablet("Samsung Galaxy Tab A7", 1599.99, "Tablet 10.4 cali z systemem Android", 10.4, "Android", false);
        Tablet tablet10 = new Tablet("Lenovo Yoga Tab 13", 3899.99, "Tablet z wyświetlaczem 13 cali", 13, "Android", true);
        Tablet tablet11 = new Tablet("Amazon Fire HD 8", 399.99, "Tablet 8 cali z systemem Android", 8, "Fire OS", false);
        Tablet tablet12 = new Tablet("Realme Pad", 1499.99, "Tablet 10.4 cali z systemem Android", 10.4, "Android", false);



        Smartfon smartfon1 = new Smartfon("iPhone 14 Pro", 8999.99, "Smartfon z aparatami 48 MP", 6.1, "48 MP", 3200, "A15 Bionic");
        Smartfon smartfon2 = new Smartfon("Samsung Galaxy S22 Ultra", 6499.99, "Smartfon z aparatem 108 MP i ekranem 6.8 cala", 6.8, "108 MP", 5000, "Exynos 2200");
        Smartfon smartfon3 = new Smartfon("Google Pixel 6 Pro", 5499.99, "Smartfon z aparatem 50 MP i ekranem 6.7 cala", 6.7, "50 MP", 5000, "Google Tensor");
        Smartfon smartfon4 = new Smartfon("OnePlus 10 Pro", 4999.99, "Smartfon z aparatem 48 MP i ekranem 6.7 cala", 6.7, "48 MP", 5000, "Snapdragon 8 Gen 1");
        Smartfon smartfon5 = new Smartfon("Xiaomi Mi 11 Ultra", 4999.99, "Smartfon z aparatem 50 MP i ekranem 6.81 cala", 6.81, "50 MP", 5000, "Snapdragon 888");
        Smartfon smartfon6 = new Smartfon("Samsung Galaxy Z Fold 4", 11499.99, "Składany smartfon z ekranem 7.6 cala", 7.6, "50 MP", 4400, "Snapdragon 8+ Gen 1");
        Smartfon smartfon7 = new Smartfon("Oppo Find X5 Pro", 7499.99, "Smartfon z aparatem 50 MP i ekranem 6.7 cala", 6.7, "50 MP", 5000, "Snapdragon 8 Gen 1");
        Smartfon smartfon8 = new Smartfon("Realme GT 2 Pro", 3499.99, "Smartfon z aparatem 50 MP i ekranem 6.7 cala", 6.7, "50 MP", 5000, "Snapdragon 8 Gen 1");
        Smartfon smartfon9 = new Smartfon("Xiaomi 12 Pro", 4699.99, "Smartfon z aparatem 50 MP i ekranem 6.73 cala", 6.73, "50 MP", 4600, "Snapdragon 8 Gen 1");
        Smartfon smartfon10 = new Smartfon("Vivo X80 Pro", 5999.99, "Smartfon z aparatem 50 MP i ekranem 6.78 cala", 6.78, "50 MP", 4700, "Snapdragon 8 Gen 1");
        Smartfon smartfon11 = new Smartfon("Asus ROG Phone 6", 5999.99, "Smartfon gamingowy z procesorem Snapdragon 8+ Gen 1", 6.78, "50 MP", 6000, "Snapdragon 8+ Gen 1");
        Smartfon smartfon12 = new Smartfon("Motorola Edge 30 Pro", 3799.99, "Smartfon z aparatem 50 MP i ekranem 6.7 cala", 6.7, "50 MP", 4800, "Snapdragon 8 Gen 1");



         Dodajemy produkty do magazynu
        magazyn.DodajProdukt(laptop1, 10);
        magazyn.DodajProdukt(laptop2, 5);
        magazyn.DodajProdukt(laptop3, 3);
        magazyn.DodajProdukt(laptop4, 15);
        magazyn.DodajProdukt(laptop5, 7);
        magazyn.DodajProdukt(laptop6, 12);
        magazyn.DodajProdukt(laptop7, 6);
        magazyn.DodajProdukt(laptop8, 4);
        magazyn.DodajProdukt(laptop9, 2);
        magazyn.DodajProdukt(laptop10, 10);
        magazyn.DodajProdukt(laptop11, 5);
        magazyn.DodajProdukt(laptop12, 20);

        magazyn.DodajProdukt(tablet1, 8);
        magazyn.DodajProdukt(tablet2, 10);
        magazyn.DodajProdukt(tablet3, 6);
        magazyn.DodajProdukt(tablet4, 12);
        magazyn.DodajProdukt(tablet5, 25);
        magazyn.DodajProdukt(tablet6, 7);
        magazyn.DodajProdukt(tablet7, 15);
        magazyn.DodajProdukt(tablet8, 9);
        magazyn.DodajProdukt(tablet9, 18);
        magazyn.DodajProdukt(tablet10, 4);
        magazyn.DodajProdukt(tablet11, 22);
        magazyn.DodajProdukt(tablet12, 5);

        magazyn.DodajProdukt(smartfon1, 12);
        magazyn.DodajProdukt(smartfon2, 8);
        magazyn.DodajProdukt(smartfon3, 5);
        magazyn.DodajProdukt(smartfon4, 14);
        magazyn.DodajProdukt(smartfon5, 20);
        magazyn.DodajProdukt(smartfon6, 2);
        magazyn.DodajProdukt(smartfon7, 6);
        magazyn.DodajProdukt(smartfon8, 16);
        magazyn.DodajProdukt(smartfon9, 11);
        magazyn.DodajProdukt(smartfon10, 7);
        magazyn.DodajProdukt(smartfon11, 9);
        magazyn.DodajProdukt(smartfon12, 13);


         Wyświetlamy wszystkie produkty w magazynie
        magazyn.WyswietlProdukty();

        magazyn.ZapiszDoXml("magazyn.xml");
        */
        Magazyn odczytanyMagazyn = Magazyn.OdczytXml("magazyn.xml");
        Console.WriteLine("odczytany:");
        foreach (var produkt in odczytanyMagazyn.produkty)
        {
            Console.WriteLine(produkt);
        }
    } }
    //Tworzymy przykładowe produkty
    /* var laptop1 = new Laptop(1, "Laptop Dell XPS", 5000, "Laptop Dell z procesorem Intel i 16 GB RAM", "Intel Core i7", 16, 512, "NVIDIA GTX 1650");
     var tablet1 = new Tablet(2, "Tablet Samsung Galaxy Tab", 2000, "Tablet z ekranem 10 cali", 10.1, "Android", true);
     var smartfon1 = new Smartfon(3, "Smartfon Samsung Galaxy", 2500, "Smartfon z aparatem 48 MP i baterią 4000 mAh", 6.5, "48 MP", 4000, "Exynos 2100");

      Tworzymy koszyk
     var koszyk = new Koszyk();

      Dodajemy produkty do koszyka
     koszyk.DodajProdukt(laptop1);
     koszyk.DodajProdukt(tablet1);
     koszyk.DodajProdukt(smartfon1);

      Zastosowanie rabatu (jeśli produkty z każdej kategorii są w koszyku)
     koszyk.ZastosujRabat();

      Wyświetlamy zawartość koszyka i obliczoną cenę po rabacie
     Console.WriteLine("Zawartość koszyka:");
     koszyk.WyswietlKoszyk();

     Console.WriteLine("\n");


    

      Zaktualizuj ilość produktu
     magazyn.ZaktualizujIloscProduktu(1, 12);

      Usuwamy produkt z magazynu
     magazyn.UsunProdukt(3); // Usuwamy Smartfon Samsung Galaxy

      Wyświetlamy produkty po zmianach
     magazyn.WyswietlProdukty();

     Console.WriteLine("\n");

      Tworzymy przykładowego klienta
     Klient klient = new Klient(1, "Jan", "Kowalski", "jan.kowalski@email.com", "123-456-789");

      Dodajemy adresy do klienta
     klient.DodajAdres("ul. Przykładowa 1, Warszawa");
     klient.DodajAdres("ul. Inna 2, Kraków");

      Tworzymy przykładowe zamówienie
     Zamowienie zamowienie = new Zamowienie(1, klient);
     zamowienie.DodajProdukt(new Laptop(1, "Laptop Dell XPS", 5000, "Laptop Dell z procesorem Intel i 16 GB RAM", "Intel Core i7", 16, 512, "NVIDIA GTX 1650"));
     zamowienie.DodajProdukt(new Tablet(2, "Tablet Samsung Galaxy Tab", 2000, "Tablet z ekranem 10 cali", 10.1, "Android", true));

      Dodajemy zamówienie do historii klienta
     klient.DodajZamowienie(zamowienie);

      Wyświetlamy historię zamówień klienta
     klient.WyswietlHistorieZamowien();



      Dodajemy produkty do zamówienia
     zamowienie.DodajProdukt(laptop1);
     zamowienie.DodajProdukt(tablet1);
     zamowienie.DodajProdukt(smartfon1);

      Wyświetlamy szczegóły zamówienia
     zamowienie.WyswietlSzczegoly();

      Zaktualizowanie statusu zamówienia
     zamowienie.ZaktualizujStatus("W realizacji");

     Console.WriteLine("\n");


     var platnosc = new Platnosc(zamowienie, "Karta kredytowa");

      Wyświetlamy szczegóły płatności przed jej realizacją
     platnosc.WyswietlSzczegolyPlatnosci();

      Dokonujemy płatności
     platnosc.DokonajPlatnosci();

      Wyświetlamy szczegóły płatności po realizacji
     platnosc.WyswietlSzczegolyPlatnosci();
 }
    
}*/

