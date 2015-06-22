using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_AreaDepatment
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string Department_Guid { get; set; }
        public string Area_Guid { get; set; }
    }
}
