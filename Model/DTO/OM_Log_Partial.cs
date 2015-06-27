using OrderManager.Model.DTO;
using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_Log
    {
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
