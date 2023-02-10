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
    /// Interaktionslogik für RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void SpeichernButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Content= ((RegisterView)sender).Content;
            ((Button)sender).Background = Brushes.Violet;
        }

        private void AbbruchButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new System.Windows.Controls.Frame().Content = new AdminView();
        }
    }
}
