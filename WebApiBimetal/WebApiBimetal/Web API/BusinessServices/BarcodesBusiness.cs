using BusinessEntities;
using DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class BarcodesBusiness
    {
        public static Barcodes ValidateBarcodes(string barcode,int cusid,int agentid,string scanmode)
        {
            DataTable tab = new DataTable();
            Barcodes barcodes = new Barcodes();
            try
            {
                BarcodeData objbarcode = new BarcodeData();
                barcodes = objbarcode.getallvalidatedbarcodes(barcode, cusid, agentid, scanmode);
                return barcodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Barcodes.BarcodesData GetQRCodesInfo(int cusid, int agentid)
        {
            DataTable tab = new DataTable();
            Barcodes.BarcodesData barcodes = new Barcodes.BarcodesData();           
            try
            {
                BarcodeData objbarcode = new BarcodeData();
                barcodes = objbarcode.getbarcodesinfo(cusid, agentid);
                return barcodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Barcodes DeleteQRCodes(int cusid, int agentid,int barcodeid,int childbcodeid)
        {
            DataTable tab = new DataTable();
            Barcodes barcodes = new Barcodes();
            try
            {
                BarcodeData objbarcode = new BarcodeData();
                barcodes = objbarcode.deleteqrcodes(cusid, agentid, barcodeid, childbcodeid);
                return barcodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Barcodes.BarcodesData AcknowledgeQRCodes(int cusid, int agentid, int barcodeid, string sign,string paymode)
        {
            DataTable tab = new DataTable();
            Barcodes.BarcodesData barcodes = new Barcodes.BarcodesData();
            try
            {
                BarcodeData objbarcode = new BarcodeData();
                barcodes = objbarcode.acknowledgeqrcodes(cusid, agentid, barcodeid, sign,paymode);
                return barcodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Barcodes.BarcodesData SubmitQRCodes(int cusid, int agentid, int barcodeid)
        {
            DataTable tab = new DataTable();
            Barcodes.BarcodesData barcodes = new Barcodes.BarcodesData();
            try
            {
                BarcodeData objbarcode = new BarcodeData();
                barcodes = objbarcode.submitqrcodes(cusid, agentid, barcodeid);
                return barcodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
      
        
        public static Barcodes.AgentHistory ViewAgentHistory(int agentid)
        {
            DataTable tab = new DataTable();
            Barcodes.AgentHistory barcodes = new Barcodes.AgentHistory();
            try
            {
                BarcodeData objbarcode = new BarcodeData();
                barcodes = objbarcode.viewagenthistory(agentid);
                return barcodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Barcodes> ViewChartData(int agentid)
        {
            DataTable tab = new DataTable();
            List<Barcodes> chartdata = new List<Barcodes>();
            try
            {
                BarcodeData objbarcode = new BarcodeData();
                chartdata = objbarcode.viewchartdata(agentid);
                return chartdata;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   
        
    }
}
