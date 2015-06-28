
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.ServiceModel;
using OrderManager.Web.Models;
using OrderManager.Model.Models;
using System.Web.Script.Serialization;
using OrderManager.Model.DTO;
using System.Net;
using OrderManager.Common;


namespace OrderManager.Web
{
    public class BaseController : Controller
    {

        //public ICache Cache { get; set; }
        public ViewResult Exception(Models.InfoModel model)
        {
            if (model == null)
                model = new InfoModel();
            return View("~/Views/Template/Exception.cshtml", model);
        }

        protected char CookieSplitStr { get { return '*'; } }

        protected string GetCookie(string key)
        {
            var cookie = HttpContext.Request.Cookies[key];
            if (cookie != null)
                return cookie.Value;
            return null;
        }

        protected void SetCookie(string key, string value, DateTime? timeout)
        {
            var cookie = HttpContext.Response.Cookies[key];
            if (cookie == null)
            {
                cookie = new HttpCookie(key, value);
                if (timeout != null)
                    cookie.Expires = timeout.Value;
                HttpContext.Response.AppendCookie(cookie);
            }
            else
            {
                cookie.Value = value;
                if (timeout != null)
                    cookie.Expires = timeout.Value;
                HttpContext.Response.SetCookie(cookie);
            }

        }

        protected void UpdateCookiePassword(string key, string pwd)
        {
            var acccount = GetCookie(key);
            if (string.IsNullOrEmpty(acccount))
                return;

            var array = acccount.Split(CookieSplitStr);
            var result = array[0] + CookieSplitStr + array[1];
            SetCookie(key, " ", DateTime.Now.AddDays(7));

        }


        public OM_UserDetail CurrentUser
        {
            get
            {
                var address = GetLocationComputer();
                return (OM_UserDetail)Session[address];
            }
            set
            {
                var address = GetLocationComputer();
                Session.Timeout = 120;
                Session[address] = value;

            }
        }

        protected string Cipher
        {
            get
            {
                if (CurrentUser == null)
                    return null;

                var result = CurrentUser.User.Guid;
                return result;

            }
        }

        private string GetLocationComputer()
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName);
            string strAddr = string.Concat(strHostName, ipEntry.AddressList[0].ToString());
            return strAddr;
        }

        public BaseController()
        {
            //Cache = Tools.DistrubutedCache;
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            //filterContext.
            base.OnAuthorization(filterContext);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentUser != null)
            {
                ViewBag.UserName = CurrentUser.User.Name;
                ViewBag.LoginDate = CurrentUser.User.UpdateDatetime;
            }
            base.OnActionExecuting(filterContext);
        }


        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            InfoModel errormodel = new InfoModel() { Title = "错误", Code = -1 };
            JsonModel resultModel = new JsonModel() { Code = -1 };
            var wcfException = filterContext.Exception as FaultException<ExceptionDetail>;
            if (wcfException != null)
            {
                errormodel.Message = GetWcfExceptionDetail(wcfException.Detail);
                errormodel.Type = wcfException.Detail.HelpLink;
                string notepad = FormmatException(wcfException.StackTrace, wcfException.Message, wcfException.Source);
                ExceptionLog.Write(notepad);
            }
            else
            {
                errormodel.Message = GetExceptionDetail(filterContext.Exception);
                string notepad = FormmatException(filterContext.Exception.StackTrace, filterContext.Exception.Message, filterContext.Exception.Source);
                ExceptionLog.Write(notepad);
            }

            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {

                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                resultModel.Data = "createDialog('" + Url.Content("~/base/exception") + "'," + jsonSerializer.Serialize(errormodel) + ")";
                filterContext.Result = Json(resultModel);
            }
            else
                filterContext.Result = View("~/Views/Template/ExceptionPage.cshtml", errormodel);

        }

        private string GetWcfExceptionDetail(ExceptionDetail ex)
        {
            string str = string.Concat(ex.Message, "  "); // ex.StackTrace
            if (ex.InnerException != null)
            {
                str = string.Concat(str, this.GetWcfExceptionDetail(ex.InnerException));
            }
            return str;
        }

        private string GetExceptionDetail(Exception ex)
        {
            string str = string.Concat(ex.Message, "  "); //ex.StackTrace
            if (ex.InnerException != null)
            {
                str = string.Concat(str, this.GetExceptionDetail(ex.InnerException));
            }
            return str;
        }

        private string FormmatException(string StackTrace, string Message, string Source)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("------------------【{0}】------------------", DateTime.Now));
            sb.Append("\r\n");
            sb.Append("【Source】：" + Source); sb.Append("\r\n");
            sb.Append("【Message】：" + Message); sb.Append("\r\n");
            sb.Append("【StackTrace】：" + Message); sb.Append("\r\n");
            return sb.ToString();
        }


    }
}
