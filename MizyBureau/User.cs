using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MizyBureau
{
    public class User
    {
        public User(string email, bool twitter = false, bool facebook = false)
        {
            _email = email;
            _isTwitter = twitter;
            _isFacebook = facebook;
        }

        public string _email { get; set; }
        public bool _isFacebook { get; set; }
        public bool _isTwitter { get; set; }
    }
}
