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
    /// Interaktionslogik für LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {

      
        
        public LoginView()
        {
            InitializeComponent();
            timer();

          
        }

        private async void timer()
        {
            while (true)
            {
                LoginDate.Content = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                await Task.Delay(1000);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if(tempadminLogin.IsChecked == true )
            {
                this.Content = new System.Windows.Controls.Frame().Content = new AdminView();
            }
            else
            {
                this.Content = new System.Windows.Controls.Frame().Content = new UserView(PersonalNummer.Text);
            }
            
        }
    }
}
