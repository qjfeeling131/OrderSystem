using OrderManager.Common;
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
using Web.UserService;
using OrderManager.Web.Models;



namespace OrderManager.Web
{
    public class HomeController : BaseController
    {

        private IUserService UserService;

        public HomeController()
        {
            UserService = new UserServiceClient();
        }

        //js验证 和loading
        public ViewResult Login()
        {
            var Account = GetCookie("UserAccount");
            if (!string.IsNullOrEmpty(Account))
            {
                var arr = Account.Split(CookieSplitStr);
                ViewBag.Account = arr[0];
                ViewBag.Pwd = arr[1];
            }
            return View();
        }


        public ViewResult Home()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Login(string UserCode, string Password, bool? IsRememeber)  //json 不能传null
        {
           
           var detail = UserService.Login(UserCode, Encryptor.MD5Encrypt(Password));
            CurrentUser = detail;

            if (IsRememeber == true)
            {
                SetCookie("UserAccount", UserCode + CookieSplitStr + Password, DateTime.Now.AddDays(7));
            }
            else
            {
                UpdateCookiePassword("UserAccount", Password);
            }

            return Json(new JsonModel { Code = 1, Type = JsonTypeEnym.Redirect.ToString(), Href = Url.Content("~/home/home") });
        }


        [HttpPost]
        public JsonResult SignOut(string userGuid)
        {
            CurrentUser = null;
            //SetCookie("UserAccount", "", DateTime.Now.AddDays(-1));
            return Json(new JsonModel { Code = 1, Type = JsonTypeEnym.Redirect.ToString(), Href = Url.Content("~/home/login") });
        }

    }
}
