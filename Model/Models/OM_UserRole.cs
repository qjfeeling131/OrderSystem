using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_UserRole
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string User_Guid { get; set; }
        public string Role_Guid { get; set; }
        public bool IsDel { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
    }
}
