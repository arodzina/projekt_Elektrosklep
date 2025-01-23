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
    public partial class ListaProduktow : Window
    {
        private Koszyk _koszyk;
        private List<string> p = new();
       
        public ListaProduktow(string kategoria, Koszyk koszyk)
        {
            InitializeComponent();
            _koszyk = koszyk;
            lblKategoria.Content = $"Produkty z kategorii: {kategoria}";
            List<string> produkty = PobierzProdukty(kategoria);
            listBoxProdukty.ItemsSource = produkty;
            p = produkty;  
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
            else if(kategoria == "Smartfony")
            {
                var smartfony = doc.Descendants("Produkt")
                            .Where(p => p.Attribute(XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance") + "type")?.Value == "Smartfon")
                            .Select(p => p.Element("Nazwa")?.Value )
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
                Specyfikacja specyfikacja = new Specyfikacja(nazwa, cena, opis, dodatkowePola,wybrany,_koszyk);
                specyfikacja.Show();
                
            }
        }
        private void btnPowrotClick(object sender, RoutedEventArgs e)
        {
            Kategoria_produktu kategoria = new Kategoria_produktu(_koszyk, "user");
            kategoria.Show();
            this.Close();
        }
        public void SortujPoNazwie(List<string> lista)
        {
            lista.Sort((x,y)=>(x.CompareTo(y)));
        }
        private void btnSortujNazwaClick(object sender, RoutedEventArgs e) 
        {
            SortujPoNazwie(p);
            listBoxProdukty.ItemsSource = null; 
            listBoxProdukty.ItemsSource = p;
        }
        private void btnSortujCenaClick(object sender, RoutedEventArgs e)
        {
            SortujPoCenie(p);
            listBoxProdukty.ItemsSource = null;
            listBoxProdukty.ItemsSource = p;
        }
        private void SortujPoCenie(List<string> lista)
        {
            List<Produkt> p1 = new List<Produkt>();
            Magazyn odczytanyMagazyn = Magazyn.OdczytXml("magazyn.xml");
            
            for (int i = 0; i < lista.Count; i++)
            {
                foreach(Produkt item in odczytanyMagazyn.produkty)
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


     
    }
}
