using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_Permission
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public Nullable<short> FormMethod { get; set; }
        public string Remark { get; set; }
        public bool IsDel { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
        public bool IsAdmin { get; set; }
    }
}
