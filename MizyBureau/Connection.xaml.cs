using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Xml;
using System.Windows.Media;

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
            Set_UI();
        }

        private void Set_UI()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + UI.Get_Theme() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ui/bgcolor");
            if (node != null)
            {
                Color color = (Color)ColorConverter.ConvertFromString(node.InnerText);
                coGrid.Background = new SolidColorBrush(color);
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/text/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtConnexion.Foreground = ckboxResterCo.Foreground = connexion.Foreground = inscription.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/box/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                boxIdentifiant.Foreground = pboxPwd.Foreground = brush;
            }
        }

        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + Langue.Get_Lang() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/connection/message");
            if (node != null)
                txtConnexion.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/connection/mail")) != null)
                boxIdentifiant.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/connection/toggle")) != null)
                ckboxResterCo.Content = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/connection/login")) != null)
                connexion.Content = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/connection/signin")) != null)
                inscription.Content = node.InnerText;
        }

        private void Inscription_Load(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.INSCRIPTION);
        }


        private async void Home_LoadAsync(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            if (boxIdentifiant.Text == "Identifiant")
            {
                MessageBox.Show("Veuillez entrer votre email et mot de passe.");
                return;
            }

            User toto = new User(boxIdentifiant.Text, true, true, pboxPwd.Password);

            Script.UserManager.instance.ActualUser = toto;
            Script.PageManager.instance.HomePage.SetHomeWithUser();
            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.HOME);

            string response = await Script.OverHttpClient.instance.CreateSendItemAsync(new Script.SendUser(toto));

            if (string.IsNullOrEmpty(response))
            {
                MessageBox.Show("User incorrect.");
                return;
            }
            Sounds.Connect();

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
