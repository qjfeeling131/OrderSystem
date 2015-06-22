using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_Product
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string FrgnName { get; set; }
        public Nullable<decimal> OnHand { get; set; }
        public string GroupType { get; set; }
        public Nullable<decimal> GroupAPrice { get; set; }
        public Nullable<decimal> GroupBPrice { get; set; }
        public Nullable<decimal> GroupCPrice { get; set; }
        public string CardCode { get; set; }
        public string WhsCode { get; set; }
        public string Img { get; set; }
        public bool IsDel { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        public Nullable<System.DateTime> UpdateDateTime { get; set; }
        public string Remarks { get; set; }
    }
}
