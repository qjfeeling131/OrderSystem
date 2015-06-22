using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_Role
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string Department_Guid { get; set; }
        public string Name { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<bool> IsDel { get; set; }
        public Nullable<System.DateTime> CreateDatetiime { get; set; }
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
    }
}
