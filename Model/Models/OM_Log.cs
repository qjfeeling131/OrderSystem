using OrderManager.Model.DTO;
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

        public OM_LogDataObject DTO(string userName)
        {
            OM_LogDataObject logDTO = new OM_LogDataObject()
            {
                ID = this.ID,
                User_Guid = this.User_Guid,
                Guid = this.Guid,
                Message = this.Message,
                CreateDatetime = this.CreateDatetime,
                Operation = this.Operation,
                Doc_Name = this.Doc_Name,
                Doc_View = this.Doc_View,
                User_Name = userName
            };
            return logDTO;
        }
    }
}
