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
        public T_Conversation(string name, int nb, int idC, int idF) : this()
        {
            _nb_Conversation = nb;
            _IdConversation = idC;
            _IdFriend = idF;
            _isShow = false;
        }

        public string _name { get; set; }
        public int _nb_Conversation { get; set; }
        public int _IdConversation { get; set; }
        public int _IdFriend { get; set; }
        public bool _isShow { get; set; }
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
            _conversations = new List<T_Conversation>();
            using (SqlConnection connection = new SqlConnection(Constants.LocalDB_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd1 = new SqlCommand(@"SELECT * FROM ConversationUtilisateurAmi where IdUtilisateur = '" + _user.GetId() + "'", connection))
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
                using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM Ami where IdAmi = '" + idFriend + "'", connection))
                {
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                        }
                    }
                }
            }
            Show_Conversation();
        }

        private void ShowConv(T_Conversation conv) // add a conv to xaml (get placement of conv with conv.nb_conv)
        {
            if (conv._isShow == false)
            {
                conv._isShow = true;
                setRectangle(conv._nb_Conversation);
                setProfileImg("/Images/fille-logo.png", conv._nb_Conversation);
                setNameText(conv._name, conv._nb_Conversation);
                setAppImg("/Images/linkedin-logo.png", conv._nb_Conversation);
            }
        }

        private void addConv(object sender, RoutedEventArgs e)
        {

            /*setRectangle();
            setProfileImg("/Images/fille-logo.png");
            setNameText(NewFriend.Text);
            setAppImg("/Images/linkedin-logo.png");*/

            // get name friend from textbox
            // if friend name in list conv 
            //do nothing
            // else 
            //add textbox name to friend
            //get new friend id
            //add to conv a conv with userid and the newfriendid
            //get new conv id
            //add conv to conv list
            _nb_conv++;
            //show new conv
        } // tips ou un truc bien a faire : creer une classe db_request et ajouter les fonction de get, set, add, delete de la db dedans)

        private void setAppImg(string path, int nb)
        {
            System.Uri imguri = new Uri(path, UriKind.Relative);
            BitmapImage ni = new BitmapImage(imguri);
            Image img = new Image();
            img.Source = ni;
            img.Margin = new Thickness(1129, (nb * 100) + 37, 0, 0);
            img.Height = 50;
            img.SetValue(Panel.ZIndexProperty, 3);

            Page_Profile.Children.Add(img);
        }


        private void setNameText(string name, int nb)
        {
            TextBlock new_txt = new TextBlock();

            new_txt.Margin = new Thickness(130, (nb * 100) + 10, 0, 0);
            new_txt.SetValue(Panel.ZIndexProperty, 3);
            new_txt.Text = name;
            new_txt.Foreground = new SolidColorBrush(Color.FromRgb(64, 164, 145));
            new_txt.FontSize = 40;
            Page_Profile.Children.Add(new_txt);
        }

        private void setProfileImg(string path, int nb)
        {
            System.Uri imguri = new Uri(path, UriKind.Relative);
            BitmapImage ni = new BitmapImage(imguri);
            Image img = new Image();
            img.Source = ni;
            img.Margin = new Thickness(3, (nb * 100), 0, 0);
            img.Height = 107;
            img.Width = 120;
            img.SetValue(Panel.ZIndexProperty, 3);

            Page_Profile.Children.Add(img);
        }

        public void setRectangle(int nb)
        {
            Rectangle new_rec = new Rectangle();

            new_rec.Height = 100;
            new_rec.Width = 1200;
            new_rec.Margin = new Thickness(0, (nb * 100), 0, 0);
            new_rec.SetValue(Panel.ZIndexProperty, 2);
            if (nb % 2 == 1)
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

        public void Show_Conversation()
        {
            foreach (var conv in _conversations)
            {
                setRectangle(conv._nb_Conversation);
                setProfileImg("/Images/fille-logo.png", conv._nb_Conversation);
                setNameText(conv._name, conv._nb_Conversation);
                setAppImg("/Images/linkedin-logo.png", conv._nb_Conversation);
            }
        }
    }
}
