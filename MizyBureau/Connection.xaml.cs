using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using RestSharp;
using System.Diagnostics;
using System.Data.SqlClient;




namespace MizyBureau
{

    /// <summary>
    /// Logique d'interaction pour Connection.xaml
    /// </summary>
    public partial class Connection : Page
    {
        private SocketClient _socketClient;

        public Connection(SocketClient sc)
        {
            InitializeComponent();
            _socketClient = sc;
            if (_socketClient._isStateOk == false)
               System.Windows.Application.Current.Shutdown();
        }

        private void Inscription_Load(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Inscription(_socketClient));
            return;
        }

       private void Home_Load(object sender, RoutedEventArgs e)
        {
            Window w = Window.GetWindow(this);
            User t = new User("toto", true, true);
            SocketClient s = new SocketClient();
            s._isStateOk = true;
            Home home = new Home(t, s);

            App.Current.MainWindow = home;
            w.Close();
            home.Show();
        }


        private User Get_user(string email, string pwd)
        {
            User u = null;
            bool twitter = false;
            bool facebook = false;
            if (_socketClient.Login(email, pwd, ref twitter, ref facebook ) == true)
            {
                u = new User(email, twitter, facebook);
            }
            return u;
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
