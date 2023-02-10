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
    /// Interaktionslogik für UserView.xaml
    /// </summary>
    public partial class UserView : Page


    {
        private DateTime dt = DateTime.Now;

        private Boolean tempLoggedIn = false;
        public UserView(String name)
        {
            InitializeComponent();
            timer();
            UserWelcomeLabel.Content = name.Length!=0 ?  "Hallo " + name : "Willkommen";
            if (tempLoggedIn)
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
            this.Content = new System.Windows.Controls.Frame().Content = new LoginView();
        }

        private void KommenButton_Click(object sender, RoutedEventArgs e)
        {
            KommenButton.IsEnabled = false;
            GehenButton.IsEnabled = true;
            UserTimeState.Content = "Gekommen um " + DateTime.Now.ToString("HH:mm");
        }

        private void GehenButton_Click(object sender, RoutedEventArgs e)
        {
            KommenButton.IsEnabled = true;
            GehenButton.IsEnabled = false;
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
            UserTimeState.Content = ((DateTime)DatumUser.SelectedDate).ToString("dd.MM.yyyy");
        }
    }
}
