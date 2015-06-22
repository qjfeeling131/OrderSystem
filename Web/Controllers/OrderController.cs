
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



namespace OrderManager.Web
{
    public class OrderController : BaseController
    {
        public ViewResult Index(string key, int? pageIndex = 0, int? pageSize = 10)
        {
            List<OM_User> list = new List<OM_User>() { 
            new OM_User{ Guid="1", Name="rrere1", Account="c001", Email="wwerewr@qq.com", Gender=true,Address="guangzhou"},
            new OM_User{  Guid="2",Name="rrere2", Account="c001", Email="wwerewr@qq.com", Gender=true},
            new OM_User{  Guid="3",Name="rrere3", Account="c001", Email="wwerewr@qq.com", Gender=true},
            new OM_User{ Guid="4", Name="rrere4", Account="c001", Email="wwerewr@qq.com", Gender=true},
            new OM_User{ Guid="5", Name="rrere5", Account="c001", Email="wwerewr@qq.com", Gender=true},
            new OM_User{  Guid="6",Name="rrere6", Account="c001", Email="wwerewr@qq.com", Gender=true},
              new OM_User{ Name="7", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="8", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="9", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="10", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="11", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="12", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="13", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="14", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="15", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="16", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="17", Account="c001", Email="wwerewr@qq.com", Gender=true},
              new OM_User{ Name="18", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="19", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="20", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="21", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="22", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true},
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="30", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="35", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true},
              new OM_User{ Name="40", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="44", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="45", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="50", Account="c001", Email="wwerewr@qq.com", Gender=true}, 
              new OM_User{ Name="rrere", Account="c001", Email="wwerewr@qq.com", Gender=true}
            };

            ViewBag.PageSize = pageSize;
            ViewBag.PageIndex = pageIndex;
            ViewBag.TotalPages = Math.Ceiling(Convert.ToDouble(list.Count) / Convert.ToDouble(pageSize));
            var result = list.Skip(Convert.ToInt32(pageIndex * pageSize)).Take((int)pageSize).ToList();
            return View("~/views/order/index.cshtml", result);
        }

        public ViewResult Order()
        {
            return View();
        }


        
    }
}
