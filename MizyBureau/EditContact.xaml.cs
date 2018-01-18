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
        private void Set_UI()
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
