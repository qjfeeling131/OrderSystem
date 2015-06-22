using OrderManager.Model.DTO;
using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OrderManager.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        OM_UserDetail Login(string userAccount, string password);

        [OperationContract]
        List<OM_LogDataObject> GetCurrentUserLogs(string cipher, string userId);

        [OperationContract]
        void ResetPassword(string cipher, string userGuid, string newPwd);

        [OperationContract]
        void UpdatePassword(string cipher, string userGuid, string oldPwd, string newPwd);

        [OperationContract]
        List<OM_User> GetCurrentUserList(string cipher, string userGuid);

        [OperationContract]
        OM_User GetUser(string cipher, string userGuid);

        [OperationContract]
        bool SaveMessageBoard(string cipher, OM_MessageBoard msgBoard);

        [OperationContract]
        List<OM_MessageBoard> GetCurrentUserMessageBoard(string cipher, string userId);

        [OperationContract]
        OM_MessageBoard GetMessageBoardModel(string cipher, string guid);
    }
}

