using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MizyBureau
{
    public class User
    {
        public User(string email, int id)
        {
            _email = email;
            _id = id;
        }

        public string GetEmail()
        {
            return _email;
        }

        public int GetId()
        {
            return _id;
        }

        private string      _email;
        private int         _id;
        private List<User>  _friends;
    }
}
