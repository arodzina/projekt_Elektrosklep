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

namespace gui
{
    /// <summary>
    /// Logika interakcji dla klasy Kategoria_produktu.xaml
    /// </summary>
    public partial class Kategoria_produktu : Window
    {
        private Koszyk _koszyk;
        string osoba;
        public Kategoria_produktu(Koszyk koszyk, string kto)
        {
            osoba = kto;
            _koszyk = koszyk;
            InitializeComponent();
            if(osoba=="admin")
            {
                BtnKoszyk.Visibility = Visibility.Hidden;
            }
            else
            {
                BtnKoszyk.Visibility = Visibility.Visible;
            }
        }
        private void ClkLaptop(object sender, RoutedEventArgs e)
        {
            if (osoba == "user")
            {
                ListaProduktow laptopy = new("Laptopy", _koszyk);
                laptopy.Show();
                this.Close();
            }
            else
            {
                Admin_ListaProduktów a = new("Laptopy");
                a.Show();
                this.Close();
            }
        }
        private void ClkTablet(object sender, RoutedEventArgs e)
        {
            if (osoba == "user")
            {
                ListaProduktow tablety = new("Tablety", _koszyk);
                tablety.Show();
                this.Close();
            }
            else
            {
                Admin_ListaProduktów a = new("Tablety");
                a.Show();
                this.Close();
            }
        }
        private void ClkSmart(object sender, RoutedEventArgs e)
        {
            if (osoba == "user")
            {
                ListaProduktow telefony = new("Smartfony", _koszyk);
                telefony.Show();
                this.Close();
            }
            else
            {
                Admin_ListaProduktów a = new("Smartfony");
                a.Show();
                this.Close();
            }

        }
        private void btnKoszykClick(object sender, RoutedEventArgs e)
        {
            Koszyk_produktów k = new(_koszyk);
            k.Show();
            this.Close();
        }
    }
}
