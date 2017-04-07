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
using System.Data.SqlClient;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour InstantMessagery.xaml
    /// </summary>
    public partial class InstantMessagery : UserControl
    {
        public InstantMessagery()
        {
            InitializeComponent();

           
        }
        private void Send_message(object sender, RoutedEventArgs e)
        {
            TextBlock new_message = new TextBlock();
            new_message.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x05, 0x0B, 0x0F));
            new_message.Foreground = Brushes.AntiqueWhite;
            new_message.Text = My_message.Text;
            My_message.Text = "";
            Message_view.Children.Add(new_message);
        }
    }
}
