using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace MizyBureau
{

    public class C_Conversation
    {
        public C_Conversation(string name, bool f = false, bool t = false, bool s = false)
        {
            Name = name;
            Facebook = (f == true) ? "Visible" : "Hidden";
            Twitter = (t == true) ? "Visible" : "Hidden";
            Slack = (s == true) ? "Visible" : "Hidden";
        }

        public C_Conversation(string name, string f, string t, string s)
        {
            Name = name;
            Facebook = f;
            Twitter = t;
            Slack = s;
        }

        public string Name { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Slack { get; set; }

        public List<Message> Messages { get; set; }
    }

    public class Message
    {
        public Message()
        {

        }

        public string Content { get; set; }
        public string Date { get; set; }
        public string Service { get; set; }
        public string Sender { get; set; }
    }

    /// <summary>
    /// Logique d'interaction pour Conversation.xaml
    /// </summary>
    public partial class Conversation : UserControl
    {
        private ObservableCollection<C_Conversation> _conversations;


        public Conversation()
        {
            InitializeComponent();
            _conversations = new ObservableCollection<C_Conversation>()
            {
                new C_Conversation("Benjamin", true, false, true),
            };

            ListConversation.ItemsSource = _conversations;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListConversation.ItemsSource);
            view.Filter = UserFilter;

            Set_Texts();
            Set_UI();
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(boxName.Text))
                return true;
            else
                return ((item as C_Conversation).Name.IndexOf(boxName.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void boxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListConversation.ItemsSource).Refresh();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            int i = ListConversation.SelectedIndex;

            if (i > -1)
            {
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int i = ListConversation.SelectedIndex;

            if (i > -1)
            {
                Home.instance.EditContact(_conversations[i], i);
            }
        }

        public void Delete_and_Add(C_Conversation c, int i)
        {
            _conversations.Add(new C_Conversation(c.Name, c.Facebook, c.Twitter, c.Slack));
            _conversations.RemoveAt(i);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int i = ListConversation.SelectedIndex;

            if (i > -1)
            {
                _conversations.RemoveAt(i);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Home.instance.EditContact(null);
        }

        public void Add_Conversation(C_Conversation c)
        {
            _conversations.Add(c);
        }

        public void Set_UI()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + UI.Get_Theme() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ui/bgcolor");
            if (node != null)
            {
                Color color = (Color)ColorConverter.ConvertFromString(node.InnerText);
                convGrid.Background = Page_Profile.Background = new SolidColorBrush(color);
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/text/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                //   txtUser.Foreground = btnAdd.Foreground = btnEdit.Foreground = btnShow.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/title/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                txtNameTitle.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/secondarycolor")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                // recFirst.Fill = brush;
            }
        }
        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\language.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/conversations/filter");
            if (node != null)
                txtNameTitle.Text = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/conversations/open")) != null)
                btnShow.Content = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/conversations/edit")) != null)
                btnEdit.Content = node.InnerText;
            if ((node = doc.DocumentElement.SelectSingleNode("/mizy/conversations/addcontact")) != null)
                btnAdd.Content = node.InnerText;
        }
    }
}
