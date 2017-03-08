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

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        /* private void Conv_Load(object sender, RoutedEventArgs e)
         {
             this.NavigationService.Navigate(new Uri("Conversations.xaml", UriKind.Relative));
         }*/
        public Home()
        {
            InitializeComponent();
            _p = new Profile();
            this.Content = _p;
        }

        public void Load_Profile()
        {
            this.Content = _p;
        }

        public void Load_Conversation()
        {
            this.Content = null;
        }

        private Profile _p;
    }
}

