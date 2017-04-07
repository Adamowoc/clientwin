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
            setRectangle();
            setProfileImg("/Images/fille-logo.png");
            setNameText();
            setMsgText();
            setAppImg("/Images/linkedin-logo.png");

            nb_conv++;
        }

        public void setAppImg(string path)
        {
            System.Uri imguri = new Uri(path, UriKind.Relative);
            BitmapImage ni = new BitmapImage(imguri);
            Image img = new Image();
            img.Source = ni;
            img.Margin = new Thickness(1129, (nb_conv * 100) + 37, 0, 0);
            img.Height = 50;
            img.SetValue(Panel.ZIndexProperty, 3);

            Page_Profile.Children.Add(img);
        }

        public void setMsgText()
        {
            TextBlock new_txt = new TextBlock();

            new_txt.Margin = new Thickness(159, (nb_conv * 100) + 64, 0, 0);
            new_txt.SetValue(Panel.ZIndexProperty, 3);
            new_txt.Text = "Ca m'a fait plaisir de te reparler ! A bientôt.";
            new_txt.Foreground = new SolidColorBrush(Color.FromRgb(64, 164, 145));
            new_txt.FontSize = 20;
            Page_Profile.Children.Add(new_txt);
        }

        public void setNameText()
        {
            TextBlock new_txt = new TextBlock();

            new_txt.Margin = new Thickness(130, (nb_conv * 100) + 10, 0, 0);
            new_txt.SetValue(Panel.ZIndexProperty, 3);
            new_txt.Text = "Ana Khonda";
            new_txt.Foreground = new SolidColorBrush(Color.FromRgb(64, 164, 145));
            new_txt.FontSize = 40;
            Page_Profile.Children.Add(new_txt);
         }

        public void setProfileImg(string path)
        {
            System.Uri imguri = new Uri(path, UriKind.Relative);
            BitmapImage ni = new BitmapImage(imguri);
            Image img = new Image();
            img.Source = ni;
            img.Margin = new Thickness(3, (nb_conv * 100), 0, 0);
            img.Height = 107;
            img.Width = 120;
            img.SetValue(Panel.ZIndexProperty, 3);

            Page_Profile.Children.Add(img);
        }

        public void setRectangle()
        {
            Rectangle new_rec = new Rectangle();

            new_rec.Height = 100;
            new_rec.Width = 1200;
            new_rec.Margin = new Thickness(0, (nb_conv * 100), 0, 0);
            new_rec.SetValue(Panel.ZIndexProperty, 2);
            if (nb_conv % 2 == 1)
                new_rec.Fill = new SolidColorBrush(Color.FromRgb(5, 11, 15));
            else
                new_rec.Fill = new SolidColorBrush(Color.FromRgb(47, 54, 64));

            Page_Profile.Children.Add(new_rec);
        }
    }
}
