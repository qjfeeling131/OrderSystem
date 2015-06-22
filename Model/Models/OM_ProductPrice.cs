using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_ProductPrice
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Product_ItemCode { get; set; }
        public string Department_Guid { get; set; }
    }
}
