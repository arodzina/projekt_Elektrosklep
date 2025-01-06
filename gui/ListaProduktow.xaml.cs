using Elektrosklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace gui
{
    /// <summary>
    /// Logika interakcji dla klasy ListaProduktow.xaml
    /// </summary>
    public partial class ListaProduktow : Window
    {
        private Koszyk _koszyk;
      
        
        public ListaProduktow(string kategoria, Koszyk koszyk)
        {
            InitializeComponent();
           _koszyk = koszyk;
            // Ustawienie nagłówka z nazwą kategorii
            lblKategoria.Content = $"Produkty z kategorii: {kategoria}";

            // Załadowanie listy produktów na podstawie kategorii
            List<string> produkty = PobierzProdukty(kategoria);
            listBoxProdukty.ItemsSource = produkty;
            
        }

        // Metoda zwracająca listę produktów na podstawie kategorii
        private List<string> PobierzProdukty(string kategoria)
        {


            string xmlFilePath = "magazyn.xml";
            XDocument doc = XDocument.Load(xmlFilePath);

            if (kategoria == "Laptopy")
            {
                var laptopy = doc.Descendants("Produkt")
                             .Where(p => p.Attribute(XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance") + "type")?.Value == "Laptop")
                            .Select(p => p.Element("Nazwa")?.Value) 
                            .Where(nazwa => nazwa != null)
                            .ToList();
                return laptopy;
            }
            else if (kategoria == "Tablety")
            {
                var tablety = doc.Descendants("Produkt")
                            .Where(p => p.Attribute(XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance") + "type")?.Value == "Tablet")
                            .Select(p => p.Element("Nazwa")?.Value) 
                            .Where(nazwa => nazwa != null)
                            .ToList();
                return tablety;
            }
            else if(kategoria == "Smartfony")
            {
                var smartfony = doc.Descendants("Produkt")
                            .Where(p => p.Attribute(XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance") + "type")?.Value == "Smartfon")
                            .Select(p => p.Element("Nazwa")?.Value)
                            .Where(nazwa => nazwa != null)
                            .ToList();
                return smartfony;
            }
            else
            {
                return new List<string>();
            }
 
            
        }

        private void listBoxProdukty_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listBoxProdukty.SelectedItem == null)
                return;
            
            Produkt pr = listBoxProdukty.SelectedItem as Produkt;
            string wybranyProdukt = listBoxProdukty.SelectedItem.ToString();
            string xmlFilePath = "magazyn.xml";
            XDocument doc = XDocument.Load(xmlFilePath);

            var produkt = doc.Descendants("Produkt")
                             .FirstOrDefault(p => p.Element("Nazwa")?.Value == wybranyProdukt);

           
            if (produkt != null)
            {
                string nazwa = produkt.Element("Nazwa")?.Value;
                string cena = produkt.Element("Cena")?.Value;
                string opis = produkt.Element("Opis")?.Value;
                string typ = produkt.Attribute(XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance") + "type")?.Value;

                // Dodatkowe pola w zależności od typu produktu
                Dictionary<string, string> dodatkowePola = new();

                if (typ == "Laptop")
                {
                    dodatkowePola["Procesor"] = produkt.Element("Procesor")?.Value;
                    dodatkowePola["RAM"] = $"{produkt.Element("RAM")?.Value} GB";
                    dodatkowePola["Dysk"] = $"{produkt.Element("Dysk")?.Value} GB";
                    dodatkowePola["Karta Graficzna"] = produkt.Element("KartaGraficzna")?.Value;
                }
                else if (typ == "Smartfon")
                {
                    dodatkowePola["Przekątna Ekranu"] = $"{produkt.Element("PrzekatnaEkranu")?.Value} cala";
                    dodatkowePola["Aparat"] = produkt.Element("Aparat")?.Value;
                    dodatkowePola["Pojemność Baterii"] = $"{produkt.Element("PojemnoscBaterii")?.Value} mAh";
                    dodatkowePola["Procesor"] = produkt.Element("Procesor")?.Value;
                }
                else if (typ == "Tablet")
                {
                    dodatkowePola["Wyświetlacz"] = $"{produkt.Element("Wyswietlacz")?.Value} cala";
                    dodatkowePola["System Operacyjny"] = produkt.Element("SystemOperacyjny")?.Value;
                    dodatkowePola["Czy Rysik"] = produkt.Element("CzyRysik")?.Value == "true" ? "Tak" : "Nie";
                }
                
                // Otwórz nowe okno z pełną specyfikacją
                Specyfikacja specyfikacja = new Specyfikacja(pr, nazwa, cena, opis, dodatkowePola, _koszyk);
                specyfikacja.Show();
                this.Close();
            }
        }

        // Obsługa przycisku powrotu
        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            // Powrót do menu sklepu
            Kategoria_produktu kategoria = new Kategoria_produktu(_koszyk);
            kategoria.Show();
            this.Close();
        }


     
    }
}