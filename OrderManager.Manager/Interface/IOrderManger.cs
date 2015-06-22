
using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Manager
{
    public interface IOrderManger
    {
        #region Save Method
         bool SaveProduct(OM_Product product);

         bool SaveSalesOrder(OM_Order saleOrder);
         bool SaveSalesOrderItem(OM_OrderItem saleOrderItem);
        #endregion

        #region Update Method
         bool UpdateProduct(OM_Product product);

         bool UpdateSalesOrder(OM_Order saleOrder);
         bool UpdateSalesOrderItem(OM_OrderItem saleOrderItem);
        #endregion

        #region Update Method
         bool DeleteProduct(Expression<Func<OM_Product, bool>> product);

         bool UpdateSalesOrder(Expression<Func<OM_Order, bool>> saleOrder);
         bool DeleteSalesOrderItem(Expression<Func<OM_OrderItem, bool>> saleOrderItem);
        #endregion

        #region Get ont or manay object

         IList<OM_Product> GetProductList(int PageIndex, int PageSize, Expression<Func<OM_Product, bool>> fuc, Expression<Func<OM_Product, bool>> orderFuc);

         OM_Product GetProduct(Expression<Func<OM_Product, bool>> fuc);
         IList<OM_Order> GetSalesOrderList(int PageIndex, int PageSize, Expression<Func<OM_Order, bool>> fuc, Expression<Func<OM_Order, bool>> orderFuc);

         OM_Order GetSalesOrder(Expression<Func<OM_Order, bool>> fuc);

         IList<OM_OrderItem> GetSalesOrderItemList(int PageIndex, int PageSize, Expression<Func<OM_OrderItem, bool>> fuc, Expression<Func<OM_OrderItem, bool>> orderFuc);
         OM_OrderItem GetSalesOrderItem(Expression<Func<OM_OrderItem, bool>> fuc);
        #endregion
    }
}
