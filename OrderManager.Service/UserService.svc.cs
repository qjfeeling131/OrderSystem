using Microsoft.Practices.Unity;
using OrderManager.Common;
using OrderManager.Manager;
using OrderManager.Model.DTO;
using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    public class UserService : IUserService
    {
        [Dependency]
        public IUserManager userManager { get; set; }

        [Dependency]
        public ILogManager logManager { get; set; }

        [Dependency]
        public IOrderManger orderManger { get; set; }


        public OM_UserDetail Login(string userAccount, string password)
        {
            var result = userManager.Login(userAccount, password);
            if (result == false)
                throw new GenericException("账户或密码错误，请再次检查输入", OM_ExceptionCodeEnum.LOGIN.ToString());

            var user = userManager.GetUser(f => f.Account == userAccount && f.Pwd == password);

            user.UpdateDatetime = DateTime.Now;
            user.Key = Encryptor.MD5Encrypt(user.ID + user.Account + user.Pwd + user.CreateDatetime + user.Area_Guid + user.UpdateDatetime);
            userManager.UpdateUer(user);

            var re = userManager.GetUserDetail(user.Guid);

            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "User/Login",
                Guid = Guid.NewGuid().ToString(),
                Operation = "登陆",
                User_Guid = user.Guid,
                Message = string.Format("用户[{0}] : '{1}' 登陆了系统.", user.Name, DateTime.Now)
            };
            logManager.WriteLog(log);

            return re;
        }

        public List<OM_User> GetCurrentUserList(string cipher, string userGuid)
        {
            var result = userManager.GetAreaRoles(userGuid);

            return result;
        }

        public List<OM_LogDataObject> GetCurrentUserLogs(string cipher, string userId)
        {
            return userManager.GetCurrentUserLogs(userId);
        }

        public void ResetPassword(string cipher, string userGuid, string newPwd)
        {
            var result = userManager.ResetPassword(userGuid, newPwd);
            if (result == false)
                throw new GenericException("重设用户密码失败");

            var user = userManager.GetUser(s => s.Guid == userGuid);
            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "User/ResetPassword",
                Guid = Guid.NewGuid().ToString(),
                Operation = "重设用户密码",
                User_Guid = cipher,
                Message = string.Format("'{0}' 重设用户 [{1}] 密码.", DateTime.Now, user.Name)
            };
            logManager.WriteLog(log);
        }

        public void UpdatePassword(string cipher, string userGuid, string oldPwd, string newPwd)
        {
            var result = userManager.UpdatePassword(userGuid, oldPwd, newPwd);
            if (result == false)
                throw new GenericException("更新用户密码失败");

            var user = userManager.GetUser(s => s.Guid == userGuid);
            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "User/Login",
                Guid = Guid.NewGuid().ToString(),
                Operation = "修改密码",
                User_Guid = cipher,
                Message = string.Format("用户[{0}] : '{1}' 修改了密码.", user.Name, DateTime.Now)
            };
            logManager.WriteLog(log);

        }

        public OM_User GetUser(string cipher, string userGuid)
        {
            var user = userManager.GetUser(a => a.Guid == userGuid);
            if (user == null)
                throw new GenericException("用户不存在");
            return user;
        }


        public List<OM_MessageBoard> GetCurrentUserMessageBoard(string cipher, string userId)
        {
            return userManager.GetCurrentUserMessageBoard(userId);
        }


        public bool SaveMessageBoard(string cipher, OM_MessageBoard msgBoard)
        {
            var result = userManager.SaveMessageBoard(msgBoard);
            if (result)
            {
                var user = userManager.GetUser(s => s.Guid == cipher);
                var log = new OM_Log
                {
                    CreateDatetime = DateTime.Now,
                    Doc_View = "Log/MessageBoard",
                    Guid = Guid.NewGuid().ToString(),
                    Operation = "留言",
                    User_Guid = cipher,
                    Message = string.Format("用户[{0}] : '{1}' 留了一条信息.", user.Name, DateTime.Now)
                };
                logManager.WriteLog(log);
            }
            return result;
        }

        public OM_MessageBoard GetMessageBoardModel(string cipher, string guid)
        {
            return userManager.GetMessageBoard(m => m.Guid == guid);
        }

        #region Order

        public IList<OM_Order> GetOrderList(string cipher, string userGuid)
        {
            int count = 0;
            var result = orderManger.GetSalesOrderList(new PageListParameter<OM_Order, int>
            {
                isAsc = true,
                orderByLambda = s => s.DocEntry,
                pageIndex = 0,
                pageSize = int.MaxValue,
                whereLambda = s => s.User_Guid == userGuid,
            }, out count);
            return result;
        }

        public string SaveSalesOrder(string cipher, OM_SalesOrderDataObject obj)
        {
            var result = orderManger.SaveSalesOrder(obj);
            if (!result)
                throw new GenericException("保存草稿失败。");

            var user = userManager.GetUser(s => s.Guid == cipher);
            var order = orderManger.GetSalesOrder(s => s.Guid == obj.Guid);
            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "Order/UpdateStatus",
                Guid = Guid.NewGuid().ToString(),
                Operation = "保存草稿",
                User_Guid = user.Guid,
                Message = string.Format("用户[{0}] : '{1}' 保存草稿【{2}】.", user.Name, DateTime.Now, order.DocEntry)
            };
            logManager.WriteLog(log);
            return order.Guid;
        }


        public void UpdateSalesOrder(string cipher, OM_SalesOrderDataObject obj)
        {
            orderManger.UpdateSalesOrder(obj);

            var user = userManager.GetUser(s => s.Guid == cipher);
            var order = orderManger.GetSalesOrder(s => s.Guid == obj.Guid);
            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "Order/UpdateStatus",
                Guid = Guid.NewGuid().ToString(),
                Operation = "修改草稿",
                User_Guid = user.Guid,
                Message = string.Format("用户[{0}] : '{1}' 修改草稿【{2}】.", user.Name, DateTime.Now, order.DocEntry)
            };
            logManager.WriteLog(log);

        }

        public OM_SalesOrderDataObject GetSalesOrderAndDetail(string cipher, string salesOrder_Guid)
        {
            return orderManger.GetSalesOrderAndDetail(salesOrder_Guid);
        }


        public List<OM_Order> GetCurrentSalesOrderList(string cipher, string userGuid)
        {
            return orderManger.GetCurrentSalesOrderList(userGuid);
        }


        public List<OM_ProductPrice> GetCurrentProducePriceList(string cipher, string itemCode, string cardCode)
        {
            return orderManger.GetCurrentProducePriceList(itemCode, cardCode);
        }


        public List<OM_User> GetCurrentUserByCardCode(string cipher, string userGuid)
        {
            return userManager.GetCurrentUserByCardCode(userGuid);
        }


        public IList<OM_ProductInfo> GetProductList(string cipher, string CardCode,string searchKey, int pageIndex)
        {
            int count = 0;
            PageListParameter<OM_Product, string> parameter = new PageListParameter<OM_Product, string>();
            parameter.whereLambda = s => (s.ItemCode.Contains(searchKey.ToUpper()) || s.ItemName.Contains(searchKey)) 
                                            && s.CardCode==CardCode
                                            && (s.ParentId == null || s.ParentId == s.ItemCode); // randy
            parameter.pageIndex = pageIndex;
            parameter.orderByLambda = s => s.ItemCode;
            parameter.pageSize = 5;

            IList<OM_ProductInfo> result = new List<OM_ProductInfo>();
            var productList = orderManger.GetProductList(parameter, out count);


            var user = userManager.GetUser(s => s.Account == CardCode);

         
            foreach (var item in productList)
            {
                var listPrice = orderManger.GetCurrentProducePriceList(item.ItemCode, user.Guid);
                List<OM_ProductInfo> children = orderManger.GetChildProductRecursion(item.CardCode, item.ItemCode, user.Guid);

                OM_ProductInfo product = new OM_ProductInfo();           
                product.ItemName = item.ItemName;
                product.ItemCode = item.ItemCode;
                product.ChildNode = children;
                product.Price =listPrice.Select(a => a.Price.ToString("0.00")).ToArray();

                result.Add(product);
            }
            return result;
        }

    


        public int GetProductListCount(string cipher, string CardCode, string searchKey)
        {
            int count = 0;
            PageListParameter<OM_Product, string> parameter = new PageListParameter<OM_Product, string>();
            parameter.whereLambda = s => (s.ItemCode.Contains(searchKey.ToUpper()) || s.ItemName.Contains(searchKey))
                                            && s.CardCode == CardCode
                                            && (s.ParentId == null || s.ParentId == s.ItemCode);
            parameter.orderByLambda = s => s.ItemCode;
            parameter.pageSize = int.MaxValue;
            parameter.pageIndex = 0;
            orderManger.GetProductList(parameter, out count);

            return count;
        }


        public void UpdateSalesOrderStatusByCommit(string cipher, string orderGuid)
        {
            orderManger.UpdateSalesOrderStatusByCommit(orderGuid);

            var user = userManager.GetUser(s => s.Guid == cipher);
            var order = orderManger.GetSalesOrder(s => s.Guid == orderGuid);
            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "Order/UpdateStatus",
                Guid = Guid.NewGuid().ToString(),
                Operation = "提交订单",
                User_Guid = user.Guid,
                Message = string.Format("用户[{0}] : '{1}' 提交订单【{2}】.", user.Name, DateTime.Now, order.DocEntry)
            };
            logManager.WriteLog(log);

        }


        public void UpdateSalesOrderStatusByToSAP(string cipher, string orderGuid)
        {
            orderManger.UpdateSalesOrderStatusByToSAP(orderGuid);

            var user = userManager.GetUser(s => s.Guid == cipher);
            var order = orderManger.GetSalesOrder(s => s.Guid == orderGuid);
            var log = new OM_Log
            {
                CreateDatetime = DateTime.Now,
                Doc_View = "Order/UpdateStatus",
                Guid = Guid.NewGuid().ToString(),
                Operation = "对接订单到SAP",
                User_Guid = user.Guid,
                Message = string.Format("用户[{0}] : '{1}' 对接订单【{2}】到SAP.", user.Name, DateTime.Now, order.DocEntry)
            };
            logManager.WriteLog(log);
        }

        #endregion

    }
}

