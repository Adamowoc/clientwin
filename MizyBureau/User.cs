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
        }


        public string _token;
        public string _email { get; set; }
        public string _lastname { get; set; }
        public string _firstname { get; set; }
        public bool _isFacebook { get; set; }
        public bool _isTwitter { get; set; }
        public string _password { get; set; }
    }
}
