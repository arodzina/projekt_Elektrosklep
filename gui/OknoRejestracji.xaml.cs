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
    /// Logika interakcji dla klasy OknoRejestracji.xaml
    /// </summary>
    public partial class OknoRejestracji : Window
    {
        private Koszyk _koszyk;
        public OknoRejestracji(Koszyk koszyk)
        {
            InitializeComponent();
            _koszyk = koszyk;
        }
        // Obsługa kliknięcia przycisku rejestracji
        private void btnZarejestruj_Click(object sender, RoutedEventArgs e)
        {
            string imie = txtImie.Text;
            string nazwisko = txtNazwisko.Text;
            string email = txtEmail.Text;
            string haslo = txtHaslo.Password;

            // Walidacja danych
            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(haslo))
            {
                lblError.Content = "Wszystkie pola muszą być wypełnione!";
                lblError.Visibility = Visibility.Visible;
            }
            else if (!email.Contains("@"))
            {
                lblError.Content = "Proszę podać poprawny adres e-mail!";
                lblError.Visibility = Visibility.Visible;
            }
            else
            {
                // Rejestracja (zapis do bazy danych, lista użytkowników itp.)
                // Możesz tutaj dodać kod do zapisania użytkownika, np. do bazy danych.

                // Po udanej rejestracji
                MessageBox.Show("Rejestracja zakończona sukcesem!");

                // Możesz zamknąć okno rejestracji i przejść do okna logowania lub głównego menu
                this.Close();
                Kategoria_produktu menu = new Kategoria_produktu(_koszyk);
                menu.Show();
                
            }
        }
    }
}
