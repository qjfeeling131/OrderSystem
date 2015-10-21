﻿using Microsoft.Practices.Unity;
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
    public class UserManager : BaseManger, IUserManager
    {

        #region Save Method
        public bool SaveUer(OM_User user)
        {
            if (DbRepository.Add(user) > 0)
            {
                return true;
            }
            return false;
        }
        public bool SaveLog(OM_Log log)
        {
            if (DbRepository.Add(log) > 0)
            {
                return true;
            }
            return false;
        }
        public bool SaveDepartment(OM_Department dep)
        {
            if (DbRepository.Add(dep) > 0)
            {
                return true;
            }
            return false;
        }

        public bool SaveRole(OM_Role role)
        {
            if (DbRepository.Add(role) > 0)
            {
                return true;
            }
            return false;
        }
        public bool SaveRolePermission(OM_RolePermission rolePermission)
        {
            if (DbRepository.Add(rolePermission) > 0)
            {
                return true;
            }
            return false;
        }
        public bool SaveUserRole(OM_UserRole userRole)
        {
            if (DbRepository.Add(userRole) > 0)
            {
                return true;
            }
            return false;
        }

        public bool SavePermission(OM_Permission permission)
        {
            if (DbRepository.Add(permission) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Update Method
        public bool UpdateUer(OM_User user)
        {
            if (user != null)
                user.UpdateDatetime = DateTime.Now;
            if (DbRepository.Update(user) > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateLog(OM_Log log)
        {
            if (DbRepository.Update(log) > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateDepartment(OM_Department dep)
        {
            if (DbRepository.Update(dep) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateRole(OM_Role role)
        {
            if (DbRepository.Update(role) > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateRolePermission(OM_RolePermission rolePermission)
        {
            if (DbRepository.Update(rolePermission) > 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateUserRole(OM_UserRole userRole)
        {
            if (DbRepository.Update(userRole) > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdatePermission(OM_Permission permission)
        {
            if (DbRepository.Update(permission) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Delete Method
        public bool DeleteUer(Expression<Func<OM_User, bool>> func)
        {
            if (DbRepository.Delete(func) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteLog(Expression<Func<OM_Log, bool>> log)
        {
            if (DbRepository.Update(log) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteDepartment(Expression<Func<OM_Department, bool>> dep)
        {
            if (DbRepository.Update(dep) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteRole(Expression<Func<OM_Role, bool>> role)
        {
            if (DbRepository.Update(role) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteRolePermission(Expression<Func<OM_RolePermission, bool>> rolePermission)
        {
            if (DbRepository.Update(rolePermission) > 0)
            {
                return true;
            }
            return false;
        }
        public bool DeleteUserRole(Expression<Func<OM_UserRole, bool>> userRole)
        {
            if (DbRepository.Update(userRole) > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeletePermission(Expression<Func<OM_Permission, bool>> permission)
        {
            if (DbRepository.Update(permission) > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Get one or manay Object

        public OM_User GetUser(Expression<Func<OM_User, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }


        public OM_Log GetLog(Expression<Func<OM_Log, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }

        public OM_Permission GetPermission(Expression<Func<OM_Permission, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }


        public OM_Department GetDepartment(Expression<Func<OM_Department, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }


        public OM_Role GetRole(Expression<Func<OM_Role, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }

        public OM_RolePermission GetRolePermission(Expression<Func<OM_RolePermission, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }



        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="fuc"></param>
        /// <returns></returns>
        public OM_UserRole GetUserRole(Expression<Func<OM_UserRole, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);

        }
        #endregion

        #region Function

        public OM_UserDetail GetUserDetail(string userGuid)
        {
            OM_UserDetail result = new OM_UserDetail();
            result.User = GetUser(o => o.Guid == userGuid);

            var userRole = GetUserRole(o => o.User_Guid == userGuid);

            result.Role = GetRole(o => o.Guid == userRole.Role_Guid);

            return result;
        }

        public bool Login(string userAccount, string password)
        {
            bool result = false;
            var user = GetUser(f => f.Account == userAccount && f.Pwd == password && f.IsDel == false);
            if (user != null)
            {
                result = true;
            }
            return result;
        }


        public bool ResetPassword(string userGuid, string newPwd)
        {
            var user = GetUser(o => o.Guid == userGuid);
            if (user == null)
                throw new GenericException("当前用户不存在");

            user.Pwd = newPwd;
            var result = UpdateUer(user);

            return result;
        }


        public bool UpdatePassword(string userGuid, string oldPwd, string newPwd)
        {
            var user = GetUser(o => o.Guid == userGuid);
            if (user == null)
                throw new GenericException("当前用户不存在", OM_ExceptionCodeEnum.REDIRECT_LOGIN.ToString());

            if (user.Pwd != oldPwd)
                throw new GenericException("旧密码错误，更新密码失败。");

            user.Pwd = newPwd;
            var result = UpdateUer(user);
            return result;

        }

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="fuc"></param>
        /// <returns></returns>
        public IList<OM_Role> GetRoles(Expression<Func<OM_Role, bool>> fuc)
        {
            return DbRepository.GetList(fuc);
        }

        /// <summary>
        /// 获取当前用户集合
        /// </summary>
        /// <param name="fuc"></param>
        /// <returns></returns>
        public IList<OM_User> GetUserList(Expression<Func<OM_User, bool>> fuc)
        {
            return DbRepository.GetList(fuc);
        }
        public IList<OM_UserRole> GetUserRoleList(Expression<Func<OM_UserRole, bool>> fuc)
        {
            return DbRepository.GetList(fuc);
        }

        public IList<OM_Log> GetLogList(Expression<Func<OM_Log, bool>> fuc)
        {
            return DbRepository.GetList(fuc);
        }
        //public List<OM_User> GetCurrentUser(string userId)
        //{

        //    List<OM_AreaRoles> listRoles = GetAreaRoles(userId);
        //    if (listRoles != null)
        //    {

        //    }
        //}
        public List<OM_LogDataObject> GetCurrentUserLogs(string userId)
        {
            List<OM_User> listUsers = this.GetAreaRoles(userId);

            if (listUsers == null)
            {
                return null;
            }
            //List<OM_Log> listCurrentUserLogs = new List<OM_Log>();
            List<OM_LogDataObject> listLogDataObject = new List<OM_LogDataObject>();
            foreach (var item in listUsers)
            {
                listLogDataObject.AddRange(GetLogList(l => l.User_Guid == item.Guid).Select(c => c.DTO(item.Name)));
                //listCurrentUserLogs.AddRange(GetLogList(l => l.User_Guid == item.Guid).ToList());
            }
            return listLogDataObject.OrderByDescending(l => l.CreateDatetime).ToList();
        }
        /// <summary>
        /// 模糊查询日记
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="serVal"></param>
        /// <returns></returns>
        public List<OM_LogDataObject> GetCurrentUserLogs(string userId, string serVal)
        {
            List<OM_User> listUsers = this.GetAreaRoles(userId);
            if (listUsers == null)
            {
                return null;
            }
            //List<OM_Log> listCurrentUserLogs = new List<OM_Log>();
            List<OM_LogDataObject> listLogDataObject = new List<OM_LogDataObject>();
            foreach (var item in listUsers)
            {
                listLogDataObject.AddRange(GetLogList(l => l.User_Guid == item.Guid && (l.Doc_View.Contains(serVal) || l.Doc_Name.Contains(serVal) || l.Operation.Contains(serVal) || l.CreateDatetime.ToString().Contains(serVal))).Select(c => c.DTO(item.Name)));
                //listCurrentUserLogs.AddRange(GetLogList(l => l.User_Guid == item.Guid).ToList());
            }
            return listLogDataObject.OrderByDescending(l => l.CreateDatetime).ToList();
        }

        /// <summary>
        /// 获取当前区域用户下属的经销商、用户
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public List<OM_User> GetCurrentUserByCardCode(string userGuid)
        {

            OM_UserRole userRole = GetUserRole(c => c.User_Guid == userGuid);

            OM_User currentUser = GetUser(u => u.Guid == userGuid && u.IsDel == false);
            if (currentUser == null)
            {
                return null;
            }
            List<OM_User> listUsers = new List<OM_User>();
            listUsers.Add(currentUser);
            OM_Role role = GetRole(c => c.Guid == userRole.Role_Guid);

            List<OM_Role> roles = GetRoles(r => r.IsDel == false).ToList();

            List<OM_AreaRoles> listRoles = new List<OM_AreaRoles>();
            GetRolesTree(role.ID, listRoles, roles);
            List<OM_User> listNewUsers = null;
            if (listRoles != null)
            {
                List<string> listUserGuid = new List<string>();

                GetListUserGuid(listUserGuid, listRoles);
                if (currentUser.Account == currentUser.ParentCode)
                {
                    listUsers.AddRange(GetUserList(u => listUserGuid.Contains(u.Guid) && u.Area_Guid == currentUser.Area_Guid && u.IsDel == false).ToList());
                }
                else
                {
                    listUsers.AddRange(GetUserList(u => listUserGuid.Contains(u.Guid) && u.Area_Guid == currentUser.Area_Guid && u.IsDel == false && u.ParentCode == currentUser.Account).ToList());
                }
                List<OM_UserRole> listUserRoles = GetUserRoleList(u => (u.Role_Guid == "AA196056-70EE-45BF-A56A-A90070DA1425" || u.Role_Guid == "57BE06DB-BA09-49B7-A1D8-795EFA25F392")).ToList();
                listNewUsers = new List<OM_User>();
                foreach (var item in listUsers)
                {
                    foreach (var cardCode in listUserRoles)
                    {
                        if (item.Guid == cardCode.User_Guid)
                        {
                            if (!listNewUsers.Contains(item))
                            {
                                listNewUsers.Add(item);
                            }

                        }
                    }
                }
            }
            return listNewUsers;

        }

        /// <summary>
        /// 获取当前用户登陆信息以及其管理的其它用户
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public List<OM_User> GetAreaRoles(string userId)
        {

            OM_UserRole userRole = GetUserRole(c => c.User_Guid == userId);

            OM_User currentUser = GetUser(u => u.Guid == userId && u.IsDel == false);
            if (currentUser == null)
            {
                return null;
            }
            List<OM_User> listUsers = new List<OM_User>();
            listUsers.Add(currentUser);
            OM_Role role = GetRole(c => c.Guid == userRole.Role_Guid);

            List<OM_Role> roles = GetRoles(r => r.IsDel == false).ToList();

            List<OM_AreaRoles> listRoles = new List<OM_AreaRoles>();

            GetRolesTree(role.ID, listRoles, roles);
            if (listRoles != null)
            {
                List<string> listUserGuid = new List<string>();

                GetListUserGuid(listUserGuid, listRoles);
                if (currentUser.Account == currentUser.ParentCode)
                {
                    listUsers.AddRange(GetUserList(u => listUserGuid.Contains(u.Guid) && u.Area_Guid == currentUser.Area_Guid && u.IsDel == false).ToList());
                }
                else
                {
                    listUsers.AddRange(GetUserList(u => listUserGuid.Contains(u.Guid) && u.Area_Guid == currentUser.Area_Guid && u.IsDel == false && u.ParentCode == currentUser.Account).ToList());
                }

            }
            return listUsers;
        }


        private void GetListUserGuid(List<string> listUserGuid, List<OM_AreaRoles> listRoles)
        {
            foreach (var role in listRoles)
            {
                listUserGuid.AddRange(GetUserRoleList(c => c.Role_Guid == role.Guid && c.IsDel == false).Select(r => r.User_Guid).ToList());
                if (role.ChildRoles.Count > 0)
                {
                    GetListUserGuid(listUserGuid, role.ChildRoles);
                }
            }
        }
        private void GetRolesTree(int roleId, List<OM_AreaRoles> listRoles, List<OM_Role> roles)
        {
            foreach (var role in roles)
            {
                if (role.ParentID == roleId)
                {
                    OM_AreaRoles areaRoles = new OM_AreaRoles();
                    areaRoles.ID = role.ID;
                    areaRoles.Name = role.Name;
                    areaRoles.ParentID = Convert.ToInt32(role.ParentID);
                    areaRoles.Guid = role.Guid;
                    areaRoles.IsDel = role.IsDel;
                    areaRoles.Department_Guid = role.Department_Guid;
                    areaRoles.CreateDatetiime = role.CreateDatetiime;
                    areaRoles.UpdateDateTime = role.UpdateDateTime;
                    listRoles.Add(areaRoles);
                    GetRolesTree(role.ID, areaRoles.ChildRoles, roles);
                }

            }
        }
        #endregion


        /// <summary>
        /// 获取区域用户的日记集合-分页
        /// </summary>          
        public List<OM_MessageBoard> GetCurrentUserMessageBoard(string userId)
        {
            List<OM_User> listUsers = this.GetAreaRoles(userId);

            if (listUsers == null)
            {
                return null;
            }
            List<OM_MessageBoard> listMsgBoardDataObject = new List<OM_MessageBoard>();
            foreach (var item in listUsers)
            {
                listMsgBoardDataObject.AddRange(GetMessageBoardList(m => m.User_Guid == item.Guid));
            }
            return listMsgBoardDataObject.OrderByDescending(m => m.CreateDatetime).ToList();
        }


        private IList<OM_MessageBoard> GetMessageBoardList(Expression<Func<OM_MessageBoard, bool>> whereLambda)
        {
            return DbRepository.GetList<OM_MessageBoard>(whereLambda);
        }

        /// <summary>
        /// 保存留言信息
        /// </summary>
        /// <param name="msgBoard"></param>
        /// <returns></returns>
        public bool SaveMessageBoard(OM_MessageBoard msgBoard)
        {
            msgBoard.CreateDatetime = DateTime.Now;
            if (DbRepository.Add(msgBoard) > 0)
            {
                return true;
            }
            return false;
        }



        public OM_MessageBoard GetMessageBoard(Expression<Func<OM_MessageBoard, bool>> fuc)
        {
            return DbRepository.GetModel(fuc);
        }
    }

}