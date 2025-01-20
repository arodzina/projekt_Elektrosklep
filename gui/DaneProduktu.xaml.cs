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
    /// Logika interakcji dla klasy DaneProduktu.xaml
    /// </summary>
    public partial class DaneProduktu : Window
    {
        Laptop laptop = new();
        Elektrosklep.Smartfon smartfon = new();
        Elektrosklep.Tablet tablet = new();
        
        public DaneProduktu(string kategoria, string funkcja, Produkt? produkt)
        {
            InitializeComponent();
            if(produkt!=null && produkt is Laptop)
            {
                laptop = (Laptop)produkt;
            }
            if (produkt != null && produkt is Elektrosklep.Tablet)
            {
                tablet = (Elektrosklep.Tablet)produkt;
            }
            if (produkt != null && produkt is Smartfon)
            {
                smartfon = (Smartfon)produkt;
            }

            if (kategoria == "Laptopy")
                {
                    TxtBKate.Text = "Laptopy";
                    Lbl1.Content = "Procesor";
                    Lbl2.Content = "RAM";
                    Lbl3.Content = "Dysk";
                    Lbl4.Content = "Karta graficzna";
                }
                if (kategoria == "Tablety")
                {
                    TxtBKate.Text = "Tablety";
                    Lbl1.Content = "Wyświetlacz";
                    Lbl2.Content = "System operacyjny";
                    Lbl3.Content = "Czy rysik";
                    Lbl4.Content = "";
                    TxtB4.IsEnabled = false;
                }
                if (kategoria == "Smartfony")
                {
                    TxtBKate.Text = "Smartfony";
                    Lbl1.Content = "Przekątna ekranu";
                    Lbl2.Content = "Aparat";
                    Lbl3.Content = "Pojemność baterii";
                    Lbl4.Content = "Procesor";
                }
            if(funkcja=="dodawanie")
            {

            }
            else
            {
                if (TxtBKate.Text == "Laptopy")
                {
                    TxtBNazwa.Text = laptop.Nazwa;
                    TxtBCena.Text = laptop.Cena.ToString();
                    TxtBOpis.Text = laptop.Opis;
                    TxtB1.Text = laptop.Procesor;
                    TxtB2.Text=laptop.RAM.ToString();
                    TxtB3.Text=laptop.Dysk.ToString();
                    TxtB4.Text = laptop.KartaGraficzna;

                }
                if (TxtBKate.Text == "Tablety")
                {
                    TxtBNazwa.Text= tablet.Nazwa;
                    TxtBCena.Text=tablet.Cena.ToString();
                    TxtBOpis.Text= tablet.Opis;
                    TxtB1.Text=tablet.Wyswietlacz.ToString();
                    TxtB2.Text= tablet.SystemOperacyjny;
                    if(tablet.CzyRysik==true)
                    {
                        TxtB3.Text = "tak";
                    }
                    else
                    {
                        TxtB3.Text = "nie";
                    }
                    //TxtB3.Text=tablet.CzyRysik.ToString();
                    TxtB4.IsEnabled = false;

                }
                if (TxtBKate.Text == "Smartfony")
                {
                    TxtBNazwa.Text= smartfon.Nazwa;
                    TxtBCena.Text=smartfon.Cena.ToString();
                    TxtBOpis.Text= smartfon.Opis;
                    TxtB1.Text=smartfon.PrzekatnaEkranu.ToString();
                    TxtB2.Text = smartfon.Aparat;
                    TxtB2.Text= smartfon.PojemnoscBaterii.ToString();
                    TxtB4.Text= smartfon.Procesor;

                }
            }
        }
        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Zatwierdz_Click(object sender, RoutedEventArgs e)
        {
            string xmlFilePath = "magazyn.xml";
            Magazyn odczytanyMagazyn = Magazyn.OdczytXml(xmlFilePath);


            if (TxtBKate.Text=="Laptopy")
            {
                laptop.Nazwa = TxtBNazwa.Text;
                Double.TryParse(TxtBCena.Text, out double c);
                laptop.Cena = c;
                laptop.Opis = TxtBOpis.Text;
                laptop.Procesor = TxtB1.Text;
                int.TryParse(TxtB2.Text, out int p);
                laptop.RAM = p;
                int.TryParse(TxtB3.Text, out int s);
                laptop.Dysk = s;
                laptop.KartaGraficzna = TxtB4.Text;

                if (!odczytanyMagazyn.produkty.Any(p => p.Nazwa == laptop.Nazwa))
                {
                    odczytanyMagazyn.produkty.Add(laptop);
                }

            }
            if (TxtBKate.Text == "Tablety")
            {
                string zmienna;
                tablet.Nazwa = TxtBNazwa.Text;
                Double.TryParse(TxtBCena.Text, out double c);
                tablet.Cena = c;
                tablet.Opis = TxtBOpis.Text;
                Double.TryParse(TxtB1.Text, out double p);
                tablet.Wyswietlacz = p;
                tablet.SystemOperacyjny = TxtB2.Text;
                if(TxtB3.Text == "tak" || TxtB3.Text=="Tak")
                {
                    zmienna = "true";
                }
                else
                {
                    zmienna = "false";
                }
                bool.TryParse(zmienna, out bool b);
                tablet.CzyRysik = b;
                laptop.KartaGraficzna = TxtB4.Text;

                if (!odczytanyMagazyn.produkty.Any(p => p.Nazwa == tablet.Nazwa))
                {
                    odczytanyMagazyn.produkty.Add(tablet);
                }

            }
            if (TxtBKate.Text == "Smartfony")
            {
                smartfon.Nazwa = TxtBNazwa.Text;
                Double.TryParse(TxtBCena.Text, out double c);
                smartfon.Cena = c;
                smartfon.Opis = TxtBOpis.Text;
                Double.TryParse(TxtB1.Text, out double p);
                smartfon.PrzekatnaEkranu = p;
                smartfon.Aparat = TxtB2.Text;
                int.TryParse(TxtB2.Text, out int r);
                smartfon.PojemnoscBaterii= r;
                smartfon.Procesor = TxtB4.Text;

                if (!odczytanyMagazyn.produkty.Any(p => p.Nazwa == smartfon.Nazwa))
                {
                    odczytanyMagazyn.produkty.Add(smartfon);
                }
            }
            odczytanyMagazyn.ZapiszDoXml(xmlFilePath);
            this.Close();
        }
        
    }
}
