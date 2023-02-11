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
using Zeiterfassungssystem.Controller;
using Zeiterfassungssystem.Model;

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
            if(User.userList.Count == 0)
            {
               UserController.getAllUsers();
            }
            ArbeitstagController.checkForCurrentDateInDB();
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
            Int32 persNr = 0;
            try
            {
                persNr = Int32.Parse(PersonalNummer.Text);
            } catch
            {
                MessageBox.Show("Bitte gültige Personalnummer eingeben!");
            }

            if(!User.userList.TryGetValue(persNr, out User.aktiveUser))
            {
                MessageBox.Show("Unbekannte Personalnummer!");
            } else if (User.aktiveUser.IsAdmin && loginPassword.Password.Equals(User.aktiveUser.Password))
            {
                
                this.Content = new System.Windows.Controls.Frame().Content = new AdminView();
            } else if (loginPassword.Password.Equals(User.aktiveUser.Password))
            {

                this.Content = new System.Windows.Controls.Frame().Content = new UserView();
            } else
            {
                loginPassword.Background = Brushes.Red;
            }
          
            
        }


        private static Boolean checkPassword(String pw)
        {
            return User.aktiveUser.Password.Equals(pw); 
        }

        private void LoginButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }
    }
}
