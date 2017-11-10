using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MizyBureau.Script
{
    public class Contact
    {
        public Contact(string name, bool twitter = false, bool facebook = false)
        {
            _name = name;
            _isTwitter = twitter;
            _isFacebook = facebook;
        }

        public string _name { get; set; }
        public bool _isFacebook { get; set; }
        public bool _isTwitter { get; set; }
    }
}
