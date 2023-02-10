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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zeiterfassungssystem
{
    /// <summary>
    /// Interaktionslogik für AdminView.xaml
    /// </summary>
    public partial class AdminView : Page
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new System.Windows.Controls.Frame().Content = new RegisterView();
        }

        private void AdminLogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ausgeloggt");
            this.Content = new System.Windows.Controls.Frame().Content = new LoginView();
        }
    }
}
