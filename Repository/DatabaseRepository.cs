using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private DbContext _dbContext;

        public DatabaseRepository()
        {
            _dbContext = new OrderManagementContext();//can extension -> reflection
        }

        public virtual int Add<T>(T model)
            where T : class
        {
            var result = 0;
            try
            {
                _dbContext.Set<T>().Add(model);
                 result = _dbContext.SaveChanges();
            
            }
            catch (DbEntityValidationException dbEx)
            {
             
            }
            return result;
        }

        public virtual int AddRange<T>(List<T> listModel) where T : class
        {
            _dbContext.Set<T>().AddRange(listModel);
            var result = _dbContext.SaveChanges();
            return result;

        }


        public virtual int UpdateRange<T>(List<T> listModel)
           where T : class
        {
            foreach (var item in listModel)
            {
                DbEntityEntry entry = _dbContext.Entry<T>(item);
                entry.State = System.Data.Entity.EntityState.Modified;
            }
            return _dbContext.SaveChanges();
        }
        public virtual int Delete<T>(Expression<Func<T, bool>> whereLambda = null, string activeProperty = "IsDel") where T : class
        {
            var model = GetModel(whereLambda);
            DbEntityEntry entry = _dbContext.Entry<T>(model);
            entry.State = System.Data.Entity.EntityState.Unchanged;
            entry.Property(activeProperty).IsModified = true;
            entry.Property(activeProperty).CurrentValue = true;
            return _dbContext.SaveChanges();
        }

        public virtual int RealDelete<T>(Expression<Func<T, bool>> whereLambda = null)
           where T : class
        {
            var model = GetModel(whereLambda);
            //DbEntityEntry entry = _dbContext.Entry<T>(model);
            _dbContext.Set<T>().Remove(model);
            return _dbContext.SaveChanges();
        }

        public virtual int Update<T>(T model)
           where T : class
        {
            DbEntityEntry entry = _dbContext.Entry<T>(model);
            entry.State = System.Data.Entity.EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public virtual List<T> GetPagedList<T, TKey>(PageListParameter<T, TKey> parameter, out int count)
         where T : class
        {
            count = _dbContext.Set<T>().Where(parameter.whereLambda).Count();
            var list = _dbContext.Set<T>().Where<T>(parameter.whereLambda);
            if (parameter.isAsc)
            {
                list = list.OrderBy(parameter.orderByLambda);
            }
            else
            {
                list = list.OrderByDescending(parameter.orderByLambda);
            }
            var result = list.Skip((parameter.pageIndex) * parameter.pageSize).Take(parameter.pageSize).ToList();
            return result;
        }



        public virtual int ExcuteSql(string strSql, params object[] paras)
        {
            return _dbContext.Database.ExecuteSqlCommand(strSql, paras);
        }


        public virtual T GetModel<T>(Expression<Func<T, bool>> lambda) where T : class
        {
            return _dbContext.Set<T>().Where(lambda).FirstOrDefault();
        }


        public virtual List<T> GetList<T>(Expression<Func<T, bool>> whereLambda) where T : class
        {
            return _dbContext.Set<T>().Where(whereLambda).ToList();
        }
    }
}
