using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    class Users
    {
        public string UserName { get; set; }
        public readonly IService1Callback callback;

        public Users(string userName, IService1Callback callback)
        {
            this.UserName = userName;
            this.callback = callback;
        }
    }
}
