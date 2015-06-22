using OrderManager.Model.DTO;
using System;
using System.Collections.Generic;

namespace OrderManager.Model.Models
{
    public partial class OM_Order
    {
        public int DocEntry { get; set; }
        public string Guid { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string DocStatus { get; set; }
        public Nullable<System.DateTime> DocDate { get; set; }
        public Nullable<System.DateTime> DocDueDate { get; set; }
        public string User_Guid { get; set; }
        public string TPLCompany { get; set; }
        public string TPLOrder { get; set; }
        public string TPLContact { get; set; }
        public string TPLPhone { get; set; }
        public string NumCard { get; set; }
        public string NoteNotice { get; set; }
        public string Remarks { get; set; }

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
    }
}