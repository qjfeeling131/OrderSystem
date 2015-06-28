
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
using OrderManager.Model.DTO;
using System.Web.Script.Serialization;




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
            var detail = UserService.GetSalesOrderAndDetail(Cipher, orderItemGuid);
             var status = Enum.Parse(typeof(OM_DocStatusEnum), detail.DocStatus);

            ViewBag.Status = status;

            return View("~/views/order/order.cshtml", detail);

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
            // post  get 分页数据
            return View("~/views/order/UserCodeList.cshtml", list.Take(10));

        }

        [HttpPost]
        public JsonResult UserCodeList(int? pageindex)
        {

            return Json(new JsonModel { });
        }



        public ViewResult ProductList()
        {
            var list = UserService.GetProductList(Cipher);
            return View("~/views/order/ProductList.cshtml", list);

        }

        [HttpPost]
        public JsonResult ProductList(int? pageindex)
        {
            return Json(new JsonModel { });
        }


        public ViewResult ProductPrice(string productItemCode)
        {
            var list = UserService.GetCurrentProducePriceList(Cipher, productItemCode, CurrentUser.User.Guid);
            return View("~/views/order/productPrice.cshtml", list);

        }


        [HttpPost]
        public JsonResult SaveDraft(string obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var orderDetail = jsonSerializer.Deserialize<OM_SalesOrderDataObject>(obj);
            orderDetail.User_Guid = CurrentUser.User.Guid;

            if (!string.IsNullOrWhiteSpace(orderDetail.Guid))
            {
                UserService.UpdateSalesOrder(Cipher, orderDetail);
            }
            else
            {
                orderDetail.Guid = UserService.SaveSalesOrder(Cipher, orderDetail);  // return order guid
            }

            return Json(new JsonModel { Data = orderDetail.Guid });

        }


        [HttpPost]
        public JsonResult SubmitOrder(string orderGuid)
        {
            UserService.UpdateSalesOrderStatusByCommit(Cipher, orderGuid);
            return Json(new JsonModel { Data="已提交" });
        }

        [HttpPost]
        public JsonResult SubmitOrder2SAp(string orderGuid)
        {
            UserService.UpdateSalesOrderStatusByToSAP(Cipher, orderGuid);
            return Json(new JsonModel { Data="已对接"});
        }

    }
}
