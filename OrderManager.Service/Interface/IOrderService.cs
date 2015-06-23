using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OrderManager.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderService" in both code and config file together.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        IList<OM_Order> GetOrderList(string cipher, string userGuid);

        [OperationContract]
        IList<OM_OrderItem> GetOrderItemList(string cipher, string orderGuid);
    }
}
