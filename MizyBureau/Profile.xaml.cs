using System.Windows;
using System.Windows.Controls;
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
        }

        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\language.xml");
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
