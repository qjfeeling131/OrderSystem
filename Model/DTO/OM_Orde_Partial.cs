using OrderManager.Model.DTO;
using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_Order
    {
        public OM_SalesOrderDataObject ToDTO()
        {
            OM_SalesOrderDataObject salesOrderDataObejct = new OM_SalesOrderDataObject()
            {
                DocEntry = this.DocEntry,
                Guid = this.Guid,
                DocDate = this.DocDate,
                DocDueDate = this.DocDueDate,
                DocStatus = this.DocStatus,
                CardCode = this.CardCode,
                CardName = this.CardName,
                NumCard = this.NumCard,
                TPLCompany = this.TPLCompany,
                TPLContact = this.TPLContact,
                TPLOrder = this.TPLOrder,
                TPLPhone = this.TPLPhone,
                NoteNotice = this.NoteNotice,
                Remarks = this.Remarks,
                User_Guid = this.User_Guid

            };
            return salesOrderDataObejct;

        }

        public string ConvertDocStatus(string chineseStatus)
        {
            return null;
        }
       
    }
}
