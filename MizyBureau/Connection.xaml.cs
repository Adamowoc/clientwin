using System;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Xml;

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
            Set_Texts();
        }
        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\Manon\Pictures\School\EIP\GITHUB\Mizy Sounds\clientwin\MizyBureau\language.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/connection/message");
            txtConnexion.Text = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/mizy/connection/mail");
            boxIdentifiant.Text = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/mizy/connection/toggle");
            ckboxResterCo.Content = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/mizy/connection/login");
            connexion.Content = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/mizy/connection/signin");
            inscription.Content = node.InnerText;
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

            User toto = new User(boxIdentifiant.Text, true, true, pboxPwd.Password);

            //Script.UserManager.instance.ActualUser = toto;
            //Script.PageManager.instance.HomePage.SetHomeWithUser();
            //Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.HOME);

            string response = await Script.OverHttpClient.instance.CreateSendItemAsync(new Script.SendUser(toto));

            if (string.IsNullOrEmpty(response))
            {
                MessageBox.Show("User incorrect.");
                return;
            }

            Debug.WriteLine(response);

            dynamic test = JsonConvert.DeserializeObject(response);
           
            toto._token = test.auth.token;
            toto._lastname = test.user.lastname;
            toto._firstname = test.user.firstname;


            Script.UserManager.instance.ActualUser = toto;
            Script.PageManager.instance.HomePage.SetHomeWithUser();
            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.HOME);
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
