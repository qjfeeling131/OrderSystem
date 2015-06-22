using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_User
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string Area_Guid { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string Post { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Img { get; set; }
        public bool IsDel { get; set; }

        public Nullable<System.DateTime> CreateDatetime { get; set; }
        public Nullable<System.DateTime> UpdateDatetime { get; set; }
        public string Account { get; set; }
        public string Key { get; set; }
    }
}
