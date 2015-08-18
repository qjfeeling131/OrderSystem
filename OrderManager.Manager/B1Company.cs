using OrderManager.Common;
using OrderManager.Model.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Manager
{
    public class B1Company : IDisposable
    {
        private static object single = new object();
        private static B1Company _SBOCompany;

        public static B1Company SBOCompany
        {
            get
            {
                lock (single)
                {
                    if (_SBOCompany == null)
                    {
                        _SBOCompany = new B1Company();
                    }
                }
                return _SBOCompany;
            }
        }
        private SAPbobsCOM.Company _Company;

        private SAPbobsCOM.Company jFZCompany;
        public SAPbobsCOM.Company CurrentCompany
        {
            get
            {
                lock (single)
                {
                    if (_Company == null)
                    {
                        _Company = new SAPbobsCOM.Company();
                    }
                }
                return _Company;
            }
        }
        public SAPbobsCOM.Company JFZCompany
        {
            get
            {
                lock (single)
                {
                    if (jFZCompany == null)
                    {
                        jFZCompany = new SAPbobsCOM.Company();
                    }
                }
                return jFZCompany;
            }
        }


        public bool Connect()
        {
            string licenseAddress = ConfigurationManager.AppSettings["LicenseServer"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("licenseAddress is Null");
                return false;
            }
            string companyDB = ConfigurationManager.AppSettings["CompanyDB"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("CompanyDB is Null");
                return false;
            }
            string dbUser = ConfigurationManager.AppSettings["DbUserName"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("DbUserName is Null");
                return false;
            }
            string dbPwd = ConfigurationManager.AppSettings["DbPassword"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("DbPassword is Null");
                return false;
            }
            string language = ConfigurationManager.AppSettings["Language"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("Language is Null");
                return false;
            }
            string b1User = ConfigurationManager.AppSettings["UserName"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("UserName is Null");
                return false;
            }
            string b1Pwd = ConfigurationManager.AppSettings["Password"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("Password is Null");
                return false;
            }
            string dbServerType = ConfigurationManager.AppSettings["DbServerType"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("DbServerType is Null");
                return false;
            }
            string serverAddress = ConfigurationManager.AppSettings["Server"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("Server is Null");
                return false;
            }
            CurrentCompany.CompanyDB = companyDB;
            CurrentCompany.DbServerType = (SAPbobsCOM.BoDataServerTypes)int.Parse(dbServerType);
            CurrentCompany.LicenseServer = licenseAddress;
            CurrentCompany.DbUserName = dbUser;
            CurrentCompany.DbPassword = dbPwd;
            CurrentCompany.language = (SAPbobsCOM.BoSuppLangs)int.Parse(language);
            CurrentCompany.UserName = b1User;
            CurrentCompany.Password = b1Pwd;
            CurrentCompany.Server = serverAddress;

            if (CurrentCompany.Connect() == 0)
            {
                return true;
            }
            ExceptionLog.Write(string.Format("Error Code:{0}----Error Descride:{1}", _Company.GetLastErrorCode().ToString(), _Company.GetLastErrorDescription()));
            return false;
        }

        public bool JFZConnect()
        {
            string licenseAddress = ConfigurationManager.AppSettings["LicenseServer"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("licenseAddress is Null");
                return false;
            }
            string companyDB = ConfigurationManager.AppSettings["JFZCompanyDB"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("CompanyDB is Null");
                return false;
            }
            string dbUser = ConfigurationManager.AppSettings["DbUserName"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("DbUserName is Null");
                return false;
            }
            string dbPwd = ConfigurationManager.AppSettings["DbPassword"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("DbPassword is Null");
                return false;
            }
            string language = ConfigurationManager.AppSettings["Language"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("Language is Null");
                return false;
            }
            string b1User = ConfigurationManager.AppSettings["UserName"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("UserName is Null");
                return false;
            }
            string b1Pwd = ConfigurationManager.AppSettings["Password"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("Password is Null");
                return false;
            }
            string dbServerType = ConfigurationManager.AppSettings["DbServerType"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("DbServerType is Null");
                return false;
            }
            string serverAddress = ConfigurationManager.AppSettings["Server"];
            if (string.IsNullOrEmpty(licenseAddress))
            {
                ExceptionLog.Write("Server is Null");
                return false;
            }
            CurrentCompany.CompanyDB = companyDB;
            CurrentCompany.DbServerType = (SAPbobsCOM.BoDataServerTypes)int.Parse(dbServerType);
            CurrentCompany.LicenseServer = licenseAddress;
            CurrentCompany.DbUserName = dbUser;
            CurrentCompany.DbPassword = dbPwd;
            CurrentCompany.language = (SAPbobsCOM.BoSuppLangs)int.Parse(language);
            CurrentCompany.UserName = b1User;
            CurrentCompany.Password = b1Pwd;
            CurrentCompany.Server = serverAddress;

            if (CurrentCompany.Connect() == 0)
            {
                return true;
            }
            ExceptionLog.Write(string.Format("Error Code:{0}----Error Descride:{1}", _Company.GetLastErrorCode().ToString(), _Company.GetLastErrorDescription()));
            return false;
        }

        public bool SaveSalesOrderDraftToJFZ(OM_SalesOrderDataObject salesOrder)
        {
            if (!this.JFZConnect())
            {
                return false;
            }
            SAPbobsCOM.Documents oSaleOrder = JFZCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts);
            try
            {
                oSaleOrder.CardCode = salesOrder.CardCode;
                oSaleOrder.CardName = salesOrder.CardName;
                oSaleOrder.Comments = "经销商平台对接生成";
                if (salesOrder.DocDate == null)
                {
                    oSaleOrder.DocDate = DateTime.Now;
                    oSaleOrder.DocDueDate = DateTime.Now;
                }
                else
                {
                    oSaleOrder.DocDate = (DateTime)salesOrder.DocDate;
                    oSaleOrder.DocDueDate = (DateTime)salesOrder.DocDate;
                }
                oSaleOrder.DocObjectCode = SAPbobsCOM.BoObjectTypes.oOrders;
                foreach (var item in salesOrder.SalesOrderLine)
                {
                    oSaleOrder.Lines.ItemCode = item.ItemCode;
                    oSaleOrder.Lines.ItemDescription = item.ItemName;
                    oSaleOrder.Lines.Quantity = Convert.ToDouble(item.Quantity);
                    oSaleOrder.Lines.Price = Convert.ToDouble(item.Price);
                    oSaleOrder.Lines.Add();
                }
                if (oSaleOrder.Add() == 0)
                {
                    return true;
                }
                ExceptionLog.Write(string.Format("SalseOrderAdd----Error Code:{0}----Error Descride:{1}", _Company.GetLastErrorCode().ToString(), _Company.GetLastErrorDescription()));
                return false;
            }
            catch (Exception ex)
            {
                ExceptionLog.Write(string.Format("SalseOrderAdd----Error Code:{0}----Error Descride:{1}", _Company.GetLastErrorCode().ToString(), _Company.GetLastErrorDescription()));
                return false;
            }
            finally
            {
                DisConnect();
                Dispose();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(oSaleOrder);
            }

        }
        public bool SaveSalesOrderDraft(OM_SalesOrderDataObject salesOrder)
        {
            if (!this.Connect())
            {
                return false;
            }
            SAPbobsCOM.Documents oSaleOrder = CurrentCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts);
            try
            {

                oSaleOrder.CardCode = salesOrder.CardCode;
                oSaleOrder.CardName = salesOrder.CardName;
                oSaleOrder.Comments = "经销商平台对接生成";
                if (salesOrder.DocDate == null)
                {
                    oSaleOrder.DocDate = DateTime.Now;
                    oSaleOrder.DocDueDate = DateTime.Now;
                }
                else
                {
                    oSaleOrder.DocDate = (DateTime)salesOrder.DocDate;
                    oSaleOrder.DocDueDate = (DateTime)salesOrder.DocDate;
                }
                oSaleOrder.DocObjectCode = SAPbobsCOM.BoObjectTypes.oOrders;
                foreach (var item in salesOrder.SalesOrderLine)
                {
                    oSaleOrder.Lines.ItemCode = item.ItemCode;
                    oSaleOrder.Lines.ItemDescription = item.ItemName;
                    oSaleOrder.Lines.Quantity = Convert.ToDouble(item.Quantity);
                    oSaleOrder.Lines.Price = Convert.ToDouble(item.Price);
                    oSaleOrder.Lines.Add();
                }
                if (oSaleOrder.Add() == 0)
                {
                    return true;
                }
                ExceptionLog.Write(string.Format("SalseOrderAdd----Error Code:{0}----Error Descride:{1}", _Company.GetLastErrorCode().ToString(), _Company.GetLastErrorDescription()));
                return false;
            }
            catch (Exception ex)
            {
                ExceptionLog.Write(string.Format("SalseOrderAdd----Error Code:{0}----Error Descride:{1}", _Company.GetLastErrorCode().ToString(), _Company.GetLastErrorDescription()));
                return false;
            }
            finally
            {
                DisConnect();
                Dispose();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(oSaleOrder);
            }

        }
        public void DisConnect()
        {
            CurrentCompany.Disconnect();
            JFZCompany.Disconnect();
        }

        public void Dispose()
        {
            if (_Company != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_Company);
            }
            if (CurrentCompany != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(CurrentCompany);
            }
        }
    }
}
