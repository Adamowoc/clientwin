using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Navigation;
using System.Windows.Documents;
using System.Xml;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour InstantMessagery.xaml
    /// </summary>
    public partial class InstantMessagery : UserControl
    {
        public InstantMessagery()
        {
            InitializeComponent();
            Set_Texts();
            Set_UI();
            //_stringslqconnection = s;
            //_userid = i;
            //Construct_message_view();
        }
        public void Set_UI()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + UI.Get_Theme() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ui/bgcolor");
            if (node != null)
            {
                Color color = (Color)ColorConverter.ConvertFromString(node.InnerText);
                messGrid.Background = My_message.Background = btnSend.Background = messFirst.Background = new SolidColorBrush(color);
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
                messFirst.Foreground = brush;
            }
        }
        private void Set_Texts()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\language.xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/mizy/messagery/send");
            if (node != null)
                btnSend.Content = node.InnerText;
        }
            //private void Construct_message_view()
            //{
            //    SqlConnection sqlConnection1 = new SqlConnection(_stringslqconnection);
            //    SqlCommand cmd = new SqlCommand();
            //    SqlDataReader reader;

            //    cmd.CommandText = "SELECT * FROM Messagerie where IdUsername = '" + _userid + "' order by Date";
            //    cmd.CommandType = CommandType.Text;
            //    cmd.Connection = sqlConnection1;

            //    sqlConnection1.Open();
            //    using (reader = cmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            TextBlock new_message = new TextBlock();
            //            new_message.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x05, 0x0B, 0x0F));
            //            if (reader.GetBoolean(4) == false)
            //                new_message.Foreground = Brushes.AntiqueWhite;
            //            else
            //                new_message.Foreground = Brushes.Yellow;

            //            if (reader.GetInt32(5) == 1)
            //                new_message.Text = reader["Date"] + "\n" + reader.GetString(2) + "\n send from Facebook";
            //            else
            //                new_message.Text = reader["Date"] + "\n" + reader.GetString(2) + "\n send from Skype  by toto";

            //            Message_view.Children.Add(new_message);
            //        }
            //    }
            //}

            private void Send_message(object sender, RoutedEventArgs e)
            {
            Sounds.Sound1();
            if (My_message.Text == "")
                return;
            TextBlock new_message = new TextBlock();

            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\" + UI.Get_Theme() + ".xml");
            XmlNode node = doc.DocumentElement.SelectSingleNode("/ui/bgcolor");
            if (node != null)
            {
                Color color = (Color)ColorConverter.ConvertFromString(node.InnerText);
                new_message.Background = My_message.Background = btnSend.Background = messFirst.Background = new SolidColorBrush(color);
            }
            if ((node = doc.DocumentElement.SelectSingleNode("/ui/text/color")) != null)
            {
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString(node.InnerText);
                new_message.Foreground = brush;
            }
            new_message.Text = DateTime.Now + " \n" + My_message.Text + " \n" + "sent from Mizy\n";
            FindLinks(new_message);


            //    using (SqlConnection conn = new SqlConnection(_stringslqconnection))
            //    {
            //        using (SqlCommand comm = new SqlCommand("INSERT INTO Messagerie (IdUsername, Contenu, Date, IsSend, SendFrom) VALUES (@val1, @va2, @val3, @val4, @val5)"))
            //        {
            //            comm.Connection = conn;

            //            comm.Parameters.AddWithValue("@val1", _userid);
            //            comm.Parameters.AddWithValue("@val2", My_message.Text);
            //            comm.Parameters.AddWithValue("@val3", DateTime.Now);
            //            comm.Parameters.AddWithValue("@val4", false);
            //            comm.Parameters.AddWithValue("@val5", 1);

            //            try
            //            {
            //                conn.Open();
            //                comm.ExecuteNonQuery();
            //            }
            //            catch(SqlException err)
            //            {
            //                Debug.Write(err.Errors.ToString() + "\ntoto42\n");
            //            }
            //        }
            //       }
            My_message.Text = "";
            Message_view.Children.Add(new_message);
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
        //private int _userid;
        //private string _stringslqconnection;
    }
}
