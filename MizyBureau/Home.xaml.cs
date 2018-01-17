using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public static Home instance;

        public bool IsActivated = false;

        private User _user;

        public User GetUser()
        {
            return _user;
        }

        public Home()
        {
            InitializeComponent();
            instance = this;
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
                Menu.Background = new SolidColorBrush(color);
            }
        }
            public void SetHomeWithUser()
        {
            _user = Script.UserManager.instance.ActualUser;
            // load userform (pages)
            _p = new Profile();
            _c = new Conversation();
            _l = new Linking(ref _user);
            _i = new InstantMessagery();
            _e = new EditProfil();

            if (_user._isFacebook == false || _user._isTwitter == false)
                Go_To_Blank();
            else
                Go_To_Profile();
            //Accout_Email.Text = "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        private void Go_To_Conversation(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            contentControl.Content = _c;
            //Accout_Email.Text = "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        public void Go_To_Profile(object sender = null, RoutedEventArgs e = null)
        {
            Sounds.Sound1();
            this.contentControl.Content = _p;
            _p.OnLoadPage();
            //Accout_Email.Text =  "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        public void Go_To_Blank(object sender = null, RoutedEventArgs e = null)
        {
            Sounds.Sound1();
            this.contentControl.Content = _l;
            //Accout_Email.Text =  "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        public void Exitt(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            Script.PageManager.instance.ChangePage(Script.PageManager.ListPage.CONNECTION);
            Sounds.Disco();
        }

        public void Go_To_Messagerie(InstantMessagery i)
        {
            this.contentControl.Content = i;
            //Accout_Email.Text = "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        public void Go_to_Edit_Profile()
        {
            this.contentControl.Content = _e;
            _e.OnLoadEditProfil();
            //Accout_Email.Text = "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        private Linking _l;
        private Profile _p;
        private Conversation _c;
        private InstantMessagery _i;
        private EditProfil _e;
    }
}

