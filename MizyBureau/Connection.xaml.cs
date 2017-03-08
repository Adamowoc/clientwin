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
using RestSharp;
using System.Diagnostics;


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
            this.NavigationService.Navigate(new Uri("Inscription.xaml", UriKind.Relative));
        }

        private void Home_Load(object sender, RoutedEventArgs e)
        {
            if (boxIdentifiant.Text == "Identifiant" || pboxPwd.Password.ToString() == "Password")
            {
                MessageBox.Show("Veuillez entrer votre email et mot de passe.");
                return;
            }

            var client = new RestClient("https://dev.api.mizy.io/");
            var request = new RestRequest("auth/login", Method.POST);

            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(new { email = boxIdentifiant.Text, password = pboxPwd.Password.ToString() });
            
            IRestResponse response = client.Execute(request); // execute the request
            var error = response.ErrorException;
            var content = response.Content; // raw content as string

            Debug.Write(content);
            // if connection ok then

            Window w = Window.GetWindow(this); 
            Home home = new Home();
            App.Current.MainWindow = home;
            w.Close();
            home.Show();
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
