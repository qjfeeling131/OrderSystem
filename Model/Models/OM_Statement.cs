using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Model.Models
{
    public class OM_Statement
    {
        string cardCode;

        public string CardCode
        {
            get { return cardCode; }
            set { cardCode = value; }
        }

        string cardName;

        public string CardName
        {
            get { return cardName; }
            set { cardName = value; }
        }

        string docType;

        public string DocType
        {
            get { return docType; }
            set { docType = value; }
        }
        DateTime docDate;

        public DateTime DocDate
        {
            get { return docDate; }
            set { docDate = value; }
        }

        int docNum;

        public int DocNum
        {
            get { return docNum; }
            set { docNum = value; }
        }

        string itemName;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        string itemStandard;

        public string ItemStandard
        {
            get { return itemStandard; }
            set { itemStandard = value; }
        }

        Decimal? quantity;

        public Decimal? Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        string invntryUom;

        public string InvntryUom
        {
            get { return invntryUom; }
            set { invntryUom = value; }
        }

        Decimal? packageQty;

        public Decimal? PackageQty
        {
            get { return packageQty; }
            set { packageQty = value; }
        }

        Decimal? priceAfVAT;

        public Decimal? PriceAfVAT
        {
            get { return priceAfVAT; }
            set { priceAfVAT = value; }
        }

        Decimal? gTotal;

        public Decimal? GTotal
        {
            get { return gTotal; }
            set { gTotal = value; }
        }



        Decimal? paid;

        public Decimal? Paid
        {
            get { return paid; }
            set { paid = value; }
        }

        string remarks;


        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
    }
}
