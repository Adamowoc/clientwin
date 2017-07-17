using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace MizyBureau
{
    public static class Constants
    {
        public const string LocalDB_connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MizyLocalDB.mdf;Integrated Security = True";
    }

    public class SocketClient
    {
        private Socket Socket;

        public bool _isStateOk { get; set; }
        public SocketClient()
        {
            _isStateOk = false;
            try
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse("81.56.97.154");
                System.Net.IPEndPoint remoteEP = new IPEndPoint(ipAdd, 60);
                Socket.Connect(remoteEP);
                _isStateOk = true;
            }

            catch (Exception e)
            {
                _isStateOk = false;
            }
            _isStateOk = true;
        }

        public bool Login(string email, string password, ref bool twitter, ref bool facebook)
        {
            try
            {
                string str = "{ \"function\": \"login\", \"parameters\": {\"user\":\"" + @email + "\", \"password\":\"" + @password + "\"} }\r\n";
                byte[] byData = System.Text.Encoding.UTF8.GetBytes(str);
                Socket.Send(byData);
                int k = Socket.Receive(byData);
                string strReceived = Encoding.UTF8.GetString(byData);
                if (strReceived.Contains("\"response\" : \"OK\""))
                {
                    if (strReceived.Contains("\"twitter\" : \"True\""))
                        twitter = true;
                    if (strReceived.Contains("\"facebook\" : \"True\""))
                        facebook = true;
                    return true;
                }
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public bool Register(string email, string password)
        {
            try
            {
                string str = "{ \"function\": \"register\", \"parameters\": {\"user\":\"" + @email + "\", \"password\":\"" + @password + "\"} }\r\n";
                byte[] byData = System.Text.Encoding.UTF8.GetBytes(str);
                Socket.Send(byData);
                Socket.Receive(byData);
                string strReceived = Encoding.UTF8.GetString(byData);
                if (strReceived.Contains("\"response\" : \"OK\""))
                   return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public bool Linking(string channel, string user, string password)
        {
            try
            {
                string str = "{ \"function\": \"loginAPI\", \"parameters\": {\"channel\":\"" + @channel + "\", \"user\":\"" + @user + "\", \"password\":\"" + @password + "\"} }\r\n";
                byte[] byData = System.Text.Encoding.UTF8.GetBytes(str);
                Socket.Send(byData);
                int k = Socket.Receive(byData);
                string strReceived = Encoding.UTF8.GetString(byData);
                if (strReceived.Contains("\"response\" : \"OK\""))
                    return true;
            }
            catch (Exception e)
            {
            }
            return false;
        }


        ~SocketClient()
        {
            Socket.Close();
        }

    }
}
