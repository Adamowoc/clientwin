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
        public Connection()
        {
            InitializeComponent();
        }

        private void Inscription_Load(object sender, RoutedEventArgs e)
        {
            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.INSCRIPTION);
        }

        private async void Home_LoadAsync(object sender, RoutedEventArgs e)
        {
            if (boxIdentifiant.Text == "Identifiant" || pboxPwd.Password == "Password")
            {
                MessageBox.Show("Veuillez entrer votre email et mot de passe.");
                return;
            }

<<<<<<< HEAD
            User toto = new User(boxIdentifiant.Text, true, true, pboxPwd.Password);

            var tutu = await Script.OverHttpClient.instance.CreateSendItemAsync(new Script.SendUser(toto));
            if (tutu == null)
=======
            User u = Get_user(boxIdentifiant.Text, pboxPwd.Password.ToString());

            if (u == null)
>>>>>>> master
            {
                MessageBox.Show("User incorrect.");
                return;
            }

<<<<<<< HEAD
=======

            //if ((User u = HTTPClient.instance.GetUser()) != null)
            //Script.UserManager.instance.ActualUser = u
            User toto = new User(boxIdentifiant.Text, true, true);  /// waiting for a true server

>>>>>>> master
            Script.UserManager.instance.ActualUser = toto;
            Script.PageManager.instance.HomePage.SetHomeWithUser();
            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.HOME);
            return;
<<<<<<< HEAD
=======



            //Window w = Window.GetWindow(this);
            //User t = new User("toto", true, true);
            //SocketClient s = new SocketClient();
            //s._isStateOk = true;
            //Home home = new Home(u);

            //App.Current.MainWindow = home;
            //w.Close();
            //home.Show();
>>>>>>> master
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
