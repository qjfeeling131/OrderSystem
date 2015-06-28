
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
using OrderManager.Model.Models;
using Web.UserService;
using OrderManager.Common;
using OrderManager.Model.DTO;
using OrderManager.Web.Models;



namespace OrderManager.Web
{
    public class LogController : BaseController
    {
        //日记  Randy want to modify
        public ViewResult Index(string key, int? pageIndex = 0, int? pageSize = 10)
        {
            string userId = CurrentUser.User.Guid;
            UserServiceClient client = new UserServiceClient();
            List<OM_LogDataObject> list = client.GetCurrentUserLogs(Cipher, userId);


            if (!string.IsNullOrWhiteSpace(key))
            {
                list = list.Where(s => s.User_Name.Contains(key)).ToList();
                ViewBag.Key = key;
            }
            ViewBag.PageSize = pageSize;
            ViewBag.PageIndex = pageIndex;
            ViewBag.TotalPages = Math.Ceiling(Convert.ToDouble(list.Count) / Convert.ToDouble(pageSize));
            var result = list.Skip(Convert.ToInt32(pageIndex * pageSize)).Take((int)pageSize).ToList();
            client.Close();
            return View("~/views/log/index.cshtml", result);



        }

        //留言板
        public ViewResult MessageBoard(string key, int? pageIndex = 0, int? pageSize = 10)
        {

            using (UserServiceClient client = new UserServiceClient())
            {
                List<OM_MessageBoard> list = client.GetCurrentUserMessageBoard(Cipher, CurrentUser.User.Guid);

                if (!string.IsNullOrWhiteSpace(key))
                {
                    list = list.Where(s => s.Name.Contains(key)).ToList();
                    ViewBag.Key = key;
                }
                ViewBag.PageSize = pageSize;
                ViewBag.PageIndex = pageIndex;
                ViewBag.TotalPages = Math.Ceiling(Convert.ToDouble(list.Count) / Convert.ToDouble(pageSize));
                var result = list.Skip(Convert.ToInt32(pageIndex * pageSize)).Take((int)pageSize).ToList();
                return View("~/views/log/messageBoard.cshtml", result);
            }

        }

        public ViewResult LeaveMessage()
        {
            ViewBag.UserName = CurrentUser.User.Name;
            return View("~/Views/log/leavemessage.cshtml", null);
        }

        public ViewResult messageBoardShow(string messageGuid)
        {
            using (UserServiceClient client = new UserServiceClient())
            {
                OM_MessageBoard msgBoard = client.GetMessageBoardModel(Cipher, messageGuid);
                return View("~/Views/log/messageBoardShow.cshtml", msgBoard);
            }
        }


        [HttpPost]
        public ActionResult SubmitMessageBoard()
        {
                Model.Models.OM_MessageBoard msgBoard = new OM_MessageBoard()
                {
                    User_Guid = CurrentUser.User.Guid,
                    CreateDatetime = DateTime.Now,
                    Email = Request.Form["om-messageBoard-fm-email"],
                    Name = CurrentUser.User.Name,
                    Guid = Guid.NewGuid().ToString(),
                    Message = Request.Form["om-messageBoard-fm-message"],
                    PhoneNumber = Request.Form["om-messageBoard-fm-phoneNumer"],
                    Title = Request.Form["om-messageBoard-fm-title"],
                };

                using (UserServiceClient client = new UserServiceClient())
                {
                    client.SaveMessageBoard(Cipher, msgBoard);
                }
 
            return Json(new JsonModel { Code = 1, Type = JsonTypeEnym.AsynData.ToString(), Data = msgBoard });
        }

    }
}
