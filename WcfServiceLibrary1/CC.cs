using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    class CC
    {
        public static List<Users> Users { get; set; }

        static CC()
        {
            Users = new List<Users>();
        }

        public static Users GetUser(string userName)
        {
            Users user = null;
            foreach (var v in Users)
            {
                if (v.UserName == userName)
                {
                    user = v;
                    break;
                }
            }
            return user;
        }
    }
}
