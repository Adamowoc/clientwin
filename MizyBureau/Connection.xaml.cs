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

            MessageBox.Show(content);
            Debug.Write(content);
            // if connection ok then

            Get_localdb_user(boxIdentifiant.Text); // try to find user in localdb if can't create it (use to test the db will be remove for beta)

            Window w = Window.GetWindow(this); 
            Home home = new Home();
            App.Current.MainWindow = home;
            w.Close();
            home.Show();
        }


        private void Get_localdb_user(string email)
        {

            using (SqlConnection connection = new SqlConnection(Constants.LocalDB_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM Utilisateur where Mail = '" + email + "'", connection))
                {
                    using (SqlDataReader reader = cmd1.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Debug.Print("user mail : " + email + " find in db ");
                        }
                        else
                        {
                            reader.Close();
                            using (SqlCommand cmd2 = new SqlCommand("INSERT INTO Utilisateur VALUES (@nom, @prenom, @mail)", connection))
                            {
                                cmd2.Parameters.AddWithValue("@nom", DBNull.Value);
                                cmd2.Parameters.AddWithValue("@prenom", DBNull.Value);
                                cmd2.Parameters.AddWithValue("@mail", email);
                                
                             int i = cmd2.ExecuteNonQuery();
                             Debug.Print("add user mail : " + email + " to db " + "\nnb ligne affecté : " + i);
                            }
                        }
                    }
                }
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
