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
        public Linking(SocketClient sc)
        {
            InitializeComponent();
            _socketClient = sc;
            if (_socketClient._isStateOk == false)
                System.Windows.Application.Current.Shutdown();
        }

        private void connexion_twitter(object sender, RoutedEventArgs e)
        {
            User u = Get_link(boxIdTwi.Text, pboxPwdTwi.Password.ToString(), "twitter");
            if (u == null)
            {
                MessageBox.Show("Le mot de passe ou l'identifiant est incorrect.");
                    return;
            }
        }


        private User Get_link(string email, string pwd, string channel)
        {
            User u = null;
            if (_socketClient.Linking(email, pwd, channel) == true)
            {
                MessageBox.Show("Vous êtes maintenant connecté à " + @channel + " !");
            }
            return u;
        }

        private void connexion_facebook(object sender, RoutedEventArgs e)
        {
            User u = Get_link(boxIdTwi.Text, pboxPwdTwi.Password.ToString(), "facebook");
            if (u == null)
            {
                MessageBox.Show("Le mot de passe ou l'identifiant est incorrect.");
                return;
            }
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
