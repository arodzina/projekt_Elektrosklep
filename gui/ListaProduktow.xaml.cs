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
        public ListaProduktow(string kategoria)
        {
            InitializeComponent();
           
            // Ustawienie nagłówka z nazwą kategorii
            lblKategoria.Content = $"Produkty z kategorii: {kategoria}";

            // Załadowanie listy produktów na podstawie kategorii
            List<string> produkty = PobierzProdukty(kategoria);
            listBoxProdukty.ItemsSource = produkty;
        }

        // Metoda zwracająca listę produktów na podstawie kategorii
        private List<string> PobierzProdukty(string kategoria)
        {
            //string sciezkaPliku = "magazyn.xml"; // Ścieżka do pliku XML
            //Magazyn? magazyn = Magazyn.OdczytXml(sciezkaPliku);

            /*if (magazyn == null)
            {
                MessageBox.Show("Nie udało się wczytać danych z pliku XML.");
                return new List<string>();
            }
            */

            string xmlFilePath = "magazyn.xml";
            XDocument doc = XDocument.Load(xmlFilePath);

            if (kategoria == "Laptopy")
            {
                var laptopy = doc.Descendants("Produkt")
                             .Where(p => p.Attribute(XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance") + "type")?.Value == "Laptop")
                            .Select(p => p.Element("Nazwa")?.Value) // Wyciągamy nazwę produktu
                            .Where(nazwa => nazwa != null)
                            .ToList();
                return laptopy;
            }
            else if (kategoria == "Tablety")
            {
                var tablety = doc.Descendants("Produkt")
                            .Where(p => p.Attribute(XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance") + "type")?.Value == "Tablet")
                            .Select(p => p.Element("Nazwa")?.Value) // Wyciągamy nazwę produktu
                            .Where(nazwa => nazwa != null)
                            .ToList();
                return tablety;
            }
            else if(kategoria == "Smartfony")
            {
                var smartfony = doc.Descendants("Produkt")
                            .Where(p => p.Attribute(XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance") + "type")?.Value == "Smartfon")
                            .Select(p => p.Element("Nazwa")?.Value) // Wyciągamy nazwę produktu
                            .Where(nazwa => nazwa != null)
                            .ToList();
                return smartfony;
            }
            else
            {
                return new List<string>();
            }
 
            
        }
    


        // Obsługa przycisku powrotu
        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            // Powrót do menu sklepu
            Kategoria_produktu kategoria = new Kategoria_produktu();
            kategoria.Show();
            this.Close();
        }
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            foreach(ListBoxItem item in listBoxProdukty.SelectedItems)
            {
                //koszyk.DodajProdukt(item); coś trzeba zrobić żeby się dodawało do koszyka
            }
            
        }
    }
}