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
    /// Logika interakcji dla klasy OknoLogowania.xaml
    /// </summary>
    public partial class OknoLogowania : Window
    {
        private Koszyk _koszyk;
        string osoba;
        public OknoLogowania(Koszyk koszyk, string kto)
        {
          
            InitializeComponent();
            osoba = kto;
            _koszyk = koszyk;
            if(osoba=="user")
            {
                LblLogin.Content = "Wpisz swój e-mail:";
                LblHasło.Content = "Wpisz swoje hasło:";
            }
            else
            {
                LblLogin.Content = "Wpisz login administratora:";
                LblHasło.Content = "Wpisz hasło:";
            }
        }

        private void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string haslo = txtHaslo.Password;

            if (osoba == "user")
            {
                
                if (email == "test@test.com" && haslo == "password123")
                {
                    Kategoria_produktu kategoria = new Kategoria_produktu(_koszyk, "user");
                    kategoria.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Niepoprawne dane logowania.");
                }
            }
            else
            {
                
                if (email == "admin1" && haslo == "admin123")
                {
                    Kategoria_produktu kategoria = new Kategoria_produktu(_koszyk,"admin");
                    kategoria.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Niepoprawne dane logowania.");
                }
            }
        }
    }
}
