using System.Windows;

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
            Script.OverHttpClient o = new Script.OverHttpClient();
        }
    }
}
