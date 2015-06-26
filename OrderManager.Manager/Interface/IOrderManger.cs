
using OrderManager.Model.DTO;
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

        IList<OM_Product> GetProductList(int PageIndex, int PageSize, Expression<Func<OM_Product, bool>> fuc, Expression<Func<OM_Product, object>> orderFuc);

        OM_Product GetProduct(Expression<Func<OM_Product, bool>> fuc);
        IList<OM_Order> GetSalesOrderList(int PageIndex, int PageSize, Expression<Func<OM_Order, bool>> fuc, Expression<Func<OM_Order, object>> orderFuc);

        OM_Order GetSalesOrder(Expression<Func<OM_Order, bool>> fuc);

        IList<OM_OrderItem> GetSalesOrderItemList(int PageIndex, int PageSize, Expression<Func<OM_OrderItem, bool>> fuc, Expression<Func<OM_OrderItem, object>> orderFuc);
        OM_OrderItem GetSalesOrderItem(Expression<Func<OM_OrderItem, bool>> fuc);
        #endregion

        #region Fuction

        IList<OM_Product> GetProductList(Expression<Func<OM_Product, bool>> fuc);
        /// <summary>
        /// 保存销售订单
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <returns></returns>
        bool SaveSalesOrder(OM_SalesOrderDataObject salesOrder);
        /// <summary>
        /// 更新销售订单
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <returns></returns>
        bool UpdateSalesOrder(OM_SalesOrderDataObject salesOrder);
        /// <summary>
        /// 获取当前单据对象的集合
        /// </summary>
        /// <param name="docEntry"></param>
        /// <returns></returns>
        OM_SalesOrderDataObject GetSalesOrderAndDetail(string salesOrder_Guid);

        /// <summary>
        /// 获取当前用户区域销售订单列表
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        List<OM_Order> GetCurrentSalesOrderList(string userGuid);

        /// <summary>
        /// 获取当前区域的产品价格清单列表
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        List<OM_ProductPrice> GetCurrentProducePriceList(string itemCode, string userGuid);

        /// <summary>
        /// Save To SAP
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <returns></returns>
        bool SaveForSAP(OM_SalesOrderDataObject salesOrder);

        /// <summary>
        /// Update SalesOrderStatus
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        bool UpdateSalesOrderStatus(OM_Order order);

        /// <summary>
        /// Get CurrentUserByCardCode
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        List<OM_User> GetCurrentUserByCardCode(string userGuid);
        #endregion

    }
}
