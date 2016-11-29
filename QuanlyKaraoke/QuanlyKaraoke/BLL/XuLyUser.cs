using QuanlyKaraoke.DAL;
using QuanlyKaraoke.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyKaraoke.BLL
{
    class XuLyUser
    {
        internal static bool checkUser(string userName, string pass)
        {
            List<User> lst = UserDAO.GetUser();
            foreach (User r in lst)
            {
                if (r.userName == userName && r.pass == pass) return true;
            }
            return false;
        }
    }
}
