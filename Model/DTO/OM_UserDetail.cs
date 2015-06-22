using AutoMapper;
using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model.DTO
{
    [DataContract]
    public class OM_UserDetail
    {
        [DataMember]
        public OM_User User { get; set; }

        [DataMember]
        public OM_Role Role { get; set; }

    }


}
