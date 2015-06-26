
using Microsoft.Practices.Unity;
using OrderManager.Model.DTO;
using OrderManager.Model.Models;
using OrderManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Manager
{
    public class OrderManger : BaseManger, IOrderManger
    {
        [Dependency]
        public IUserManager userManager { get; set; }

        #region Save Method
        public bool SaveProduct(OM_Product product)
        {
            if(DbRepository.Add(product) > 0)
            {
                return true;
            }
            return false;
        }

        public bool SaveSalesOrder(OM_Order saleOrder)
        {
            if(DbRepository.Add(saleOrder) > 0)
            {
                return true;
            }
            return false;
        }
        public bool SaveSalesOrderItem(OM_OrderItem saleOrderItem)
        {
            if(DbRepository.Add(saleOrderItem) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Update Method
        public bool UpdateProduct(OM_Product product)
        {
            if(DbRepository.Update(product) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSalesOrder(OM_Order saleOrder)
        {
            if(DbRepository.Update(saleOrder) > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateSalesOrderItem(OM_OrderItem saleOrderItem)
        {
            if(DbRepository.Update(saleOrderItem) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Update Method
        public bool DeleteProduct(Expression<Func<OM_Product, bool>> product)
        {
            if(DbRepository.Delete(product) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSalesOrder(Expression<Func<OM_Order, bool>> saleOrder)
        {
            if(DbRepository.Delete(saleOrder) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteSalesOrderItem(Expression<Func<OM_OrderItem, bool>> saleOrderItem)
        {
            if(DbRepository.Delete(saleOrderItem) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region  Get one or manay Object

        public IList<OM_Product> GetProductList(int PageIndex, int PageSize, Expression<Func<OM_Product, bool>> fuc, Expression<Func<OM_Product, object>> orderFuc)
        {
            return DbRepository.GetPagedList(PageIndex, PageSize, fuc, orderFuc);

        }

        public OM_Product GetProduct(Expression<Func<OM_Product, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }

        public IList<OM_Order> GetSalesOrderList(int PageIndex, int PageSize, Expression<Func<OM_Order, bool>> fuc, Expression<Func<OM_Order, object>> orderFuc)
        {
            return DbRepository.GetPagedList(PageIndex, PageSize, fuc, orderFuc);

        }

        public OM_Order GetSalesOrder(Expression<Func<OM_Order, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }

        public IList<OM_OrderItem> GetSalesOrderItemList(int pageIndex, int pageSize, Expression<Func<OM_OrderItem, bool>> whereLambda = null, Expression<Func<OM_OrderItem, object>> orderBy = null)
        {


            return DbRepository.GetPagedList(pageIndex, pageSize, whereLambda, orderBy).ToList();

        }
        public IList<OM_OrderItem> GetSalesOrderItemList(Expression<Func<OM_OrderItem, bool>> fuc)
        {
            return DbRepository.GetList(fuc);

        }
        public OM_OrderItem GetSalesOrderItem(Expression<Func<OM_OrderItem, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }
        #endregion

        #region Function

        public IList<OM_Product> GetProductList(Expression<Func<OM_Product, bool>> fuc)
        {
            return DbRepository.GetList(fuc);

        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <returns></returns>
        public bool SaveSalesOrder(OM_SalesOrderDataObject salesOrder)
        {
            OM_Order order = salesOrder.ToDTO();

            var salesOrderHead = DbRepository.Add(order);
            var salesOrderLine = DbRepository.AddRange(salesOrder.SalesOrderLine);
            if(salesOrderHead == 0 && salesOrderLine == 0)
            {
                return true;
            }
            return false;
        }
        public bool SaveForSAP(OM_SalesOrderDataObject salesOrder)
        {

            return false;
        }


        public bool UpdateSalesOrderStatus(OM_Order order)
        {
            if(DbRepository.Update(order) == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <returns></returns>
        public bool UpdateSalesOrder(OM_SalesOrderDataObject salesOrder)
        {
            OM_Order order = salesOrder.ToDTO();
            var salesOrderHead = DbRepository.Update(order);
            var salesOrderLine = DbRepository.UpdateRange(salesOrder.SalesOrderLine);
            if(salesOrderHead == 0 && salesOrderLine == 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取当前单据对象的集合
        /// </summary>
        /// <param name="docEntry"></param>
        /// <returns></returns>
        public OM_SalesOrderDataObject GetSalesOrderAndDetail(string salesOrder_Guid)
        {
            OM_SalesOrderDataObject salesOrderDataObject = this.GetSalesOrder(s => s.Guid == salesOrder_Guid).ToDTO();
            salesOrderDataObject.SalesOrderLine.AddRange(this.GetSalesOrderItemList(s => s.Order_Guid == salesOrder_Guid));

            return salesOrderDataObject;
        }
        private IList<OM_Order> GetSalesOrderList(Expression<Func<OM_Order, bool>> fuc)
        {
            return DbRepository.GetList(fuc);

        }
        /// <summary>
        /// 获取当前用户区域销售订单列表
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public List<OM_Order> GetCurrentSalesOrderList(string userGuid)
        {
            List<OM_User> listUser = userManager.GetAreaRoles(userGuid);
            List<OM_Order> listSalesOrder = new List<OM_Order>();
            foreach(var user in listUser)
            {
                listSalesOrder.AddRange(this.GetSalesOrderList(s => s.User_Guid == user.Guid));
            }

            return listSalesOrder;
        }

        private IList<OM_ProductPrice> GetProducePriceList(Expression<Func<OM_ProductPrice, bool>> fuc)
        {
            return DbRepository.GetList(fuc);

        }
        /// <summary>
        /// 获取当前区域的产品价格清单列表
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public List<OM_ProductPrice> GetCurrentProducePriceList(string itemCode, string userGuid)
        {
            //List<OM_ProductPrice> listProductPrice = new List<OM_ProductPrice>();

            return this.GetProducePriceList(p => p.Product_ItemCode == itemCode && userGuid == p.User_Guid).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public List<OM_User> GetCurrentUserByCardCode(string userGuid)
        {

            List<OM_User> listUsers = userManager.GetCurrentUserByCardCode(userGuid);

            return null;
        }

        #endregion
    }
}
