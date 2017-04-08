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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace MizyBureau
{
    /// <summary>
    /// Logique d'interaction pour InstantMessagery.xaml
    /// </summary>
    public partial class InstantMessagery : UserControl
    {
        public InstantMessagery(int i, string s)
        {
            InitializeComponent();
            _stringslqconnection = s;
            _userid = i;
            Construct_message_view();
        }

        private void Construct_message_view()
        {
            SqlConnection sqlConnection1 = new SqlConnection(_stringslqconnection);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Messagerie where IdUsername = '" + _userid + "' order by Date";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    TextBlock new_message = new TextBlock();
                    new_message.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x05, 0x0B, 0x0F));
                    if (reader.GetBoolean(4) == false)
                        new_message.Foreground = Brushes.AntiqueWhite;
                    else
                        new_message.Foreground = Brushes.Yellow;

                    if (reader.GetInt32(5) == 1)
                        new_message.Text = reader["Date"] + "\n" + reader.GetString(2) + "\n send from Facebook";
                    else
                        new_message.Text = reader["Date"] + "\n" + reader.GetString(2) + "\n send from Skype  by toto";

                    Message_view.Children.Add(new_message);
                }
            }
        }
        private void Send_message(object sender, RoutedEventArgs e)
        {
            TextBlock new_message = new TextBlock();
            new_message.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x05, 0x0B, 0x0F));
            new_message.Foreground = Brushes.AntiqueWhite;
            new_message.Text = DateTime.Now + "\n" + My_message.Text + "\n send from Mizy";

            using (SqlConnection conn = new SqlConnection(_stringslqconnection))
            {
                using (SqlCommand comm = new SqlCommand("INSERT INTO Messagerie (IdUsername, Contenu, Date, IsSend, SendFrom) VALUES (@val1, @va2, @val3, @val4, @val5)"))
                {
                    comm.Connection = conn;

                    comm.Parameters.AddWithValue("@val1", _userid);
                    comm.Parameters.AddWithValue("@val2", My_message.Text);
                    comm.Parameters.AddWithValue("@val3", DateTime.Now);
                    comm.Parameters.AddWithValue("@val4", false);
                    comm.Parameters.AddWithValue("@val5", 1);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                    catch(SqlException err)
                    {
                        Debug.Write(err.Errors.ToString() + "\ntoto42\n");
                    }
                }
            }
            My_message.Text = "";
            Message_view.Children.Add(new_message);
        }

        private int _userid;
        private string _stringslqconnection;
    }
}
