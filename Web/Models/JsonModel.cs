using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManager.Web.Models
{
    public class JsonModel
    {

        public int Code { get; set; }  //0 : error  ,1 : normal

        public string Type { get; set; }

        public string Href { get; set; }

        public object Data { get; set; }

    }


    public enum JsonTypeEnym
    {
        Redirect,
        AsynData,
        Reload
    }

}