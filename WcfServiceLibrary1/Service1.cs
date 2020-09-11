using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1
    {
        public void Login(string userName)
        {
            OperationContext context = OperationContext.Current;
            IService1Callback callback = context.GetCallbackChannel<IService1Callback>();
            Users newUser = new Users(userName, callback);
            string str = "";
            for (int i = 0; i < CC.Users.Count; i++)
            {
                str += CC.Users[i].UserName + "、";
            }
            newUser.callback.InitUsersInfo(str.TrimEnd('、'));
            CC.Users.Add(newUser);
            foreach (var user in CC.Users)
            {
                user.callback.ShowLogin(userName);
            }
        }

        public void Logout(string userName)
        {
            Users logoutUser = CC.GetUser(userName);
            CC.Users.Remove(logoutUser);
            logoutUser = null;
            foreach (var user in CC.Users)
            {
                user.callback.ShowLogout(userName);
            }
        }

        public void Talk(string userName, string message)
        {
            Users user = CC.GetUser(userName);
            foreach (var v in CC.Users)
            {
                v.callback.ShowTalk(userName, message);
            }
        }
    }
}
