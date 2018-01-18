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
        private void Set_UI()
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
                txtFirstNameTitle.Foreground = txtLastnameTitle.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/box/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                boxName.Foreground = boxLastName.Foreground = boxNum.Foreground = 
                    boxMail.Foreground = boxAniv.Foreground = brush;
            }
        }
        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\language.xml");
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
            Home.instance.Go_to_Edit_Profile();
        }
        private void Set_Dark(object sender, RoutedEventArgs e)
        {
            UI.Set_Theme("dark");
            Home.instance.Go_to_Edit_Profile();
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
