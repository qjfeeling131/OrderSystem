using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_RolePermission
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string Role_Guid { get; set; }
        public string Permission_Guid { get; set; }
        public Nullable<bool> IsDel { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
    }
}
