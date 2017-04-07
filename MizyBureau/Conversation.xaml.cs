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
        int nb_conv = 1;

        public Conversation()
        {
            InitializeComponent();
        }
       
        public void addConv(object sender, RoutedEventArgs e)
        {
            Rectangle new_rec = new Rectangle();
            new_rec.Height = 100;
            new_rec.Width = 1200;
            new_rec.Margin = new Thickness(0, (nb_conv * 100), 0, 0);
            new_rec.SetValue(Panel.ZIndexProperty, 2);
            //Conversation.Page_Profile.SetZIndex(new_rec, 10);
            if (nb_conv % 2 == 1)
                new_rec.Fill = new SolidColorBrush(Color.FromRgb(5, 11, 15));
            else
                new_rec.Fill = new SolidColorBrush(Color.FromRgb(47, 54, 64));
            nb_conv++;
            Page_Profile.Children.Add(new_rec);
        }
    }
}
