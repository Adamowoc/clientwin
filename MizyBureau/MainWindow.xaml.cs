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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow instance;

        public bool IsActivated = true;

        public MainWindow()
        {
            InitializeComponent();
            instance = this;
            Script.PageManager toto = new Script.PageManager();
            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.CONNECTION);
            Script.UserManager titi = new Script.UserManager();
        }
    }
}
