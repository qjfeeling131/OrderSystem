﻿
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
using Web.Attribute;




namespace OrderManager.Web
{
    public class OrderController : BaseController
    {

        private IUserService UserService;
        static string CardCode = string.Empty;
        public OrderController()
        {
            UserService = new UserServiceClient();
        }

        public ViewResult Index(string key, int? pageIndex = 0, int? pageSize = 10)
        {
            //List<OM_Order> list = UserService.GetOrderList(Cipher, CurrentUser.User.Guid);
            List<OM_Order> list = UserService.GetCurrentSalesOrderList(Cipher, CurrentUser.User.Guid);
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
            ViewBag.DocDueDate = detail.DocDueDate == null ? " " : Convert.ToDateTime(detail.DocDueDate).ToString("yyyy.MM.dd");
            ViewBag.DocDate = Convert.ToDateTime(detail.DocDate).ToString("yyyy.MM.dd");
            return View("~/views/order/order.cshtml", detail);

        }


        public ViewResult Order()
        {
            ViewBag.DocDate = DateTime.Now.ToString("yyyy.MM.dd");
            return View();
        }

        public ViewResult UserCodeList()
        {

            var list = UserService.GetCurrentUserByCardCode(Cipher, CurrentUser.User.Guid);

            ViewBag.PageSize = 10;
            ViewBag.PageIndex = 0;
            ViewBag.TotalPages = Math.Ceiling(Convert.ToDouble(list.Count) / Convert.ToDouble(10));
            var result = list.Skip(Convert.ToInt32(0)).Take(10).ToList();

            return View("~/views/order/UserCodeList.cshtml", result);

        }

        [HttpPost]
        public JsonResult UserCodeList(string key, int? pageindex)
        {
            var list = UserService.GetCurrentUserByCardCode(Cipher, CurrentUser.User.Guid);


            if (!string.IsNullOrWhiteSpace(key))
            {
                list = list.Where(s => s.Name.Contains(key) || s.Account.Contains(key.ToUpper())).ToList();
                ViewBag.Key = key;
            }

            var result = list.Skip(Convert.ToInt32(pageindex)).Take(10).ToList();
            return Json(new JsonModel { Data = result });
        }



        public ViewResult ProductList(string cardCode)
        {

            var list = UserService.GetProductList(Cipher, cardCode, "", 0);
            var count = UserService.GetProductListCount(Cipher, cardCode, "");
            CardCode = cardCode;
            ViewBag.PageSize = 5;
            ViewBag.PageIndex = 0;
            ViewBag.TotalPages = Math.Ceiling(Convert.ToDouble(count) / Convert.ToDouble(5));
            return View("~/views/order/ProductList.cshtml", list);

        }

        [HttpPost]
        public JsonResult ProductList(string key, int? pageindex)
        {
            var list = UserService.GetProductList(Cipher, CardCode, key, (int)pageindex);
            //var count = UserService.GetProductListCount(Cipher, CardCode, key);

            return Json(new JsonModel { Data = list });
        }


        public ViewResult ProductPrice(string productItemCode, string cardCode)
        {
            var list = UserService.GetCurrentProducePriceList(Cipher, productItemCode, cardCode);
            return View("~/views/order/productPrice.cshtml", list);

        }


        [HttpPost]
        public JsonResult SaveDraft(string obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            var orderDetail = jsonSerializer.Deserialize<OM_SalesOrderDataObject>(obj);
            try
            {
                orderDetail.User_Guid = CurrentUser.User.Guid;

                if (!string.IsNullOrWhiteSpace(orderDetail.Guid))
                {
                    UserService.UpdateSalesOrder(Cipher, orderDetail);
                }
                else
                {
                    orderDetail.Guid = Guid.NewGuid().ToString().ToUpper();
                    //orderDetail.Guid = UserService.SaveSalesOrder(Cipher, orderDetail);  // return order guid
                    UserService.SaveSalesOrder(Cipher, orderDetail);
                }
            }
            catch (Exception ex)
            {

                return Json(GetException(ex));
            }

            return Json(new JsonModel { Data = orderDetail.Guid });

        }


        [HttpPost]
        public JsonResult SubmitOrder(string orderGuid)
        {
            try
            {
                UserService.UpdateSalesOrderStatusByCommit(Cipher, orderGuid);
            }
            catch (Exception ex)
            {

                return Json(GetException(ex));
            }
            return Json(new JsonModel { Data = "已提交" });
        }

        [HttpPost]
        public JsonResult SubmitOrder2SAp(string orderGuid)
        {
            if (UserService.UpdateSalesOrderStatusByToSAP(Cipher, orderGuid))
            {
                return Json(new JsonModel { Data = "已对接", Code = 0 });
            }
            return Json(new JsonModel { Code = -2 });
        }
        [SkipLogin]
        public ActionResult DateTimePickerIframe()
        {
            return View();
        }

    }
}
