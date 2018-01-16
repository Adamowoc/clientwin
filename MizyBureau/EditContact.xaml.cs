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
