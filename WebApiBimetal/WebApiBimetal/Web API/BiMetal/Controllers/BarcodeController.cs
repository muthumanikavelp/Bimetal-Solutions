using BusinessEntities;
using BusinessServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiMetal.Controllers
{
    public class BarcodeController : ApiController
    {
        log4net.ILog logger4net = log4net.LogManager.GetLogger(typeof(BarcodeController));
        //Barcode Validation Process
        [Route("ValidateBarcodes")]
        [HttpPost]
        public Barcodes ValidateBarcodes()
        {
            Barcodes barcodes = new Barcodes();
            try
            {               
                Barcodes barcode = new Barcodes();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                barcode = (Barcodes)JsonConvert.DeserializeObject(post_data, barcode.GetType());
                barcodes = BarcodesBusiness.ValidateBarcodes(barcode.Barcode,barcode.Customer_id,barcode.Agent_id,barcode.Scan_mode);
                return barcodes;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return barcodes;
            }
        }
        //History after QR-Code Scan
        [Route("GetQRCodesInfo")]
        [HttpPost]
        public Barcodes.BarcodesData GetQRCodesInfo()
        {         
            Barcodes.BarcodesData barcodes = new Barcodes.BarcodesData();
            try
            {
                Barcodes qrhistory = new Barcodes();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                qrhistory = (Barcodes)JsonConvert.DeserializeObject(post_data, qrhistory.GetType());
                barcodes = BarcodesBusiness.GetQRCodesInfo(qrhistory.Customer_id, qrhistory.Agent_id);               
                return barcodes;
               
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return barcodes;
            }
        }
        //Delete individual QR Code and Delete All QR Codes
        [Route("DeleteQRCodes")]
        [HttpPost]
        public Barcodes DeleteQRCodes()
        {
            Barcodes barcodes = new Barcodes();
            try
            {
                Barcodes barcode = new Barcodes();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                barcode = (Barcodes)JsonConvert.DeserializeObject(post_data, barcode.GetType());
                barcodes = BarcodesBusiness.DeleteQRCodes(barcode.Customer_id, barcode.Agent_id,barcode.Barcode_id,barcode.ChildBarcode_id);
                return barcodes;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return barcodes;
            }
        }
        //Acknowledgement of QR Codes
        [Route("AcknowledgeQRCodes")]
        [HttpPost]
        public Barcodes.BarcodesData AcknowledgeQRCodes()
        {
            Barcodes.BarcodesData barcodes = new Barcodes.BarcodesData();
            try
            {
                Barcodes barcode = new Barcodes();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                barcode = (Barcodes)JsonConvert.DeserializeObject(post_data, barcode.GetType());
                barcodes = BarcodesBusiness.AcknowledgeQRCodes(barcode.Customer_id, barcode.Agent_id, barcode.Barcode_id, barcode.Customer_Sign,barcode.Paymode);
                return barcodes;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return barcodes;
            }
        }       
        //Final Submission of QR Codes
        [Route("SubmitQRCodes")]
        [HttpPost]
        public Barcodes.BarcodesData SubmitQRCodes()
        {
            Barcodes.BarcodesData barcodes = new Barcodes.BarcodesData();
            try
            {
                Barcodes barcode = new Barcodes();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                barcode = (Barcodes)JsonConvert.DeserializeObject(post_data, barcode.GetType());              
                barcodes = BarcodesBusiness.SubmitQRCodes(barcode.Customer_id, barcode.Agent_id, barcode.Barcode_id);
                return barcodes;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return barcodes;
            }
        }        
        //View History of Agent
        [Route("ViewAgentHistory")]
        [HttpPost]
        public Barcodes.AgentHistory ViewAgentHistory()
        {
            Barcodes.AgentHistory barcodes = new Barcodes.AgentHistory();
            try
            {
                Barcodes agenthistory = new Barcodes();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();

                agenthistory = (Barcodes)JsonConvert.DeserializeObject(post_data, agenthistory.GetType());
                barcodes = BarcodesBusiness.ViewAgentHistory(agenthistory.Agent_id);
                return barcodes;

            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return barcodes;
            }
        }
        //Chart View for Scan History of Agent
        [Route("ViewChartData")]
        [HttpPost]
        public List<Barcodes> ViewChartData()
        {
            List<Barcodes> chart = new List<Barcodes>();
            try
            {
                Barcodes chartdata = new Barcodes();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                chartdata = (Barcodes)JsonConvert.DeserializeObject(post_data, chartdata.GetType());
                chart = BarcodesBusiness.ViewChartData(chartdata.Agent_id);
                return chart;

            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return chart;
            }
        }        
    }
}
