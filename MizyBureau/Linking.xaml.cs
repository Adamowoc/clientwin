using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Xml;
using System.Windows.Media;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour Linking.xaml
    /// </summary>
    public partial class Linking : UserControl
    {
        private User _user;

        public Linking(ref User user)
        {
            InitializeComponent();
            _user = user;
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
                Page_Linking.Background = new SolidColorBrush(color);
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/text/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtExpliTwi.Foreground = getLinkTwi.Foreground = validateTwi.Foreground =
                    coFb.Foreground = coDisc.Foreground = coSlack.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/title/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtTw.Foreground = txtFb.Foreground = txtDisc.Foreground = txtSlack.Foreground =
                    txtName.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/box/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                boxPINTwi.Foreground = boxIdFB.Foreground = pboxPwdFb.Foreground =
                    boxIdDisc.Foreground = pboxPwdDisc.Foreground =
                    boxIdSlack.Foreground = pboxPwdSlack.Foreground = brush;
            }
        }
        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\language.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/accountslinking/title");
            if (node != null)
                txtName.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/accountslinking/twittermessage")) != null)
                txtExpliTwi.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/accountslinking/getlink")) != null)
                getLinkTwi.Content = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/accountslinking/enterpin")) != null)
                boxPINTwi.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/accountslinking/validate")) != null)
                validateTwi.Content = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/accountslinking/id")) != null)
            {
                boxIdFB.Text = node.InnerText;
                boxIdDisc.Text = node.InnerText;
                boxIdSlack.Text = node.InnerText;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/accountslinking/connect")) != null)
            {
                coFb.Content = node.InnerText;
                coDisc.Content = node.InnerText;
                coSlack.Content = node.InnerText;
            }
        }
            private void connexion_twitter(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            // string url = "void";
            //if (_socketClient.Linking_twitter(ref url, _user._email) == false)
            //{
            //   MessageBox.Show("Link Twitter fail");
            //}
            //else
            //{
            //  txtUrl.Text = url;
            //System.Uri uri = new System.Uri(url);
            //hyper.NavigateUri = uri;
            //}
        }

      private void validate_twitter(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            //if (_socketClient.Validate_twitter_PIN(boxPINTwi.Text, _user._email) == false)
            //{
            //    MessageBox.Show("Le code PIN est incorrect.");
            //}
            //else
            //{
            //    MessageBox.Show("Vous êtes maintenant connecté à Twitter !");
            //    _user._isTwitter = true;
            //}

            Home.instance.GetUser()._twitter = true;
        }

        private void Connexion_Facebook(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            Home.instance.GetUser()._facebook = true;

            //if (Get_link_fb(boxIdFB.Text, pboxPwdFb.Password.ToString(), "facebook") == false)
            //{
            //    MessageBox.Show("Le mot de passe ou l'identifiant est incorrect.");
            //}
            //else
            //{
            //    _user._isFacebook = true;
            //}
        }
        private void Connexion_Discord(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
        }
        private void Connexion_Slack(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            Home.instance.GetUser()._slack = true;
        }

        private bool Get_link_fb(string email, string pwd, string channel)
        {
            //if (_socketClient.Linking_fb(_user._email, email, pwd) == true)
            //{
            //    MessageBox.Show("Vous êtes maintenant connecté à " + @channel + " !");
            //    return true;
            //}
            return false;
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
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

    }
}
