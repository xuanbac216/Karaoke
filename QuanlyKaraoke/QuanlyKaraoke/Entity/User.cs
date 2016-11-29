using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyKaraoke.Entity
{
    class User
    {
        public string userName { get; set; }
        public string pass { get; set; }
        public User(string userName, string pass)
        {
            this.userName = userName;
            this.pass = pass;
        }
    }
}
