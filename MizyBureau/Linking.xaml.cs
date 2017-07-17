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

   

    /// <summary>
    /// Logique d'interaction pour Linking.xaml
    /// </summary>
    public partial class Linking : UserControl
    {
        private SocketClient _socketClient;
        private User _user;
        public Linking(SocketClient sc, ref User user)
        {
            InitializeComponent();
            _socketClient = sc;
            _user = user;
            if (_socketClient._isStateOk == false)
                System.Windows.Application.Current.Shutdown();
        }

        private void connexion_twitter(object sender, RoutedEventArgs e)
        {
            if (Get_link(boxIdTwi.Text, pboxPwdTwi.Password.ToString(), "twitter") == false)
            {
                MessageBox.Show("Link Twitter fail");
            }
            else
            {
                _user._isTwitter = true;
            }
        }


        private void connexion_facebook(object sender, RoutedEventArgs e)
        {
            if (Get_link(boxIdTwi.Text, pboxPwdTwi.Password.ToString(), "facebook") == false)
            {
                MessageBox.Show("Le mot de passe ou l'identifiant est incorrect.");
            }
            else
            {
                _user._isFacebook = true;
            }
        }

        private bool Get_link(string email, string pwd, string channel)
        {
            if (_socketClient.Linking(email, pwd, channel) == true)
            {
                MessageBox.Show("Vous êtes maintenant connecté à " + @channel + " !");
                return true;
            }
            return false;
        }

        public void Pseudo_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Pseudo_GotFocus;
        }

        public void Pwd_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox tb = (PasswordBox)sender;
            tb.Password = string.Empty;
            tb.GotFocus -= Pwd_GotFocus;
        }

    }
}
