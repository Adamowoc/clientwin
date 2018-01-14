﻿using System;
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
using System.Data.SqlClient;
using System.Diagnostics;


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
        }

      private void connexion_twitter(object sender, RoutedEventArgs e)
        {
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

        private void connexion_facebook(object sender, RoutedEventArgs e)
        {
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

        private void OnConnectionSlack(object sender, RoutedEventArgs e)
        {
            Home.instance.GetUser()._slack = true;
        }
    }
}
