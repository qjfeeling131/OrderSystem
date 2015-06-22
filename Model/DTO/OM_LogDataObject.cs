using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model.DTO
{
    [DataContract]
    public class OM_LogDataObject
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string User_Guid { get; set; }
        [DataMember]
        public string User_Name { get; set; }
        [DataMember]
        public string Guid { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CreateDatetime { get; set; }
        [DataMember]
        public string Operation { get; set; }
        [DataMember]
        public string Doc_Name { get; set; }
        [DataMember]
        public string Doc_View { get; set; }
    }
}
