﻿using Elektrosklep;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace gui
{
    public partial class Specyfikacja : Window

    {
        private Koszyk _koszyk;
        private Produkt _produkt;

        public Specyfikacja( string nazwa, string cena, string opis, Dictionary<string, string> dodatkowePola, Produkt wybrany, Koszyk koszyk )
        {
            
            InitializeComponent();
            _koszyk = koszyk;
            lblNazwa.Text = nazwa;
            lblCena.Text = $"{cena} PLN";
            lblOpis.Text = opis;
            _produkt= wybrany;
            // Dodaj dynamicznie dodatkowe pola
            foreach (var pole in dodatkowePola)
            {
                stackDodatkowePola.Children.Add(new TextBlock
                {
                    Text = $"{pole.Key}:",
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 10, 0, 0)
                });

                stackDodatkowePola.Children.Add(new TextBlock
                {
                    Text = pole.Value,
                    Margin = new Thickness(0, 0, 0, 10)
                });
            }
            var gifUri = new Uri("pack://application:,,,/assets/shopping-cart-shopping.gif");
            var gifImage = new BitmapImage(gifUri);
            ImageBehavior.SetAnimatedSource(this.gifImage, gifImage);
            
        }
        private async void btnDodajDoKoszyka_Click(object sender, RoutedEventArgs e)
        {
            string nazwaProduktu = lblNazwa.Text;
            _koszyk.DodajProdukt(_produkt);
            MessageBox.Show($"Dodano '{nazwaProduktu}' do koszyka!", "Koszyk", MessageBoxButton.OK, MessageBoxImage.Information);
            BtnDodaj.Visibility = Visibility.Hidden;
            BtnKoszyk.Visibility = Visibility.Hidden;
            BtnPowrót.Visibility = Visibility.Hidden;
            gifImage.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            gifImage.Visibility = Visibility.Collapsed;
            BtnDodaj.Visibility = Visibility.Visible;
            BtnKoszyk.Visibility = Visibility.Visible;
            BtnPowrót.Visibility = Visibility.Visible;
        }
        private void btnPowrót_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        private void btnKoszyk_Click(object sender, RoutedEventArgs e)
        {
            
            Koszyk_produktów k = new(_koszyk);
            k.Show();
            this.Close();
        }
    }
}
