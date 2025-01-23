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
    public partial class OknoLogowania : Window
    {
        private Koszyk _koszyk;
        Dictionary<string, string> daneLogowania;
        string osoba;
        public OknoLogowania(Koszyk koszyk, string kto)
        {
            InitializeComponent();
            osoba = kto;
            _koszyk = koszyk;
            daneLogowania= new();
            daneLogowania.Add("email1", "password1");
            daneLogowania.Add("email2", "password2");
            daneLogowania.Add("email3", "password3");
            daneLogowania.Add("email4", "password4");
            if (osoba=="user")
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
                if (daneLogowania.TryGetValue(email, out string p))
                {
                    if (haslo == p)
                    {
                        Kategoria_produktu kategoria = new Kategoria_produktu(_koszyk, "user");
                        kategoria.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Niepoprawne dane logowania.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
                } 
            }
            else
            {
                if (email == "admin1" && haslo == "admin123")
                {
                    Kategoria_produktu kategoria = new Kategoria_produktu(_koszyk, "admin");
                    kategoria.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Niepoprawne dane logowania.", "Błąd logowania", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void btnPowrot_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            this.Close();
        }
    }
}
