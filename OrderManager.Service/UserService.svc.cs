using Microsoft.Practices.Unity;
using OrderManager.Common;
using OrderManager.Manager;
using OrderManager.Model.DTO;
using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace OrderManager.Service
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [Aop.VerifyAuthority]
    [Aop.CatchWcfException]
    [Aop.WCFTransaction]
    public class UserService : IUserService
    {
        [Dependency]
        public IUserManager UserManager { get; set; }

        [Dependency]
        public ILogManager LogManager { get; set; }


        public OM_UserDetail Login(string userAccount, string password)
        {
            var result = UserManager.Login(userAccount, password);
            if (result == false)
                throw new GenericException("账户或密码错误，请再次检查输入", OM_ExceptionCodeEnum.LOGIN.ToString());

            var user = UserManager.GetUser(f => f.Account == userAccount && f.Pwd == password);

            user.UpdateDatetime = DateTime.Now;
            user.Key = Encryptor.MD5Encrypt(user.ID + user.Account + user.Pwd+user.CreateDatetime+user.Area_Guid+user.UpdateDatetime);
            UserManager.UpdateUer(user);

            var re = UserManager.GetUserDetail(user.Guid);

            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "User/Login",
                Guid = Guid.NewGuid().ToString(),
                Operation = "登陆",
                User_Guid = user.Guid,
                Message = string.Format("用户[{0}] : '{1}' 登陆了系统.", user.Name, DateTime.Now)
            };
            LogManager.WriteLog(log);

            return re;
        }

        public List<OM_User> GetCurrentUserList(string cipher,string userGuid)
        {
            var result = UserManager.GetAreaRoles(userGuid);
            //把自己移除
            result.Remove(result.Where(s => s.Guid == userGuid).FirstOrDefault());
            return result;
        }

        public List<OM_LogDataObject> GetCurrentUserLogs(string cipher, string userId)
        {
            return UserManager.GetCurrentUserLogs(userId);
        }

        public void ResetPassword(string cipher,  string userGuid, string newPwd)
        {
            var result = UserManager.ResetPassword(userGuid, newPwd);
            if (result == false)
                throw new GenericException("重设用户密码失败");

            var user= UserManager.GetUser(s => s.Guid == userGuid);
            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "User/ResetPassword",
                Guid = Guid.NewGuid().ToString(),
                Operation = "重设用户密码",
                User_Guid = cipher,
                Message = string.Format("'{0}' 重设用户 [{1}] 密码.", DateTime.Now, user.Name)
            };
            LogManager.WriteLog(log);
        }

        public void UpdatePassword(string cipher, string userGuid, string oldPwd, string newPwd)
        {
            var result = UserManager.UpdatePassword(userGuid, oldPwd, newPwd);
            if (result == false)
                throw new GenericException("更新用户密码失败");

            var user = UserManager.GetUser(s => s.Guid == userGuid);
            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "User/Login",
                Guid = Guid.NewGuid().ToString(),
                Operation = "修改密码",
                User_Guid = cipher,
                Message = string.Format("用户[{0}] : '{1}' 修改了密码.", user.Name, DateTime.Now)
            };
            LogManager.WriteLog(log);

        }

        public OM_User GetUser(string cipher, string userGuid)
        {
            var user= UserManager.GetUser(a => a.Guid == userGuid);
            if (user == null)
                throw new GenericException("用户不存在");
            return user;
        }



        public List<OM_MessageBoard> GetCurrentUserMessageBoard(string cipher, string userId)
        {
            return UserManager.GetCurrentUserMessageBoard(userId);
        }


        public bool SaveMessageBoard(string cipher, OM_MessageBoard msgBoard)
        {
            var result= UserManager.SaveMessageBoard(msgBoard);
            if (result)
            {
                var user = UserManager.GetUser(s => s.Guid == cipher);
                var log = new OM_Log
                {
                    CreateDatetime = DateTime.Now,
                    Doc_View = "Log/MessageBoard",
                    Guid = Guid.NewGuid().ToString(),
                    Operation = "留言",
                    User_Guid = cipher,
                    Message = string.Format("用户[{0}] : '{1}' 留了一条信息.", user.Name, DateTime.Now)
                };
                LogManager.WriteLog(log);
            }
            return result;
        }

        public OM_MessageBoard GetMessageBoardModel(string cipher, string guid)
        {
            return UserManager.GetMessageBoard(m => m.Guid == guid);
        }
    }
}

