using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestSharp;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        }

        private void Connection_Load(object sender, RoutedEventArgs e)
        {
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
