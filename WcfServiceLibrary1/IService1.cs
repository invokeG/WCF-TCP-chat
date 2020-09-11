using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    [ServiceContract(Namespace = "IService",
        CallbackContract = typeof(IService1Callback))]
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    public interface IService1
    {

        // TODO: 在此添加您的服务操作
        [OperationContract(IsOneWay = true)]
        void Login(string userName);

        [OperationContract(IsOneWay = true)]
        void Logout(string userName);

        [OperationContract(IsOneWay = true)]
        void Talk(string userName, string message);
    }


    public interface IService1Callback
    {
        [OperationContract(IsOneWay = true)]
        void ShowLogin(string loginUserName);

        [OperationContract(IsOneWay = true)]
        void ShowLogout(string userName);

        [OperationContract(IsOneWay = true)]
        void ShowTalk(string userName, string message);

        [OperationContract(IsOneWay = true)]
        void InitUsersInfo(string UsersInfo);
    }

}
