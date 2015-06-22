using Aspect;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManager.Common;
using OrderManager.Manager;
using Microsoft.Practices.Unity;
using OrderManager.Model.Models;

namespace OrderManager.Service.Aop
{
    public class VerifyAuthorityAttribute : AuthenticationAttribute
    {

        private IUserManager UserManager { get { return MyUnityContainer.Instance.Resolve<IUserManager>(); } }
  

        public override void CheckAuthentication(IMethodInvocation input)
        {

            //if (input.MethodBase.Name.ToUpper() == "LOGIN")
            //    return;  cipher 用 userguid  字段作hash MD5


            //if (input.Arguments.ContainsParameter("cipher") == false)
            //    throw new GenericException("为确保账户安全,请重新登陆", OM_ExceptionCodeEnum.LOGIN.ToString());
            ////MyUnityContainer
            //var cipher = input.Arguments["cipher"].ToString();

            //var userList = UserManager.GetUserList(0, int.MaxValue, f => f.ID > 0, null);

            //bool exist = false;
            //Model.Models.OM_User user = null;
            //foreach (var item in userList)
            //{
            //    string result = Encryptor.DESEncrypt(item.Guid, item.Key);
            //    if (result == cipher)
            //    {
               
            //        if (item.UpdateDatetime == null || item.UpdateDatetime < DateTime.Now.AddHours(-1))
            //            throw new GenericException("登陆超时，请重新登陆", OM_ExceptionCodeEnum.LOGIN.ToString());
            //        exist = true;
            //        user = item;
            //        break;
            //    }
            //}

            //if (exist == false)
            //    throw new GenericException("用户身份验证失败，请重新登录", OM_ExceptionCodeEnum.LOGIN.ToString());

            ////验证成功， 更新最后修改时间。
            //UserManager.UpdateUer(user);

        }
    }
}
