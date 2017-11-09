using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MizyBureau.Script
{
    class UserManager
    {
        public static UserManager instance;

        public UserManager()
        {
            instance = this;
        }

        public User ActualUser { get; set; }
    }
}
