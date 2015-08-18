using OrderManager.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model.DTO
{
    public class OM_SalesOrderDataObject
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

        public decimal TotalPrice { get; set; }
        List<OM_OrderItem> _SalesOrderLine;

        public OM_Order ToDTO()
        {
            OM_Order salesOrderDataObejct = new OM_Order()
            {
                DocEntry = this.DocEntry,
                Guid = this.Guid,
                DocDate = this.DocDate == null ? DateTime.Now : this.DocDate,
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
        public List<OM_OrderItem> SalesOrderLine
        {
            get
            {
                if (_SalesOrderLine == null)
                {
                    _SalesOrderLine = new List<OM_OrderItem>();

                }
                return _SalesOrderLine;
            }
            set { _SalesOrderLine = value; }
        }

    }
}
