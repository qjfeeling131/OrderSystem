using OrderManager.Model;
using OrderManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Manager
{

    public abstract class BaseManger
    {
        private IDatabaseRepository _dbRepository;
        public IDatabaseRepository DbRepository
        {
            get
            {
                if (_dbRepository == null)
                    _dbRepository = new DatabaseRepository();
                return _dbRepository;
            }
        }
    }
}
