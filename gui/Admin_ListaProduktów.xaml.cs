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
    /// Logika interakcji dla klasy Admin_ListaProduktów.xaml
    /// </summary>
    public partial class Admin_ListaProduktów : Window
    {
        private List<string> p = new();
        private Koszyk _koszyk;
        string kategoria1;
        public Admin_ListaProduktów(string kategoria)
        {
            InitializeComponent();
            lblKat.Content = $"Produkty z kategorii: {kategoria}";
            List<string> produkty = PobierzProdukty(kategoria);
            lstBoxProdukty.ItemsSource = produkty;
            p = produkty;
            kategoria1 = kategoria;
        }

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
            else if (kategoria == "Smartfony")
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

        private void lstBoxProdukty_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstBoxProdukty.SelectedItem == null)
                return;
            
            string wybranyProdukt = lstBoxProdukty.SelectedItem.ToString();
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
                Magazyn odczytanyMagazyn = Magazyn.OdczytXml("magazyn.xml");
                Produkt wybrany = null;
                foreach (var item in odczytanyMagazyn.produkty)
                {
                    if (item.Nazwa == nazwa)
                    {
                        wybrany = item;
                        break;
                    }
                }
               

            }
        }
      
        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            // Powrót do menu sklepu
            Kategoria_produktu kategoria = new Kategoria_produktu(_koszyk, "admin");
            kategoria.Show();
            this.Close();
        }
        public void SortujPoNazwie(List<string> lista)
        {
            lista.Sort((x, y) => (x.CompareTo(y)));
        }
        private void btnSortujNazwa_Click(object sender, RoutedEventArgs e)
        {
            List<string> produkty = PobierzProdukty(kategoria1);
            lstBoxProdukty.ItemsSource = produkty;
            p = produkty;
            SortujPoNazwie(p);
            lstBoxProdukty.ItemsSource = null;
            lstBoxProdukty.ItemsSource = p;
        }
        private void btnSortujCena_Click(object sender, RoutedEventArgs e)
        {
            List<string> produkty = PobierzProdukty(kategoria1);
            lstBoxProdukty.ItemsSource = produkty;
            p = produkty;
            SortujPoCenie(p);
            lstBoxProdukty.ItemsSource = null;
            lstBoxProdukty.ItemsSource = p;
        }
        private void SortujPoCenie(List<string> lista)
        {

            List<Produkt> p1 = new List<Produkt>();
            Magazyn odczytanyMagazyn = Magazyn.OdczytXml("magazyn.xml");

            for (int i = 0; i < lista.Count; i++)
            {
                foreach (Produkt item in odczytanyMagazyn.produkty)
                {
                    if (item.Nazwa == lista[i])
                    {
                        p1.Add(item);

                        break;
                    }
                }
            }
            p1.Sort();
            lista.Clear();
            foreach (var produkt in p1)
            {
                lista.Add(produkt.Nazwa);
            }
        }
        private void btnUsunzMagazynu_Click(object sender, RoutedEventArgs e)
        {
            Magazyn odczytanyMagazyn = Magazyn.OdczytXml("magazyn.xml");
            if (lstBoxProdukty.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano żadnego produktu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            List<string> lista = new List<string>();
            foreach (string item in lstBoxProdukty.SelectedItems)
            {
                lista.Add(item);
            }
            foreach (string p in lista)
            {
                odczytanyMagazyn.produkty.RemoveAll(x=>x.Nazwa.Equals(p));
            }
            odczytanyMagazyn.ZapiszDoXml("magazyn.xml");

            List<string> produkty = PobierzProdukty(lblKat.Content.ToString().Replace("Produkty z kategorii: ", ""));
            lstBoxProdukty.ItemsSource = null; 
            lstBoxProdukty.ItemsSource = produkty;
        }
        private void btnDodajDoMagazynu_Click(object sender, RoutedEventArgs e)
        {
            Magazyn odczytanyMagazyn = Magazyn.OdczytXml("magazyn.xml");
            DaneProduktu dane = new(kategoria1, "dodawanie", null);
            dane.ShowDialog();
           
            odczytanyMagazyn = Magazyn.OdczytXml("magazyn.xml");

            List<string> produkty = PobierzProdukty(kategoria1);
            lstBoxProdukty.ItemsSource = null;
            lstBoxProdukty.ItemsSource = produkty;

        }
        private void btnAktualizuj_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoxProdukty.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano żadnego produktu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string nazwap = lstBoxProdukty.SelectedItem.ToString();
            Magazyn odczytanyMagazyn = Magazyn.OdczytXml("magazyn.xml");
            Produkt produkt = odczytanyMagazyn.produkty.FirstOrDefault(p => p.Nazwa == nazwap);

            if (produkt != null)
            {
                DaneProduktu dane = new(kategoria1, "aktualizowanie", produkt);
                dane.ShowDialog();
                odczytanyMagazyn.ZapiszDoXml("magazyn.xml");
                List<string> produkty = PobierzProdukty(lblKat.Content.ToString().Replace("Produkty z kategorii: ", ""));
                lstBoxProdukty.ItemsSource = null;
                lstBoxProdukty.ItemsSource = produkty;
            }
        }
        private void btnKoniec_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        }
}