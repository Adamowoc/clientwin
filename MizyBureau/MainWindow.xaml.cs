using System.Windows;
using System.Xml;

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
            if (UI.is_theme_set == false)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\user.xml");
                XmlNode node = doc.DocumentElement.SelectSingleNode("/user/theme");
                if (node != null)
                {
                    UI.Set_Theme(node.InnerText);
                }
                UI.is_theme_set = true;
            }
            if (Langue.is_lang_set == false)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\user.xml");
                XmlNode node = doc.DocumentElement.SelectSingleNode("/user/language");
                if (node != null)
                {
                    Langue.Set_Lang(node.InnerText);
                }
                Langue.is_lang_set = true;
            }
            InitializeComponent();
            instance = this;
            Script.PageManager toto = new Script.PageManager();
            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.CONNECTION);
            Script.UserManager titi = new Script.UserManager();
            Script.OverHttpClient o = new Script.OverHttpClient();
        }
    }
}
