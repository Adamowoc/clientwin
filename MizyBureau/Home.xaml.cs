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
        public Home()
        {
            InitializeComponent();
            // load userform (pages)
            _p = new Profile();
            _c = new Conversation();
            // set profile as default page
            this.contentControl.Content = _p;
        }


        private void Go_To_Conversation(object sender, RoutedEventArgs e)
        {
            contentControl.Content = _c;
        }

        private void Go_To_Profile(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = _p;
        }

        private void Go_To_Blank(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = null;
        }

        private Profile _p;
        private Conversation _c;
    }
}

