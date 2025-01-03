﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            OknoLogowania logowanie = new OknoLogowania();
            logowanie.Show();
            this.Hide();
        }

        private void btnZarejestruj_Click(object sender, RoutedEventArgs e)
        {
            OknoRejestracji rejestracja = new OknoRejestracji();
            rejestracja.Show();
            this.Hide();
        }

        private void btnGosc_Click(object sender, RoutedEventArgs e)
        {
            MenuSklepu menu = new MenuSklepu();
            menu.Show();
            this.Hide();
        }
    }
}