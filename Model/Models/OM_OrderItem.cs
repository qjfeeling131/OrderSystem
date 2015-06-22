using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_OrderItem
    {
        public int DocEntry { get; set; }
        public string Guid { get; set; }
        public int LineNum { get; set; }
        public int VisualOrder { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemFName { get; set; }
        public string Flag { get; set; }
        public string WhsCode { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Quantity { get; set; }
        public Nullable<decimal> OpenQty { get; set; }
        public Nullable<decimal> CloseQty { get; set; }
        public string Currency { get; set; }
        public string Img { get; set; }
        public string Remarks { get; set; }
    }
}
