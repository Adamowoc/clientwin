using System;
using System.Windows;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Media;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour Inscription.xaml
    /// </summary>
    public partial class Inscription : Page
    {
        public Inscription()
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
                inscrGrid.Background = new SolidColorBrush(color);
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/text/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtaide.Foreground = btnvalidation.Foreground = btnannulation.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/box/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                boxFirstName.Foreground = boxLastName.Foreground = pboxPwd.Foreground = pboxPwd2.Foreground = boxEmail.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/title/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtConnexion.Foreground = brush;
            }
        }
        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + Langue.Get_Lang() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/inscription/title");
            if (node != null)
                txtConnexion.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/inscription/message")) != null)
                txtaide.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/inscription/firstname")) != null)
                boxFirstName.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/inscription/lastname")) != null)
                boxLastName.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/inscription/mail")) != null)
                boxEmail.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/inscription/validate")) != null)
                btnvalidation.Content = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/inscription/cancel")) != null)
                btnannulation.Content = node.InnerText;
        }
        private void Connection_Load(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.CONNECTION);
        }

        public void Id_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Id_GotFocus;
        }

        public void Pwd1_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox tb = (PasswordBox)sender;
            tb.Password = string.Empty;
            tb.GotFocus -= Pwd1_GotFocus;
        }

        public void Pwd2_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox tb = (PasswordBox)sender;
            tb.Password = string.Empty;
            tb.GotFocus -= Pwd2_GotFocus;
        }

        public void Email_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Email_GotFocus;
        }

        private async void RegisterUser(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            if (Is_data_ok() == false)
            {
                MessageBox.Show(Msg_error);
                return;
            }

            User toto = new User(boxEmail.Text, true, true, pboxPwd.Password, boxFirstName.Text, boxLastName.Text);

            string response = await Script.OverHttpClient.instance.CreateSendItemAsync(new Script.SendNewUser(toto));
            if (string.IsNullOrEmpty(response))
            {
                MessageBox.Show("data incorrect.");
                return;
            }

            MessageBox.Show("Inscription done.");


            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.CONNECTION);
        }

        private bool Is_data_ok()
        {
            try
            {
                bool result_mail = Regex.IsMatch(boxEmail.Text,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                if (result_mail == false)
                {
                    Msg_error = "Mail invalide";
                    return false;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                Msg_error = "Timeout mail";
                return false;
            }

            if (pboxPwd.Password.Equals(pboxPwd2.Password, StringComparison.Ordinal) == false)
            {
                Msg_error = "mot de passe non identique";
                return false;
            }

            return true;
        }

        private string Msg_error;
    }
}
