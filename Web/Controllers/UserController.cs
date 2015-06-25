
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Web.Mvc;
using System.Xml;
using System.Net.NetworkInformation;
using System.Net;
using System.Web;
using OrderManager.Web.Models;
using OrderManager.Model.Models;
using Web.UserService;
using OrderManager.Common;



namespace OrderManager.Web
{
    public class UserController : BaseController
    {

        private IUserService UserService;

        public UserController()
        {
            UserService = new UserServiceClient();
        }

        public ViewResult Index()
        {
            var userGuid = CurrentUser.User.Guid;
            ViewBag.UserGuid = userGuid;
            ViewBag.UserName = CurrentUser.User.Name;
            ViewBag.Account = CurrentUser.User.Account;
            return View();
        }

        [HttpPost]
        public JsonResult ChangePassword(string oldPwd, string newPwd, string userGuid)
        {
            var old = Encryptor.MD5Encrypt(oldPwd).ToUpper();
            var npwd = Encryptor.MD5Encrypt(newPwd).ToUpper();

            UserService.UpdatePassword(Cipher, userGuid, old, npwd);

            UpdateCookiePassword("UserAccount", npwd);

            return Json(new JsonModel { Code = 1, Type = JsonTypeEnym.Reload.ToString(), Data = "用户密码修改成功." });
        }


        public ViewResult UserList(string key, int? pageIndex = 0, int? pageSize = 10)
        {

            List<OM_User> list = UserService.GetCurrentUserList(Cipher,CurrentUser.User.Guid);
            //把自己移除
            list.Remove(list.Where(s => s.Guid == CurrentUser.User.Guid).FirstOrDefault());

            if (!string.IsNullOrWhiteSpace(key))
            {
                list = list.Where(s => s.Name.Contains(key)).ToList();
                ViewBag.Key = key;
            }

            ViewBag.PageSize = pageSize;
            ViewBag.PageIndex = pageIndex;
            ViewBag.TotalPages = Math.Ceiling(Convert.ToDouble(list.Count) / Convert.ToDouble(pageSize));
            var result = list.Skip(Convert.ToInt32(pageIndex * pageSize)).Take((int)pageSize).ToList();
            return View("~/views/user/userlist.cshtml", result);
        }

        [HttpGet]
        public ViewResult ResetPassword(string UserGuid)
        {
            OM_User model = UserService.GetUser(Cipher,UserGuid);
            
            return View("~/Views/user/resetpassword.cshtml", model);
        }

        [HttpPost]
        public JsonResult ResetPassword(string UserGuid, string newpwd)
        {
            var npwd = Encryptor.MD5Encrypt(newpwd);
            UserService.ResetPassword(Cipher, UserGuid, npwd);
            return Json(new JsonModel { Code = 1, Type = JsonTypeEnym.Reload.ToString(), Data = "重置用户密码成功." });
        }

    }
}
