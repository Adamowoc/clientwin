using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
            Set_Texts();
            Set_UI();
        }
        public void Set_UI()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + UI.Get_Theme() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ui/bgcolor");
            if (node != null)
            {
                Color color = (Color)ColorConverter.ConvertFromString(node.InnerText);
                My_profile.Background = Page_Profil.Background = new SolidColorBrush(color);
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/text/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtSmsName.Foreground = txtEmail.Foreground = txtAnniv.Foreground = btnModify.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/title/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtName.Foreground = txtAccounts.Foreground = brush;
            }
        }
        public void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + Langue.Get_Lang() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/profile/accounts");
            if (node != null)
                txtAccounts.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/profile/modify")) != null)
                btnModify.Content = node.InnerText;
        }
        private void buttonModify_Click(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            Home.instance.Go_to_Edit_Profile();
        }

        public void OnLoadPage()
        {
            User u = Home.instance.GetUser();

            txtName.Text = u._firstname + " " + u._lastname;

            txtEmail.Text = u._email;

            if (u._twitter == false)
                imgTwitter.Visibility = Visibility.Hidden;
            else
                imgTwitter.Visibility = Visibility.Visible;

            if (u._facebook == false)
                imgSlack.Visibility = Visibility.Hidden;
            else
                imgSlack.Visibility = Visibility.Visible;

            if (u._slack == false)
                imgTwitter.Visibility = Visibility.Hidden;
            else
                imgTwitter.Visibility = Visibility.Visible;
        }
    }
}
