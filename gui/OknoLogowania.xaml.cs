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
        public OknoLogowania()
        {
            InitializeComponent();
        }
        private void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string haslo = txtHaslo.Password;

            // Prosta weryfikacja
            if (email == "test@test.com" && haslo == "password123")
            {
                MenuSklepu menu = new MenuSklepu();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Niepoprawne dane logowania.");
            }
        }
    }
}
