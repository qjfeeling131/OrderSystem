﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.UserService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Login", ReplyAction="http://tempuri.org/IUserService/LoginResponse")]
        OrderManager.Model.DTO.OM_UserDetail Login(string userAccount, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Login", ReplyAction="http://tempuri.org/IUserService/LoginResponse")]
        System.Threading.Tasks.Task<OrderManager.Model.DTO.OM_UserDetail> LoginAsync(string userAccount, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentUserLogs", ReplyAction="http://tempuri.org/IUserService/GetCurrentUserLogsResponse")]
        System.Collections.Generic.List<OrderManager.Model.DTO.OM_LogDataObject> GetCurrentUserLogs(string cipher, string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentUserLogs", ReplyAction="http://tempuri.org/IUserService/GetCurrentUserLogsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.DTO.OM_LogDataObject>> GetCurrentUserLogsAsync(string cipher, string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ResetPassword", ReplyAction="http://tempuri.org/IUserService/ResetPasswordResponse")]
        void ResetPassword(string cipher, string userGuid, string newPwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ResetPassword", ReplyAction="http://tempuri.org/IUserService/ResetPasswordResponse")]
        System.Threading.Tasks.Task ResetPasswordAsync(string cipher, string userGuid, string newPwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdatePassword", ReplyAction="http://tempuri.org/IUserService/UpdatePasswordResponse")]
        void UpdatePassword(string cipher, string userGuid, string oldPwd, string newPwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdatePassword", ReplyAction="http://tempuri.org/IUserService/UpdatePasswordResponse")]
        System.Threading.Tasks.Task UpdatePasswordAsync(string cipher, string userGuid, string oldPwd, string newPwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentUserList", ReplyAction="http://tempuri.org/IUserService/GetCurrentUserListResponse")]
        System.Collections.Generic.List<OrderManager.Model.Models.OM_User> GetCurrentUserList(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentUserList", ReplyAction="http://tempuri.org/IUserService/GetCurrentUserListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_User>> GetCurrentUserListAsync(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        OrderManager.Model.Models.OM_User GetUser(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetUser", ReplyAction="http://tempuri.org/IUserService/GetUserResponse")]
        System.Threading.Tasks.Task<OrderManager.Model.Models.OM_User> GetUserAsync(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/SaveMessageBoard", ReplyAction="http://tempuri.org/IUserService/SaveMessageBoardResponse")]
        bool SaveMessageBoard(string cipher, OrderManager.Model.Models.OM_MessageBoard msgBoard);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/SaveMessageBoard", ReplyAction="http://tempuri.org/IUserService/SaveMessageBoardResponse")]
        System.Threading.Tasks.Task<bool> SaveMessageBoardAsync(string cipher, OrderManager.Model.Models.OM_MessageBoard msgBoard);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentUserMessageBoard", ReplyAction="http://tempuri.org/IUserService/GetCurrentUserMessageBoardResponse")]
        System.Collections.Generic.List<OrderManager.Model.Models.OM_MessageBoard> GetCurrentUserMessageBoard(string cipher, string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentUserMessageBoard", ReplyAction="http://tempuri.org/IUserService/GetCurrentUserMessageBoardResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_MessageBoard>> GetCurrentUserMessageBoardAsync(string cipher, string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetMessageBoardModel", ReplyAction="http://tempuri.org/IUserService/GetMessageBoardModelResponse")]
        OrderManager.Model.Models.OM_MessageBoard GetMessageBoardModel(string cipher, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetMessageBoardModel", ReplyAction="http://tempuri.org/IUserService/GetMessageBoardModelResponse")]
        System.Threading.Tasks.Task<OrderManager.Model.Models.OM_MessageBoard> GetMessageBoardModelAsync(string cipher, string guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetOrderList", ReplyAction="http://tempuri.org/IUserService/GetOrderListResponse")]
        System.Collections.Generic.List<OrderManager.Model.Models.OM_Order> GetOrderList(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetOrderList", ReplyAction="http://tempuri.org/IUserService/GetOrderListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_Order>> GetOrderListAsync(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/SaveSalesOrder", ReplyAction="http://tempuri.org/IUserService/SaveSalesOrderResponse")]
        string SaveSalesOrder(string cipher, OrderManager.Model.DTO.OM_SalesOrderDataObject obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/SaveSalesOrder", ReplyAction="http://tempuri.org/IUserService/SaveSalesOrderResponse")]
        System.Threading.Tasks.Task<string> SaveSalesOrderAsync(string cipher, OrderManager.Model.DTO.OM_SalesOrderDataObject obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateSalesOrder", ReplyAction="http://tempuri.org/IUserService/UpdateSalesOrderResponse")]
        void UpdateSalesOrder(string cipher, OrderManager.Model.DTO.OM_SalesOrderDataObject obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateSalesOrder", ReplyAction="http://tempuri.org/IUserService/UpdateSalesOrderResponse")]
        System.Threading.Tasks.Task UpdateSalesOrderAsync(string cipher, OrderManager.Model.DTO.OM_SalesOrderDataObject obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetSalesOrderAndDetail", ReplyAction="http://tempuri.org/IUserService/GetSalesOrderAndDetailResponse")]
        OrderManager.Model.DTO.OM_SalesOrderDataObject GetSalesOrderAndDetail(string cipher, string salesOrder_Guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetSalesOrderAndDetail", ReplyAction="http://tempuri.org/IUserService/GetSalesOrderAndDetailResponse")]
        System.Threading.Tasks.Task<OrderManager.Model.DTO.OM_SalesOrderDataObject> GetSalesOrderAndDetailAsync(string cipher, string salesOrder_Guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentSalesOrderList", ReplyAction="http://tempuri.org/IUserService/GetCurrentSalesOrderListResponse")]
        System.Collections.Generic.List<OrderManager.Model.Models.OM_Order> GetCurrentSalesOrderList(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentSalesOrderList", ReplyAction="http://tempuri.org/IUserService/GetCurrentSalesOrderListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_Order>> GetCurrentSalesOrderListAsync(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentProducePriceList", ReplyAction="http://tempuri.org/IUserService/GetCurrentProducePriceListResponse")]
        System.Collections.Generic.List<OrderManager.Model.Models.OM_ProductPrice> GetCurrentProducePriceList(string cipher, string itemCode, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentProducePriceList", ReplyAction="http://tempuri.org/IUserService/GetCurrentProducePriceListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_ProductPrice>> GetCurrentProducePriceListAsync(string cipher, string itemCode, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentUserByCardCode", ReplyAction="http://tempuri.org/IUserService/GetCurrentUserByCardCodeResponse")]
        System.Collections.Generic.List<OrderManager.Model.Models.OM_User> GetCurrentUserByCardCode(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetCurrentUserByCardCode", ReplyAction="http://tempuri.org/IUserService/GetCurrentUserByCardCodeResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_User>> GetCurrentUserByCardCodeAsync(string cipher, string userGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetProductList", ReplyAction="http://tempuri.org/IUserService/GetProductListResponse")]
        System.Collections.Generic.List<OrderManager.Model.Models.OM_Product> GetProductList(string cipher, string searchKey, int pageIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetProductList", ReplyAction="http://tempuri.org/IUserService/GetProductListResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_Product>> GetProductListAsync(string cipher, string searchKey, int pageIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetProductListCount", ReplyAction="http://tempuri.org/IUserService/GetProductListCountResponse")]
        int GetProductListCount(string cipher, string searchKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetProductListCount", ReplyAction="http://tempuri.org/IUserService/GetProductListCountResponse")]
        System.Threading.Tasks.Task<int> GetProductListCountAsync(string cipher, string searchKey);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateSalesOrderStatusByCommit", ReplyAction="http://tempuri.org/IUserService/UpdateSalesOrderStatusByCommitResponse")]
        void UpdateSalesOrderStatusByCommit(string cipher, string orderGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateSalesOrderStatusByCommit", ReplyAction="http://tempuri.org/IUserService/UpdateSalesOrderStatusByCommitResponse")]
        System.Threading.Tasks.Task UpdateSalesOrderStatusByCommitAsync(string cipher, string orderGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateSalesOrderStatusByToSAP", ReplyAction="http://tempuri.org/IUserService/UpdateSalesOrderStatusByToSAPResponse")]
        void UpdateSalesOrderStatusByToSAP(string cipher, string orderGuid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/UpdateSalesOrderStatusByToSAP", ReplyAction="http://tempuri.org/IUserService/UpdateSalesOrderStatusByToSAPResponse")]
        System.Threading.Tasks.Task UpdateSalesOrderStatusByToSAPAsync(string cipher, string orderGuid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : Web.UserService.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<Web.UserService.IUserService>, Web.UserService.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public OrderManager.Model.DTO.OM_UserDetail Login(string userAccount, string password) {
            return base.Channel.Login(userAccount, password);
        }
        
        public System.Threading.Tasks.Task<OrderManager.Model.DTO.OM_UserDetail> LoginAsync(string userAccount, string password) {
            return base.Channel.LoginAsync(userAccount, password);
        }
        
        public System.Collections.Generic.List<OrderManager.Model.DTO.OM_LogDataObject> GetCurrentUserLogs(string cipher, string userId) {
            return base.Channel.GetCurrentUserLogs(cipher, userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.DTO.OM_LogDataObject>> GetCurrentUserLogsAsync(string cipher, string userId) {
            return base.Channel.GetCurrentUserLogsAsync(cipher, userId);
        }
        
        public void ResetPassword(string cipher, string userGuid, string newPwd) {
            base.Channel.ResetPassword(cipher, userGuid, newPwd);
        }
        
        public System.Threading.Tasks.Task ResetPasswordAsync(string cipher, string userGuid, string newPwd) {
            return base.Channel.ResetPasswordAsync(cipher, userGuid, newPwd);
        }
        
        public void UpdatePassword(string cipher, string userGuid, string oldPwd, string newPwd) {
            base.Channel.UpdatePassword(cipher, userGuid, oldPwd, newPwd);
        }
        
        public System.Threading.Tasks.Task UpdatePasswordAsync(string cipher, string userGuid, string oldPwd, string newPwd) {
            return base.Channel.UpdatePasswordAsync(cipher, userGuid, oldPwd, newPwd);
        }
        
        public System.Collections.Generic.List<OrderManager.Model.Models.OM_User> GetCurrentUserList(string cipher, string userGuid) {
            return base.Channel.GetCurrentUserList(cipher, userGuid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_User>> GetCurrentUserListAsync(string cipher, string userGuid) {
            return base.Channel.GetCurrentUserListAsync(cipher, userGuid);
        }
        
        public OrderManager.Model.Models.OM_User GetUser(string cipher, string userGuid) {
            return base.Channel.GetUser(cipher, userGuid);
        }
        
        public System.Threading.Tasks.Task<OrderManager.Model.Models.OM_User> GetUserAsync(string cipher, string userGuid) {
            return base.Channel.GetUserAsync(cipher, userGuid);
        }
        
        public bool SaveMessageBoard(string cipher, OrderManager.Model.Models.OM_MessageBoard msgBoard) {
            return base.Channel.SaveMessageBoard(cipher, msgBoard);
        }
        
        public System.Threading.Tasks.Task<bool> SaveMessageBoardAsync(string cipher, OrderManager.Model.Models.OM_MessageBoard msgBoard) {
            return base.Channel.SaveMessageBoardAsync(cipher, msgBoard);
        }
        
        public System.Collections.Generic.List<OrderManager.Model.Models.OM_MessageBoard> GetCurrentUserMessageBoard(string cipher, string userId) {
            return base.Channel.GetCurrentUserMessageBoard(cipher, userId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_MessageBoard>> GetCurrentUserMessageBoardAsync(string cipher, string userId) {
            return base.Channel.GetCurrentUserMessageBoardAsync(cipher, userId);
        }
        
        public OrderManager.Model.Models.OM_MessageBoard GetMessageBoardModel(string cipher, string guid) {
            return base.Channel.GetMessageBoardModel(cipher, guid);
        }
        
        public System.Threading.Tasks.Task<OrderManager.Model.Models.OM_MessageBoard> GetMessageBoardModelAsync(string cipher, string guid) {
            return base.Channel.GetMessageBoardModelAsync(cipher, guid);
        }
        
        public System.Collections.Generic.List<OrderManager.Model.Models.OM_Order> GetOrderList(string cipher, string userGuid) {
            return base.Channel.GetOrderList(cipher, userGuid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_Order>> GetOrderListAsync(string cipher, string userGuid) {
            return base.Channel.GetOrderListAsync(cipher, userGuid);
        }
        
        public string SaveSalesOrder(string cipher, OrderManager.Model.DTO.OM_SalesOrderDataObject obj) {
            return base.Channel.SaveSalesOrder(cipher, obj);
        }
        
        public System.Threading.Tasks.Task<string> SaveSalesOrderAsync(string cipher, OrderManager.Model.DTO.OM_SalesOrderDataObject obj) {
            return base.Channel.SaveSalesOrderAsync(cipher, obj);
        }
        
        public void UpdateSalesOrder(string cipher, OrderManager.Model.DTO.OM_SalesOrderDataObject obj) {
            base.Channel.UpdateSalesOrder(cipher, obj);
        }
        
        public System.Threading.Tasks.Task UpdateSalesOrderAsync(string cipher, OrderManager.Model.DTO.OM_SalesOrderDataObject obj) {
            return base.Channel.UpdateSalesOrderAsync(cipher, obj);
        }
        
        public OrderManager.Model.DTO.OM_SalesOrderDataObject GetSalesOrderAndDetail(string cipher, string salesOrder_Guid) {
            return base.Channel.GetSalesOrderAndDetail(cipher, salesOrder_Guid);
        }
        
        public System.Threading.Tasks.Task<OrderManager.Model.DTO.OM_SalesOrderDataObject> GetSalesOrderAndDetailAsync(string cipher, string salesOrder_Guid) {
            return base.Channel.GetSalesOrderAndDetailAsync(cipher, salesOrder_Guid);
        }
        
        public System.Collections.Generic.List<OrderManager.Model.Models.OM_Order> GetCurrentSalesOrderList(string cipher, string userGuid) {
            return base.Channel.GetCurrentSalesOrderList(cipher, userGuid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_Order>> GetCurrentSalesOrderListAsync(string cipher, string userGuid) {
            return base.Channel.GetCurrentSalesOrderListAsync(cipher, userGuid);
        }
        
        public System.Collections.Generic.List<OrderManager.Model.Models.OM_ProductPrice> GetCurrentProducePriceList(string cipher, string itemCode, string userGuid) {
            return base.Channel.GetCurrentProducePriceList(cipher, itemCode, userGuid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_ProductPrice>> GetCurrentProducePriceListAsync(string cipher, string itemCode, string userGuid) {
            return base.Channel.GetCurrentProducePriceListAsync(cipher, itemCode, userGuid);
        }
        
        public System.Collections.Generic.List<OrderManager.Model.Models.OM_User> GetCurrentUserByCardCode(string cipher, string userGuid) {
            return base.Channel.GetCurrentUserByCardCode(cipher, userGuid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_User>> GetCurrentUserByCardCodeAsync(string cipher, string userGuid) {
            return base.Channel.GetCurrentUserByCardCodeAsync(cipher, userGuid);
        }
        
        public System.Collections.Generic.List<OrderManager.Model.Models.OM_Product> GetProductList(string cipher, string searchKey, int pageIndex) {
            return base.Channel.GetProductList(cipher, searchKey, pageIndex);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<OrderManager.Model.Models.OM_Product>> GetProductListAsync(string cipher, string searchKey, int pageIndex) {
            return base.Channel.GetProductListAsync(cipher, searchKey, pageIndex);
        }
        
        public int GetProductListCount(string cipher, string searchKey) {
            return base.Channel.GetProductListCount(cipher, searchKey);
        }
        
        public System.Threading.Tasks.Task<int> GetProductListCountAsync(string cipher, string searchKey) {
            return base.Channel.GetProductListCountAsync(cipher, searchKey);
        }
        
        public void UpdateSalesOrderStatusByCommit(string cipher, string orderGuid) {
            base.Channel.UpdateSalesOrderStatusByCommit(cipher, orderGuid);
        }
        
        public System.Threading.Tasks.Task UpdateSalesOrderStatusByCommitAsync(string cipher, string orderGuid) {
            return base.Channel.UpdateSalesOrderStatusByCommitAsync(cipher, orderGuid);
        }
        
        public void UpdateSalesOrderStatusByToSAP(string cipher, string orderGuid) {
            base.Channel.UpdateSalesOrderStatusByToSAP(cipher, orderGuid);
        }
        
        public System.Threading.Tasks.Task UpdateSalesOrderStatusByToSAPAsync(string cipher, string orderGuid) {
            return base.Channel.UpdateSalesOrderStatusByToSAPAsync(cipher, orderGuid);
        }
    }
}
