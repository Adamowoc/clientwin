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
using System.Diagnostics;


namespace MizyBureau
{

    public struct T_Conversation
    {
        public T_Conversation(int nb, int idC, int idF) : this()
        {
            _nb_Conversation = nb;
            _IdConversation = idC;
            _IdFriend = idF;
        }

        int _nb_Conversation { get; set; }
        int _IdConversation { get; set; }
        int _IdFriend { get; set; }
    }

    /// <summary>
    /// Logique d'interaction pour Conversation.xaml
    /// </summary>
    public partial class Conversation : UserControl
    {
        int _nb_conv = 1;
        User _user;
        List<T_Conversation> _conversations;
        public Conversation(User u)
        {
            InitializeComponent();
            _user = u;
            using (SqlConnection connection = new SqlConnection(Constants.LocalDB_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM Conversation_Utilisateur/Ami where IdUtilisateur = '" + _user.GetId() +"'", connection))
                {
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AddConvSQL(reader.GetInt32(1), reader.GetInt32(2));
                            _nb_conv++;
                        }
                    }
                }
            }
        }

        private void AddConvSQL(int idConversqtion, int idFriend)
        {
            using (SqlConnection connection = new SqlConnection(Constants.LocalDB_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM Conversation_Utilisateur/Ami where IdUtilisateur = '" + u.GetId() + "'", connection))
                {
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AddConvSQL(reader.GetInt32(1), reader.GetInt32(2));
                            _nb_conv++;
                        }
                    }
                }
            }
        }

        private void addConv(object sender, RoutedEventArgs e)
        {
            setRectangle();
            setProfileImg("/Images/fille-logo.png");
            setNameText(NewFriend.Text);
            setAppImg("/Images/linkedin-logo.png");

            _nb_conv++;
        }

        private void setAppImg(string path)
        {
            System.Uri imguri = new Uri(path, UriKind.Relative);
            BitmapImage ni = new BitmapImage(imguri);
            Image img = new Image();
            img.Source = ni;
            img.Margin = new Thickness(1129, (_nb_conv * 100) + 37, 0, 0);
            img.Height = 50;
            img.SetValue(Panel.ZIndexProperty, 3);

            Page_Profile.Children.Add(img);
        }


        private void setNameText(string name)
        {
            TextBlock new_txt = new TextBlock();

            new_txt.Margin = new Thickness(130, (_nb_conv * 100) + 10, 0, 0);
            new_txt.SetValue(Panel.ZIndexProperty, 3);
            new_txt.Text = name;
            new_txt.Foreground = new SolidColorBrush(Color.FromRgb(64, 164, 145));
            new_txt.FontSize = 40;
            Page_Profile.Children.Add(new_txt);
        }

        private void setProfileImg(string path)
        {
            System.Uri imguri = new Uri(path, UriKind.Relative);
            BitmapImage ni = new BitmapImage(imguri);
            Image img = new Image();
            img.Source = ni;
            img.Margin = new Thickness(3, (_nb_conv * 100), 0, 0);
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
            new_rec.Margin = new Thickness(0, (_nb_conv * 100), 0, 0);
            new_rec.SetValue(Panel.ZIndexProperty, 2);
            if (_nb_conv % 2 == 1)
                new_rec.Fill = new SolidColorBrush(Color.FromRgb(5, 11, 15));
            else
                new_rec.Fill = new SolidColorBrush(Color.FromRgb(47, 54, 64));

            Page_Profile.Children.Add(new_rec);
        }

        public void NewFriend_Focus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= NewFriend_Focus;
        }
    }
}
