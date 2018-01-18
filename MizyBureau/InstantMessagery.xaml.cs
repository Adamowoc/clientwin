using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Windows.Documents;
using System.Xml;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour InstantMessagery.xaml
    /// </summary>
    public partial class InstantMessagery : UserControl
    {
        public ObservableCollection<Message> _messages;

        public InstantMessagery()
        {
            InitializeComponent();
            Set_Texts();
            Set_UI();
            _messages = new ObservableCollection<Message>();
            ListMessage.ItemsSource = _messages;
        }

        public void SetMessages(List<Message> messages)
        {
            _messages.Clear();

            foreach (Message m in messages)
            {
                _messages.Add(new Message(m.Content, m.Date, m.Sender, m.Service));
            }
        }

        private void Send_message(object sender, RoutedEventArgs e)
        {
            Sounds.Sound1();
            if (My_message.Text == "")
                return;

            string service = string.Empty;
            User u = Home.instance.GetUser();

            if (u._isFacebook == true)
            {
                service = "Facebook";
            }
            else if (u._isTwitter == true)
            {
                service = "Twitter";
            }
            else if (u._slack == true)
            {
                service = "Slack";
            }

            _messages.Add(new Message(My_message.Text, DateTime.Now.ToString(), "depuis", service));
        }

        // LINKS
        private void HandleRequestNavigate(object sender, RequestNavigateEventArgs args) 
        {
            System.Diagnostics.Process.Start(args.Uri.ToString());
        }
        public TextBlock FindLinks(TextBlock textBlock1)
        {
            Uri uriResult;
            string txt = textBlock1.Text;
            textBlock1.Text = "";
            foreach (string word in txt.Split(' '))
            {
                Run run = new Run(word); Debug.Write("result : " + Uri.TryCreate(word, UriKind.Absolute, out uriResult));
                if (Uri.TryCreate(word, UriKind.Absolute, out uriResult))
                {

                    Hyperlink hyperlink = new Hyperlink(run)
                    {
                        NavigateUri = new Uri(word)
                    };
                    hyperlink.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(HandleRequestNavigate);
                    textBlock1.Inlines.Add(hyperlink);
                }
                else
                    textBlock1.Inlines.Add(run);
                textBlock1.Inlines.Add(" ");
            }
            return (textBlock1);
        }

        public void Set_UI()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + UI.Get_Theme() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ui/bgcolor");
            if (node != null)
            {
                Color color = (Color)ColorConverter.ConvertFromString(node.InnerText);
             //   messGrid.Background = My_message.Background = btnSend.Background = messFirst.Background = new SolidColorBrush(color);
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/text/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                btnSend.Foreground = My_message.Foreground = btnSend.Foreground = brush;
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/title/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
            //    messFirst.Foreground = brush;
            }
        }

        public void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + Langue.Get_Lang() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/messagery/send");
            if (node != null)
                btnSend.Content = node.InnerText;
        }
    }
}
