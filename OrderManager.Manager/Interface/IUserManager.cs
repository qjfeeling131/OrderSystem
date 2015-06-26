﻿using OrderManager.Model.DTO;
using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Manager
{
    public interface IUserManager
    {
        #region Save Method
        bool SaveUer(OM_User user);
        bool SaveLog(OM_Log log);
        bool SaveDepartment(OM_Department dep);

        bool SaveRole(OM_Role role);
        bool SaveRolePermission(OM_RolePermission rolePermission);
        bool SaveUserRole(OM_UserRole userRole);
        bool SavePermission(OM_Permission permission);
        #endregion

        #region Update Method
        bool UpdateUer(OM_User user);
        bool UpdateLog(OM_Log log);
        bool UpdateDepartment(OM_Department dep);
        bool UpdateRole(OM_Role role);
        bool UpdateRolePermission(OM_RolePermission rolePermission);
        bool UpdateUserRole(OM_UserRole userRole);
        bool UpdatePermission(OM_Permission permission);
        #endregion

        #region Delete Method
        bool DeleteUer(Expression<Func<OM_User, bool>> func);
        bool DeleteLog(Expression<Func<OM_Log, bool>> log);
        bool DeleteDepartment(Expression<Func<OM_Department, bool>> dep);
        bool DeleteRole(Expression<Func<OM_Role, bool>> role);
        bool DeleteRolePermission(Expression<Func<OM_RolePermission, bool>> rolePermission);
        bool DeleteUserRole(Expression<Func<OM_UserRole, bool>> userRole);

        bool DeletePermission(Expression<Func<OM_Permission, bool>> permission);
        #endregion

        #region Get Objects

        OM_User GetUser(Expression<Func<OM_User, bool>> fuc);
        IList<OM_Log> GetLogList(int PageIndex, int PageSize, Expression<Func<OM_Log, bool>> fuc, Expression<Func<OM_Log, object>> orderFuc);
        OM_Log GetLog(Expression<Func<OM_Log, bool>> fuc);
        IList<OM_Permission> GetPermissionList(int PageIndex, int PageSize, Expression<Func<OM_Permission, bool>> fuc, Expression<Func<OM_Permission, object>> orderFuc);

        OM_Permission GetPermission(Expression<Func<OM_Permission, bool>> fuc);

        IList<OM_Department> GetDepartmentList(int PageIndex, int PageSize, Expression<Func<OM_Department, bool>> fuc, Expression<Func<OM_Department, object>> orderFuc);
        OM_Department GetDepartment(Expression<Func<OM_Department, bool>> fuc);

        IList<OM_Role> GetRoleList(int PageIndex, int PageSize, Expression<Func<OM_Role, bool>> fuc, Expression<Func<OM_Role, object>> orderFuc);
        OM_Role GetRole(Expression<Func<OM_Role, bool>> fuc);

        IList<OM_RolePermission> GetRolePermissionList(int PageIndex, int PageSize, Expression<Func<OM_RolePermission, bool>> fuc, Expression<Func<OM_RolePermission, object>> orderFuc);
        OM_RolePermission GetRolePermission(Expression<Func<OM_RolePermission, bool>> fuc);

        IList<OM_UserRole> GetUserRoleList(int PageIndex, int PageSize, Expression<Func<OM_UserRole, bool>> fuc, Expression<Func<OM_UserRole, object>> orderFuc);

        OM_UserRole GetUserRole(Expression<Func<OM_UserRole, bool>> fuc);
        #endregion

        #region User Function

        OM_UserDetail GetUserDetail(string userGuid);

        bool Login(string userAccount, string password);

        List<OM_LogDataObject> GetCurrentUserLogs(string userId);

        List<OM_User> GetAreaRoles(string userId);

        IList<OM_User> GetUserList(Expression<Func<OM_User, bool>> fuc);

        bool ResetPassword(string userGuid, string newPwd);

        bool UpdatePassword(string userGuid, string oldPwd, string newPwd);

        List<OM_MessageBoard> GetCurrentUserMessageBoard(string userId);
        bool SaveMessageBoard(OM_MessageBoard msgBoard);
        OM_MessageBoard GetMessageBoard(Expression<Func<OM_MessageBoard, bool>> fuc);

        /// <summary>
        /// 获取当前区域用户下属的经销商、用户
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        List<OM_User> GetCurrentUserByCardCode(string userGuid);
        #endregion
    }
}

