
using Microsoft.Practices.Unity;
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

        #region Save Method
        public bool SaveProduct(OM_Product product)
        {
            if (DbRepository.Add(product) > 0)
            {
                return true;
            }
            return false;
        }

        public bool SaveSalesOrder(OM_Order saleOrder)
        {
            if (DbRepository.Add(saleOrder) > 0)
            {
                return true;
            }
            return false;
        }
        public bool SaveSalesOrderItem(OM_OrderItem saleOrderItem)
        {
            if (DbRepository.Add(saleOrderItem) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Update Method
        public bool UpdateProduct(OM_Product product)
        {
            if (DbRepository.Update(product) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSalesOrder(OM_Order saleOrder)
        {
            if (DbRepository.Update(saleOrder) > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateSalesOrderItem(OM_OrderItem saleOrderItem)
        {
            if (DbRepository.Update(saleOrderItem) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Update Method
        public bool DeleteProduct(Expression<Func<OM_Product, bool>> product)
        {
            if (DbRepository.Delete(product) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateSalesOrder(Expression<Func<OM_Order, bool>> saleOrder)
        {
            if (DbRepository.Delete(saleOrder) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteSalesOrderItem(Expression<Func<OM_OrderItem, bool>> saleOrderItem)
        {
            if (DbRepository.Delete(saleOrderItem) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region  Get one or manay Object

        public IList<OM_Product> GetProductList(int PageIndex, int PageSize, Expression<Func<OM_Product, bool>> fuc, Expression<Func<OM_Product, bool>> orderFuc)
        {
            return DbRepository.GetPagedList(PageIndex, PageSize, fuc, orderFuc);

        }

        public OM_Product GetProduct(Expression<Func<OM_Product, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }

        public IList<OM_Order> GetSalesOrderList(int PageIndex, int PageSize, Expression<Func<OM_Order, bool>> fuc, Expression<Func<OM_Order, bool>> orderFuc)
        {
            return DbRepository.GetPagedList(PageIndex, PageSize, fuc, orderFuc);

        }

        public OM_Order GetSalesOrder(Expression<Func<OM_Order, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }

        public IList<OM_OrderItem> GetSalesOrderItemList(int PageIndex, int PageSize, Expression<Func<OM_OrderItem, bool>> fuc, Expression<Func<OM_OrderItem, bool>> orderFuc)
        {
            return DbRepository.GetPagedList(PageIndex, PageSize, fuc, orderFuc);

        }

        public OM_OrderItem GetSalesOrderItem(Expression<Func<OM_OrderItem, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        } 
        #endregion
    }
}
