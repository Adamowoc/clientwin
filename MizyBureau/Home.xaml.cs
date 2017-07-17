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
using System.Data.SqlClient;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private User _user;

        public Home(User u, SocketClient _socketClient)
        {
            InitializeComponent();
            _user = u;
            // load userform (pages)
            _p = new Profile();
            _c = new Conversation(_socketClient);
            _l = new Linking(_socketClient, ref _user);
            if (_user._isFacebook == false || _user._isTwitter == false)
                this.contentControl.Content = _l;   
            else
                this.contentControl.Content = _p;
            Accout_Email.Text =  "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        private void Go_To_Conversation(object sender, RoutedEventArgs e)
        {
            contentControl.Content = _c;
            Accout_Email.Text = "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        private void Go_To_Profile(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = _p;
            Accout_Email.Text =  "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        private void Go_To_Blank(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = _l;
            Accout_Email.Text =  "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        private Linking _l;
        private Profile _p;
        private Conversation _c;
        private InstantMessagery _i;
    }
}

