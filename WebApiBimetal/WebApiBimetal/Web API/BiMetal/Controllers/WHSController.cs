using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using BusinessEntities;
using BusinessServices;

namespace BiMental.Controllers
{
    public class WHSController : ApiController
    {
        log4net.ILog logger4net = log4net.LogManager.GetLogger(typeof(WHSController));
        LoginBusiness objBusiness = new LoginBusiness();
        WHSBusiness businessObj = new WHSBusiness();

        [Route("getautofillpartnos")]
        [HttpPost]
        public DataTable getautofillpartnos([FromBody] WHSDetails users)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.getautofillpartnos();
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("Checkvaliduser")]
        [HttpPost]
        public DataTable Checkvaliduser([FromBody] EmployeeDetails users)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = objBusiness.Checkvaliduser(users);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("Getpartdetails")]
        [HttpPost]
        public DataTable Getpartdetails()
        {
            DataTable dt = new DataTable();
            try
            {
                EmployeeDetails user = new EmployeeDetails();

                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                user = (EmployeeDetails)JsonConvert.DeserializeObject(post_data, user.GetType());
                dt = businessObj.Getpartdetails(user.partno);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("getinvoicedetails")]
        [HttpPost]
        public DataTable getinvoicedetails([FromBody] WHSDetails whsObj)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.getinvoicedetails(whsObj.invoiceno);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("Updatescanflag")]
        [HttpPost]
        public DataTable Updatescanflag([FromBody] WHSDetails whsObj)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.Updatescanflag(whsObj.invoiceno, whsObj._barcode);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("PrintingBarcode")]
        [HttpPost]
        public DataTable PrintBarcode([FromBody] WHSDetails whsObj)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.PrintBarcode(whsObj._productcode, whsObj._Qty, whsObj._insertedby, whsObj._plantlocation);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("showreport")]
        [HttpPost]
        public DataTable showreport([FromBody] WHSDetails whsObj)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.showreport(whsObj.invoiceno, whsObj._userid);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("PrintBarcodeInvoice")]
        [HttpPost]
        public DataTable PrintBarcodeInvoice([FromBody] WHSDetails whsObj)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.PrintBarcodeInvoice(whsObj._fromdate, whsObj._todate, whsObj._sitelocation);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("PrintBarcodeInvoicethrowInvoiceNo")]
        [HttpPost]
        public DataTable PrintBarcodeInvoicethrowInvoiceNo([FromBody] WHSDetails whsObj)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.PrintBarcodeInvoicethrowInvoiceNo(whsObj._frominvno, whsObj._toinvno, whsObj._sitelocation);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("updatepasswordflag")]
        [HttpPost]
        public DataTable updatepasswordflag([FromBody] WHSDetails objWHS)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.updatepasswordflag(objWHS._userid, objWHS._toemailid, objWHS._otpnumber);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }
        [Route("updatenewpassword")]
        [HttpPost]
        public DataTable updatenewpassword([FromBody] WHSDetails objWHS)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.updatenewpassword(objWHS._userid, objWHS._currentpwd, objWHS._newpwd);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("getcomboxvalues")]
        [HttpPost]
        public DataSet getcomboxvalues([FromBody] WHSDetails objWHS)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = businessObj.getcomboxvalues();
                return ds;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return ds;
            }
        }

        [Route("fillgatepass")]
        [HttpPost]
        public DataTable fillgatepass([FromBody] WHSDetails objWHS)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.fillgatepass();
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("printgatepass")]
        [HttpPost]
        public DataTable printgatepass([FromBody] WHSDetails objWHS)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.printgatepass(objWHS._gatepassno);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("showscannedbarcode")]
        [HttpPost]
        public DataTable showscannedbarcode([FromBody] WHSDetails objWHS)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.showscannedbarcode(objWHS._boxno);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("get_invoice_no")]
        [HttpPost]
        public DataTable get_invoice_no([FromBody] WHSDetails objWHS)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.get_invoice_no(objWHS.invoicedate_);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

        [Route("get_box_no")]
        [HttpPost]
        public DataSet get_box_no([FromBody] WHSDetails objWHS)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = businessObj.get_box_no(objWHS.invoicedate_, objWHS.invoiceno_);
                return ds;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return ds;
            }
        }

        [Route("get_item_code")]
        [HttpPost]
        public DataSet get_item_code([FromBody] WHSDetails objWHS)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = businessObj.get_item_code(objWHS.invoicedate_, objWHS.invoiceno_, objWHS.invoceboxno_);
                return ds;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return ds;
            }
        }


        [Route("get_barcode_grid_data")]
        [HttpPost]
        public DataTable get_barcode_grid_data([FromBody] WHSDetails objWHS)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = businessObj.get_barcode_grid_data(objWHS.invoicedate_, objWHS.invoiceno_, objWHS.invoceboxno_,objWHS.invoiceitemcode_);
                return dt;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return dt;
            }
        }

    }
}
