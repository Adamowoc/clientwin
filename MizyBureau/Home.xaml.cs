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

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {       
        public Home()
        {
            InitializeComponent();
            // load userform (pages)
            _p = new Profile();
            _c = new Conversation();
            // set profile as default page
            this.Content = _p;
        }

        public void Load_Profile()
        {
            this.Content = _p;
        }

        public void Load_Conversation()
        {
            this.Content = _c;
        }

        public void Load_Blank()
        {
            this.Content = null;
        }

        private Profile _p;
        private Conversation _c;
    }
}

