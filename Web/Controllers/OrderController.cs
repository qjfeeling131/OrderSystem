
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
using OrderManager.Web.Models;




namespace OrderManager.Web
{
    public class OrderController : BaseController
    {

        private IUserService UserService;

        public OrderController()
        {
            UserService = new UserServiceClient();
        }

        public ViewResult Index(string key, int? pageIndex = 0, int? pageSize = 10)
        {
            List<OM_Order> list = UserService.GetOrderList(Cipher, CurrentUser.User.Guid);

            if (!string.IsNullOrWhiteSpace(key))
            {
                list = list.Where(s => s.CardName.Contains(key)).ToList();
                ViewBag.Key = key;
            }

            ViewBag.PageSize = pageSize;
            ViewBag.PageIndex = pageIndex;
            ViewBag.TotalPages = Math.Ceiling(Convert.ToDouble(list.Count) / Convert.ToDouble(pageSize));
            var result = list.Skip(Convert.ToInt32(pageIndex * pageSize)).Take((int)pageSize).ToList();
            return View("~/views/order/index.cshtml", result);
        }


        public ViewResult OrderItem(string orderItemGuid)
        {
            var result = UserService.GetOrderItemList(Cipher, orderItemGuid);
            ViewBag.OrderNum = orderItemGuid;
            return View("~/views/order/orderitem.cshtml", result);

        }


        public ViewResult Order()
        {
            return View();
        }

        public ViewResult UserCodeList()
        {

            var list = UserService.GetCurrentUserList(Cipher, CurrentUser.User.Guid);
            for (var i = 0; i < 10; i++)
            {
                list.AddRange(list);
            }

            return View("~/views/order/UserCodeList.cshtml", list.Take(10));

        }

        public JsonResult GetProductInfo(string productCode, string productName)
        {


            return Json(new JsonModel { });
        }

        [HttpPost]
        public JsonResult SaveDraft(string userCode, string status, string remark, List<OM_OrderItem> orderItems)
        {
            return Json(new JsonModel { });
 
        }


    }
}
