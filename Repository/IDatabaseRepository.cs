﻿using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Repository
{
    public interface IDatabaseRepository
    {
        OrderManagementContext CurrentContext { get; }
        int Add<T>(T model) where T : class;
        int AddRange<T>(List<T> listModel) where T : class;
        int Delete<T>(Expression<Func<T, bool>> whereLambda = null, string activeProperty = "IsDel") where T : class;

        int RealDelete<T>(Expression<Func<T, bool>> whereLambda = null) where T : class;

        int Update<T>(T model) where T : class;

        int UpdateRange<T>(List<T> listModel) where T : class;
        T GetModel<T>(Expression<Func<T, bool>> lambda) where T : class;

        List<T> GetPagedList<T, TKey>(PageListParameter<T, TKey> parameter, out int count) where T : class;

        List<T> GetList<T>(Expression<Func<T, bool>> whereLambda) where T : class;

        int ExcuteSql(string strSql, params object[] paras);
        IEnumerable<T> ExecuteQuery<T>(string sql);
    }
}
