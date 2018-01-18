using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace MizyBureau
{
    /// <summary>
    /// Interaction logic for EditProfil.xaml
    /// </summary>
    public partial class EditProfil : UserControl
    {
        public EditProfil()
        {
            InitializeComponent();
            Set_Texts();
            Set_UI();
        }
        public void Set_UI()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + UI.Get_Theme() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ui/bgcolor");
            if (node != null)
            {
                Color color = (Color)ColorConverter.ConvertFromString(node.InnerText);
                Page_EditProfile.Background = new SolidColorBrush(color);
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/text/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtFirstNameTitle.Foreground = txtLastnameTitle.Foreground =
                btnlight.Foreground = btndark.Foreground =
                btnfr.Foreground = btnen.Foreground = buttonValidate.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/box/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                boxName.Foreground = boxLastName.Foreground = boxNum.Foreground = 
                    boxMail.Foreground = boxAniv.Foreground = brush;
            }
        }
        public void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + Langue.Get_Lang() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/editprofile/firstname");
            if (node != null)
                txtFirstNameTitle.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/editprofile/lastname")) != null)
                txtLastnameTitle.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/editprofile/lighttheme")) != null)
                btnlight.Content = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/editprofile/darktheme")) != null)
                btndark.Content = node.InnerText;
        }
        private void Set_Light(object sender, RoutedEventArgs e)
        {
            UI.Set_Theme("light");
            Home.instance.Set_UI();
            Home.instance.Reload_UI();
        }
        private void Set_Dark(object sender, RoutedEventArgs e)
        {
            UI.Set_Theme("dark");
            Home.instance.Set_UI();
            Home.instance.Reload_UI();
        }
        private void Set_Fr(object sender, RoutedEventArgs e)
        {
            Langue.Set_Lang("fr");
            Home.instance.Reload_Lang();
        }
        private void Set_En(object sender, RoutedEventArgs e)
        {
            Langue.Set_Lang("en");
            Home.instance.Reload_Lang();
        }
        public void OnLoadEditProfil()
        {
            User u = Home.instance.GetUser();

            boxName.Text = u._firstname;
            boxLastName.Text = u._lastname;
            boxMail.Text = u._email;
        }

        public void OnClickValidate(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            User u = Home.instance.GetUser();

            u._firstname = boxName.Text;
            u._lastname = boxLastName.Text;
            u._email = boxMail.Text;
            Home.instance.Go_To_Profile();
        }
    }
}
