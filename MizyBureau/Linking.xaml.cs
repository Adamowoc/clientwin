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
            public Linking()
            {
                InitializeComponent();
            }

            private void connexion_twitter(object sender, RoutedEventArgs e)
            {
                return;
            }
            private void connexion_facebook(object sender, RoutedEventArgs e)
            {
                return;
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
    }
}
