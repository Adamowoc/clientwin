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

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour Conversation.xaml
    /// </summary>
    public partial class Conversation : UserControl
    {
        public Conversation()
        {
            InitializeComponent();
        }

        private void Go_To_Conversation(object sender, RoutedEventArgs e)
        {
            Home parentWindow = (Home)Window.GetWindow(this);

            parentWindow.Load_Conversation();
            return;
        }

        private void Go_To_Profile(object sender, RoutedEventArgs e)
        {
            Home parentWindow = (Home)Window.GetWindow(this);

            parentWindow.Load_Profile();
            return;
        }

        private void Go_To_Blank(object sender, RoutedEventArgs e)
        {
            Home parentWindow = (Home)Window.GetWindow(this);

            parentWindow.Load_Blank();
            return;
        }
    }
}
