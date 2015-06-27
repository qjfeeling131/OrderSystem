using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_ProductPrice
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public decimal Price { get; set; }
        public string Product_ItemCode { get; set; }
        public string User_Guid { get; set; }
        public string Area_Guid { get; set; }
    }
}
