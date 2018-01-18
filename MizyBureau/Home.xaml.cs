using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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

        public void Set_UI()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + UI.Get_Theme() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ui/menucolor");
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
            _editContact = new EditContact();

            if (_user._isFacebook == false || _user._isTwitter == false)
                Go_To_Blank();
            else
                Go_To_Profile();
            //Accout_Email.Text = "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        int _tmp;

        public void EditContact(C_Conversation c, int i = 0)
        {
            _tmp = i;
            contentControl.Content = _editContact;
            if (c == null)
                _editContact.OnContact(string.Empty);
            else
                _editContact.OnContact(c.Name, c);
        }

        public void AddConversation(C_Conversation c)
        {
            _c.Add_Conversation(c);
            Go_To_Conversation();
        }

        public void EditConversation(C_Conversation c)
        {
            _c.Delete_and_Add(c, _tmp);
            Go_To_Conversation();
        }

        private void Go_To_Conversation(object sender = null, RoutedEventArgs e = null)
        {
            if (_user._isFacebook == false && _user._isTwitter == false && _user._slack == false)
            {
                Go_To_Blank();
                return;
            }

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

        public void SetNotif(bool b)
        {
            if (b)
            {
                Uri iconUri = new Uri("../../Images/logonotif.png", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
            }
            else
            {
                Uri iconUri = new Uri("../../Images/logo.png", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
            }
        }

        public void Go_To_Messagerie(int i)
        {
            _i.SetMessages(_c._conversations[i].Messages, i);
            this.contentControl.Content = _i;
            //Accout_Email.Text = "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }

        public void Go_to_Edit_Profile()
        {
            this.contentControl.Content = _e;
            _e.OnLoadEditProfil();
            //Accout_Email.Text = "Compte : " + _user._email + " | twitter : " + _user._isTwitter + " | facebook : " + _user._isFacebook;
        }
   
         public void Reload_UI()
         {
           _l.Set_UI();
           _p.Set_UI();
           _c.Set_UI();
           _i.Set_UI();
           _e.Set_UI();
           _editContact.Set_UI();
        }
        public void Reload_Lang()
        {
            _l.Set_Texts();
            _p.Set_Texts();
            _c.Set_Texts();
            _i.Set_Texts();
            _e.Set_Texts();
            _editContact.Set_Texts();
        }


        private Linking _l;
        private Profile _p;
        public Conversation _c;
        private InstantMessagery _i;
        private EditProfil _e;
        private EditContact _editContact;
    }

}

