using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataModel;

namespace BusinessServices
{
    public class WHSBusiness
    {
        WHSData dataObj = new WHSData();
        public DataTable Getpartdetails(string partno)
        {
            try
            {
                return dataObj.Getpartdetails(partno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getinvoicedetails(string invoiceno)
        {
            try
            {
                return dataObj.getinvoicedetails(invoiceno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Updatescanflag(string invoiceno, string barcode)
        {
            try
            {
                return dataObj.Updatescanflag(invoiceno, barcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable getautofillpartnos()
        {
            return dataObj.getautofillpartnos();
        }

        public DataTable PrintBarcode(string _productcode, int _Qty, int _insertedby, string _plantlocation)
        {
            try
            {
                return dataObj.PrintBarcode(_productcode, _Qty, _insertedby, _plantlocation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable showreport(string _invoiceno, string _usercode)
        {
            try
            {
                return dataObj.showreport(_invoiceno, _usercode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PrintBarcodeInvoice(DateTime _fromdate, DateTime _todate, string _sitelocation)
        {
            try
            {
                return dataObj.PrintBarcodeInvoice(_fromdate, _todate, _sitelocation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable updatepasswordflag(string _userid, string _mailid, int _otp)
        {
            try
            {
                return dataObj.updatepasswordflag(_userid, _mailid, _otp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable updatenewpassword(string _userid, string _currentpwd, string _newpwd)
        {
            try
            {
                return dataObj.updatenewpassword(_userid, _currentpwd, _newpwd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getcomboxvalues()
        {
            try
            {
                return dataObj.getcomboxvalues();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable PrintBarcodeInvoicethrowInvoiceNo(string frominvno, string toinvno, string _sitelocation)
        {
            try
            {
                return dataObj.PrintBarcodeInvoicethrowInvoiceNo(frominvno, toinvno, _sitelocation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable fillgatepass()
        {
            try
            {
                return dataObj.fillgatepass();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable printgatepass(string gatepassno)
        {
            try
            {
                return dataObj.printgatepass(gatepassno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable showscannedbarcode(string _boxno)
        {
            try
            {
                return dataObj.showscannedbarcode(_boxno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_invoice_no(DateTime invoicedate)
        {
            try
            {
                return dataObj.get_invoice_no(invoicedate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet get_box_no(DateTime invoicedate,string invoiceno)
        {
            try
            {
                return dataObj.get_box_no(invoicedate, invoiceno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet get_item_code(DateTime invoicedate, string invoiceno,string boxno)
        {
            try
            {
                return dataObj.get_item_code(invoicedate, invoiceno,boxno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable get_barcode_grid_data(DateTime invoicedate, string invoiceno, string boxno,string itemcode)
        {
            try
            {
                return dataObj.get_barcode_grid_data(invoicedate, invoiceno, boxno, itemcode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
