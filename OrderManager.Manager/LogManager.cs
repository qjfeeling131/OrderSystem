
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
    public class LogManager : BaseManger, ILogManager
    {

        public bool WriteLog(OM_Log log)
        {
           var result= DbRepository.Add<OM_Log>(log);
           return result > 0;
        }

    }
}
