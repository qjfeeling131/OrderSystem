using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_Department
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public bool IsDel { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
    }
}
