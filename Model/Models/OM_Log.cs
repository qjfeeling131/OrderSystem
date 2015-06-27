using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_Log
    {
        public int ID { get; set; }
        public string User_Guid { get; set; }
        public string Guid { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        public string Operation { get; set; }
        public string Doc_Name { get; set; }
        public string Doc_View { get; set; }
    }
}
