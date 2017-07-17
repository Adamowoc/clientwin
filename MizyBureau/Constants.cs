using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows;

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

        public bool Linking_fb(string user, string mail, string password)
        {
            try
            {
                string str = "{ \"function\": \"addFacebookCredentials\", \"parameters\": {\"facebook_email\":\"" + @mail + "\", \"facebook_password\":\"" + @password + "\", \"user\":\"" + @user + "\"} }\r\n";
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

        public bool Linking_twitter(ref string url, string mail)
        {
            try
            {
                string str = "{ \"function\": \"getUrlOAuth\", \"parameters\": {\"user\":\"" + @mail + "\"} }\r\n";
                byte[] byData = System.Text.Encoding.UTF8.GetBytes(str);
                Socket.Send(byData);
                int bytesRead;
                string strReceived = "";
                while ((bytesRead = Socket.Receive(byData)) > 0)
                {
                    strReceived = strReceived + Encoding.UTF8.GetString(byData);
                    // process bytesRead from buffer
                }
                if (strReceived.Contains("\"response\" : \"OK\""))
                {
                   int a = strReceived.IndexOf("\"url\" : \"") + 10;
                    url = strReceived.Substring(a, strReceived.Length - a - 1);
                    return true;
                }
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
