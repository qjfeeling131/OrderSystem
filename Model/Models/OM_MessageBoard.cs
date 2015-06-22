using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_MessageBoard
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string User_Guid { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
    }
}
