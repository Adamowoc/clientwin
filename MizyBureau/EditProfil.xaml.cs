using System.Windows;
using System.Windows.Controls;
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
