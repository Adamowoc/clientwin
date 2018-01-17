using System.Windows.Controls;
using System.Xml;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour EditContact.xaml
    /// </summary>
    public partial class EditContact : UserControl
    {
        public EditContact()
        {
            InitializeComponent();
            Set_Texts();
        }
        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\language.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/editcontact/mizy");
            if (node != null)
                txtMizyPseudo.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/editcontact/fb")) != null)
                txtFbPseudo.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/editcontact/twitter")) != null)
                txtTwiPseudo.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/editcontact/discord")) != null)
                txtDiscPseudo.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/editcontact/slack")) != null)
                txtSlaPseudo.Text = node.InnerText;
        }
        private void boxMizyPseudo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
