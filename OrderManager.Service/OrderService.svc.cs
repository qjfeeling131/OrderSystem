using Microsoft.Practices.Unity;
using OrderManager.Manager;
using OrderManager.Model.Models;
using OrderManager.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace OrderManager.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [Aop.VerifyAuthority]
    [Aop.CatchWcfException]
    [Aop.WCFTransaction]
    public class OrderService : IOrderService
    {
        [Dependency]
        public IOrderManger OrderManger { get; set; }

        [Dependency]
        public ILogManager LogManager { get; set; }

        public IList<OM_Order> GetOrderList(string cipher, string userGuid)
        {
 
        }

        public IList<OM_OrderItem> GetOrderItemList(string cipher, string orderGuid)
        {
 OrderManger.GetSalesOrderItem()
        }
    }
}
