
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour AddContact.xaml
    /// </summary>
    public partial class AddContact : UserControl
    {
        public AddContact()
        {
            InitializeComponent();
            Set_Texts();
        }
        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\language.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/addcontact/mizy");
            if (node != null)
                txtMizyPseudo.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/addcontact/fb")) != null)
                txtFbPseudo.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/addcontact/twitter")) != null)
                txtTwiPseudo.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/addcontact/discord")) != null)
                txtDiscPseudo.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/addcontact/slack")) != null)
                txtSlaPseudo.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/addcontact/title")) != null)
                txtTitre.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/addcontact/message")) != null)
                txtConnexion.Text = node.InnerText;
        }

        private void Create_Friend(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
        }
    }
}
