
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
using Web.OrderService;



namespace OrderManager.Web
{
    public class OrderController : BaseController
    {

        private IOrderService OrderService;

        public OrderController()
        {
            OrderService = new OrderServiceClient();
        }

        public ViewResult Index(string key, int? pageIndex = 0, int? pageSize = 10)
        {
            List<OM_Order> list = OrderService.GetOrderList(Cipher, CurrentUser.User.Guid);          

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
            var result = OrderService.GetOrderItemList(Cipher, orderItemGuid);
            return View("~/views/order/orderitem.cshtml", result);
 
        }

        public ViewResult Order()
        {
            return View();
        }



    }
}
