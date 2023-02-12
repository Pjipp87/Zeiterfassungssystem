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
    /// Interaktionslogik für UserView.xaml
    /// </summary>
    public partial class UserView : Page


    {
        private DateTime dt = DateTime.Now;
        private string selectedDate;
        private Boolean tempLoggedIn = false;
        public UserView()
        {
            InitializeComponent();
            timer();
            UserWelcomeLabel.Content = User.aktiveUser != null ?  "Hallo " + User.aktiveUser.FirstName + " "+User.aktiveUser.LastName : "Willkommen";
 
            if (User.aktiveUser.IsWorking)
            {
                
                KommenButton.IsEnabled = false;
                GehenButton.IsEnabled = true;
            }
            else
            {
               
                KommenButton.IsEnabled = true;
                GehenButton.IsEnabled = false;
            }
        }

        private void UserLogoutButton_Click(object sender, RoutedEventArgs e)
        {
            User.aktiveUser = null;
            this.Content = new System.Windows.Controls.Frame().Content = new LoginView();
        }

        private void KommenButton_Click(object sender, RoutedEventArgs e)
        {
            KommenButton.IsEnabled = false;
            GehenButton.IsEnabled = true;
            ArbeitszeitController.arbeitsBegin(User.aktiveUser.UserID);
            User.aktiveUser.IsWorking = true;
            UserTimeState.Content = "Gekommen um " + DateTime.Now.ToString("HH:mm");
        }

        private void GehenButton_Click(object sender, RoutedEventArgs e)
        {
            KommenButton.IsEnabled = true;
            GehenButton.IsEnabled = false;
            ArbeitszeitController.arbeitsEnde(User.aktiveUser.UserID);
            UserTimeState.Content = "Gegangen um " + DateTime.Now.ToString("HH:mm");
        }

        private async void timer()
        {
            while (true)
            {
                AktuelleZeitUserView.Content = DateTime.Now.ToString("HH:mm:ss");
                await Task.Delay(1000);
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = ((DateTime)DatumUser.SelectedDate).ToString("yyyy-MM-dd");
            ArbeitszeitenGrid.ItemsSource = null;
            Arbeitszeiten.arbeitszeitenList.Clear();
        }

        private void ArbeitszeitenAnzeigen_Click(object sender, RoutedEventArgs e)
        {
            Arbeitszeiten.arbeitszeitenList.Clear();
            
            if (ArbeitszeitController.getArbeitstagBenutzer(User.aktiveUser.UserID, selectedDate))
            {
                ArbeitszeitenGrid.ItemsSource = Arbeitszeiten.arbeitszeitenList;
            }
        }
    }
}
