
using Microsoft.Practices.Unity;
using OrderManager.Common;
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


        public OM_Product GetProduct(Expression<Func<OM_Product, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }

        public OM_Order GetSalesOrder(Expression<Func<OM_Order, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }


        public IList<OM_Order> GetSalesOrderList<Tkey>(PageListParameter<OM_Order, Tkey> parameter, out int count)
        {
            var result = DbRepository.GetPagedList<OM_Order, Tkey>(parameter, out count);
            return result;
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

        public IList<OM_Product> GetProductList<Tkey>(PageListParameter<OM_Product, Tkey> parameter, out int count)
        {
            //return DbRepository.GetList(fuc);
            return DbRepository.GetPagedList(parameter, out count);

        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <returns></returns>
        public bool SaveSalesOrder(OM_SalesOrderDataObject salesOrder)
        {
            OM_Order order = salesOrder.ToDTO();

            var user = DbRepository.GetModel<OM_User>(s => s.Account.ToUpper() == salesOrder.CardCode.ToUpper() && s.IsDel == false);
            if (user == null)
                throw new GenericException("客户代码不存在，保持草稿失败");

            //order.Guid = Guid.NewGuid().ToString();
            //order.CardName = user.Name;
            order.DocStatus = ((int)OM_DocStatusEnum.未提交).ToString();

            var salesOrderHead = DbRepository.Add(order);
            if (salesOrderHead <= 0)
                throw new GenericException("保存草稿失败");


            var orderResult = DbRepository.GetModel<OM_Order>(s => s.Guid == order.Guid);

            List<OM_OrderItem> items = new List<OM_OrderItem>();
            foreach (var item in salesOrder.SalesOrderLine)
            {
                OM_OrderItem oi = new OM_OrderItem()
                {
                    Guid = Guid.NewGuid().ToString().ToUpper(),
                    Currency = item.Currency,
                    ItemCode = item.ItemCode,
                    ItemName = item.ItemName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    TotalPrice = item.Price * item.Quantity,
                    Remarks = item.Remarks,
                    Order_Guid = orderResult.Guid,
                    DocEntry = orderResult.DocEntry

                };
                items.Add(oi);
            }

            var salesOrderLine = DbRepository.AddRange(items);

            if (salesOrderLine <= 0)
                throw new GenericException("保存草稿失败");

            return true;
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="salesOrder"></param>
        /// <returns></returns>
        public bool UpdateSalesOrder(OM_SalesOrderDataObject salesOrder)
        {
            OM_Order temp = salesOrder.ToDTO();

            var order = DbRepository.GetModel<OM_Order>(s => s.Guid == salesOrder.Guid);
            if (order == null)
                throw new GenericException("订单号不存在，修改草稿失败");

            var user = DbRepository.GetModel<OM_User>(s => s.Account.ToUpper() == salesOrder.CardCode.ToUpper() && s.IsDel == false);
            if (user == null)
                throw new GenericException("客户代码不存在，修改草稿失败");

            order.CardCode = salesOrder.CardCode;
            order.CardName = user.Name;
            order.Remarks = salesOrder.Remarks;
            order.DocDate = salesOrder.DocDate;

            var salesOrderHead = DbRepository.Update(order);
            if (salesOrderHead <= 0)
                throw new GenericException("修改草稿失败");

            List<OM_OrderItem> items = DbRepository.GetList<OM_OrderItem>(s => s.Order_Guid == salesOrder.Guid);
            List<OM_OrderItem> removeItem = new List<OM_OrderItem>();
            foreach (var item in salesOrder.SalesOrderLine)  //temp
            {
                foreach (var i in items)  //数据库
                {
                    if (string.IsNullOrWhiteSpace(item.Guid))
                    {
                        item.Guid = Guid.NewGuid().ToString();
                        item.DocEntry = salesOrder.DocEntry;
                        item.Order_Guid = salesOrder.Guid;
                        DbRepository.Add(item);
                    }
                    else
                    {  //不为空并且在数据库中找不到对应
                        var exist = salesOrder.SalesOrderLine.Where(s => s.Guid == i.Guid);
                        if ((exist == null || exist.Count() == 0) && !removeItem.Contains(i))
                        {
                            removeItem.Add(i);
                        }
                    }

                    if (i.Guid == item.Guid)
                    {
                        i.ItemCode = item.ItemCode;
                        i.ItemName = item.ItemName;
                        i.Remarks = item.Remarks;
                        i.Price = item.Price;
                        i.Quantity = item.Quantity;
                        i.TotalPrice = item.Price * item.Quantity;
                    }
                }
            }

            var salesOrderLine = DbRepository.UpdateRange(items);


            foreach (var delItem in removeItem)
            {
                DbRepository.RealDelete<OM_OrderItem>(s => s.Guid == delItem.Guid);
            }



            if (salesOrderLine <= 0)
                throw new GenericException("修改草稿失败");

            return true;
        }

        public bool UpdateSalesOrderStatusByCommit(string orderGuid)
        {
            var salesOrder = this.GetSalesOrder(s => s.Guid == orderGuid);

            if (salesOrder == null)
            {
                throw new GenericException("当前订单不存在,请检查数据");
            }

            salesOrder.DocStatus = ((int)OM_DocStatusEnum.已提交).ToString();
            if (DbRepository.Update(salesOrder) > 0)
            {
                return true;

            }

            throw new GenericException("更新失败,请联系系统管理员");
        }
        public bool UpdateSalesOrderStatusByToSAP(string orderGuid)
        {
            var salesOrder = this.GetSalesOrder(s => s.Guid == orderGuid);
            if (salesOrder == null)
            {
                throw new GenericException("当前订单不存在,请检查数据");
            }

            OM_SalesOrderDataObject salesOrderDataObject = salesOrder.ToDTO();
            salesOrderDataObject.SalesOrderLine = this.GetSalesOrderItemList(s => s.Order_Guid == orderGuid).ToList();
            if (salesOrderDataObject.SalesOrderLine == null)
            {
                throw new GenericException("当前订单行不存在,请检查数据");
            }

            //对接SAP实现
            if (SaveForSAP(salesOrderDataObject))
            {
                salesOrder.DocStatus = ((int)OM_DocStatusEnum.已对接).ToString();
                if (DbRepository.Update(salesOrder) > 0)
                {
                    return true;
                }
            }


            throw new GenericException("更新失败,请联系系统管理员");
        }

        private bool SaveForSAP(OM_SalesOrderDataObject salesOrder)
        {
            return B1Company.SBOCompany.SaveSalesOrderDraft(salesOrder);

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
            foreach (var user in listUser)
            {
                listSalesOrder.AddRange(this.GetSalesOrderList(s => s.User_Guid == user.Guid));
            }

            return listSalesOrder;
        }


        private List<OM_ProductPrice> GetProducePriceList(Expression<Func<OM_ProductPrice, bool>> fuc)
        {
            return DbRepository.GetList(fuc);

        }
        /// <summary>
        /// 获取当前区域的产品价格清单列表
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public List<OM_ProductPrice> GetCurrentProducePriceList(string itemCode, string cardCode)
        {
            //List<OM_ProductPrice> listProductPrice = new List<OM_ProductPrice>();

            if (string.IsNullOrEmpty(cardCode) || cardCode == null)
            {
                throw new GenericException("客户代码不能为空");
            }
            //if (string.IsNullOrEmpty(itemCode) || itemCode == null)
            //{
            //    throw new GenericException("物料代码不能为空");
            //}

            var user = userManager.GetUser(u => u.Guid == cardCode);

            if (user == null)
            {
                throw new GenericException("当前客户不存在");
            }
            //List<string> listUserGuids = new List<string>();

            //var temp1 = GetProducePriceList(p => p.Product_ItemCode == "PI00012" & p.User_Guid == "317122F3-0C0E-4626-883C-4F0D4669A89D");
            //var temp = GetProducePriceList(p => p.Product_ItemCode == itemCode & p.User_Guid == user.Guid);
            return this.GetProducePriceList(p => p.Product_ItemCode.Trim() == itemCode.Trim() & user.Guid.Trim().ToLower() == p.User_Guid.Trim().ToLower()).ToList();
        }



        public List<OM_ProductInfo> GetChildProductRecursion(string cardCode, string itemCode, string userGuid)
        {

            var result = DbRepository.GetList<OM_Product>(a => a.CardCode == cardCode && a.ParentId == itemCode);

            if (result == null || result.Count == 0)
            {
                return null;
            }
            else
            {
                var infos = new List<OM_ProductInfo>();
                foreach (var item in result)
                {
                    var listPrice = GetCurrentProducePriceList(item.ItemCode, userGuid);
                    var nodes = GetChildProductRecursion(item.CardCode, item.ItemCode, userGuid);
                    OM_ProductInfo product = new OM_ProductInfo();
                    product.Price = listPrice.Select(a => a.Price.ToString("0.00")).ToArray();
                    product.ItemCode = item.ItemCode;
                    product.ItemName = item.ItemName;
                    product.ChildNode = nodes;

                }
                return infos;
            }
        }


        #endregion


    }
}
