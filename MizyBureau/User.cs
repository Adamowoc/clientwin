using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MizyBureau
{
    public class User
    {
        public User(string email, bool twitter = false, bool facebook = false, string password = "", string f = "", string l = "")
        {
            _email = email;
            _isTwitter = twitter;
            _isFacebook = facebook;
            _password = password;
            _lastname = l;
            _firstname = f;

            Random rd = new Random();

            if (rd.Next(0, 2) > 1)
                _facebook = true;
            if (rd.Next(0, 2) > 1)
                _twitter = true;
            if (rd.Next(0, 2) > 1)
                _slack = true;
        }

        public string _token;
        public string _email { get; set; }
        public string _lastname { get; set; }
        public string _firstname { get; set; }
        public bool _isFacebook { get; set; }
        public bool _isTwitter { get; set; }
        public string _password { get; set; }
        public bool _facebook { get; set; }
        public bool _twitter { get; set; }
        public bool _slack{ get; set; }
    }
}
