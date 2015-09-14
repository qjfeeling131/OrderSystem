using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManager.Web.Models
{
    public class OderConditionModel
    {
        public string Id { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string OrderStatus { get; set; }

        public string OrderEntry { get; set; }


        public string Remarks { get; set; }

        public string OrderDate { get; set; }

        public string DeliverDate { get; set; } 

    }
}