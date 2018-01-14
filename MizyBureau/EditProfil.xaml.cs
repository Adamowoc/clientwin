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
            User u = Home.instance.GetUser();

            u._firstname = boxName.Text;
            u._lastname = boxLastName.Text;
            u._email = boxMail.Text;
            Home.instance.Go_To_Profile();
        }
    }
}
