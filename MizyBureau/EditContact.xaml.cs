using System.Windows.Controls;
using System.Windows.Media;
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
            Set_UI();
        }

        C_Conversation Conversation;

        private void Validate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (boxMizyPseudo.Text == string.Empty)
            {
                txtError.Text = "Nom invalide";
                return;
            }

            txtError.Text = "";

            if (txtTitre.Text == string.Empty)
            {
                C_Conversation c = new C_Conversation(boxMizyPseudo.Text, boxFbPseudo.Text == string.Empty ? false : true, boxTwiPseudo.Text == string.Empty ? false : true, boxSlaPseudo.Text == string.Empty ? false : true);
                c.Messages.Clear();
                Home.instance.AddConversation(c);
            }
            else
            {
                Conversation.Name = boxMizyPseudo.Text;
                Conversation.Facebook = boxFbPseudo.Text == string.Empty ? "Hidden" : "Visible";
                Conversation.Twitter = boxTwiPseudo.Text == string.Empty ? "Hidden" : "Visible";
                Conversation.Slack = boxSlaPseudo.Text == string.Empty ? "Hidden" : "Visible";
                Home.instance.EditConversation(Conversation);
            }
        }

        public void OnContact(string name, C_Conversation c = null)
        {
            txtTitre.Text = name;
            if (c != null)
            {
                Conversation = c;
                boxMizyPseudo.Text = c.Name;
                boxFbPseudo.Text = c.Facebook == "Visible" ? "ok" : string.Empty;
                boxTwiPseudo.Text = c.Twitter == "Visible" ? "ok" : string.Empty;
                boxSlaPseudo.Text = c.Slack == "Visible" ? "ok" : string.Empty;
            }
        }

        public void Set_UI()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + UI.Get_Theme() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ui/bgcolor");
            if (node != null)
            {
                Color color = (Color)ColorConverter.ConvertFromString(node.InnerText);
                Page_EditContact.Background = new SolidColorBrush(color);
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/text/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtMizyPseudo.Foreground = txtFbPseudo.Foreground = txtTwiPseudo.Foreground =
                    txtDiscPseudo.Foreground = txtSlaPseudo.Foreground = buttonValidate.Foreground =
                    buttonSlaDel.Foreground = buttonFbDel.Foreground = buttonTwiDel.Foreground =
                    buttonDiscDel.Foreground = buttonMizyDel.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/title/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtTitre.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/box/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                boxMizyPseudo.Foreground = boxFbPseudo.Foreground = boxTwiPseudo.Foreground =
                    boxSlaPseudo.Foreground = boxDiscPseudo.Foreground = brush;
            }
        }
        public void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + Langue.Get_Lang() + ".xml");
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

        private void buttonMizyDel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            boxMizyPseudo.Text = "";
        }

        private void buttonFbDel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            boxFbPseudo.Text = "";
        }

        private void buttonTwiDel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            boxTwiPseudo.Text = "";
        }

        private void buttonDiscDel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            boxDiscPseudo.Text = "";
        }

        private void buttonSlaDel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            boxSlaPseudo.Text = "";
        }

        private void boxMizyPseudo_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (char.IsLetter((char)e.Key)) e.Handled = true;
        }
    }
}
