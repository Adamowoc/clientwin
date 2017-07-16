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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {       
        public Home(User u, SocketClient _socketClient)
        {
            InitializeComponent();
            // load userform (pages)
            _p = new Profile();
            _c = new Conversation(u);
            _l = new Linking(_socketClient);
            // set profile as default page
            this.contentControl.Content = _l;
            _sqlstringconnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MizyDB.mdf;Integrated Security=True";
            Accout_Email.Text +=  "\n" + u.GetEmail();
        }

        private void Go_To_Conversation(object sender, RoutedEventArgs e)
        {
            contentControl.Content = _c;
        }

        private void Go_To_Profile(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = _p;
        }

        private void Go_To_Blank(object sender, RoutedEventArgs e)
        {
            if (_i == null)
                _i = new InstantMessagery(1, _sqlstringconnection);
            

            this.contentControl.Content = _i;
        }

        private Linking _l;
        private Profile _p;
        private Conversation _c;
        private InstantMessagery _i;
        private string  _sqlstringconnection;
    }
}

