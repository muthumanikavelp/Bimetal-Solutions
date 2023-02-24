using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BarcodeData
    {

        /// <summary>
        /// Gayatri---WEBAPI MODAL
        /// </summary>
        /// <param name="barcode"></param>
        /// <param name="cusid"></param>
        /// <param name="agentid"></param>
        /// <returns></returns>
        #region
        public Barcodes getallvalidatedbarcodes(string barcode,int cusid,int agentid,string scanmode)
        {

            DataTable tab = new DataTable();
            Barcodes barcodes = new Barcodes();
            try
            {

                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();
                values.Add("p_barcodeno", barcode);
                values.Add("p_cusid", cusid);
                values.Add("p_agentid", agentid);
                values.Add("p_scan_mode", scanmode);
                tab = con.RunProc("ValidateBarcodes",values);
                if (tab.Rows.Count > 0)
                {

                    foreach (DataRow dr in tab.Rows)
                    {
                        barcodes.message = dr["message"].ToString();
                        barcodes.code = int.Parse(dr["code"].ToString());

                        if (barcodes.code == 0)
                        {
                            barcodes.Scanned_Date = DateTime.Parse(dr["Date"].ToString());
                            barcodes.message = dr["message"].ToString();
                            barcodes.code = int.Parse(dr["code"].ToString());
                            barcodes.Barcode = dr["Barcode"].ToString();
                            barcodes.Coupon_count = int.Parse(dr["Coupon_count"].ToString());
                            barcodes.Coupon_amount = Decimal.Parse(dr["Coupon_amount"].ToString());  
                            
                        }
                        else
                        {
                            barcodes.Scanned_Date = DateTime.Parse(dr["Date"].ToString());
                            barcodes.message = dr["message"].ToString();
                            barcodes.code = int.Parse(dr["code"].ToString());
                            barcodes.Barcode = null;
                            barcodes.Coupon_count = 0;
                            barcodes.Coupon_amount = 0;                           
                        }                                    
                      
                    }
                }
                return barcodes;
            }
            catch(Exception ex)
            {
                return barcodes;
            }
        }
        public Barcodes.BarcodesData getbarcodesinfo(int cusid, int agentid)
        {
            List<Barcodes> ls_qrcodes = new List<Barcodes>();
            Barcodes.BarcodesData barcodes = new Barcodes.BarcodesData();
            DataSet ds = new DataSet();
            try
            {
                
                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();
                values.Add("p_customer_id", cusid);
                values.Add("p_agent_id", agentid);
                
                ds = con.RunDataSetProc("GetQRCodeHistory", values);
              
                if (ds.Tables.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    DataTable dt2 = ds.Tables[1];

                    if (dt1.Rows.Count>0 && dt2.Rows.Count>0)
                    {
                        barcodes.message = dt1.Rows[0]["message"].ToString();
                        barcodes.code = int.Parse(dt1.Rows[0]["code"].ToString());
                        foreach (DataRow dr in dt2.Rows)
                        {
                            Barcodes qrcode = new Barcodes();

                            if (barcodes.code == 0)
                            {
                                qrcode.Scanned_Date = DateTime.Parse(dr["Date"].ToString());
                                qrcode.Barcode = dr["QR_CodeNo"].ToString();
                                qrcode.Product_Code = dr["Product_Code"].ToString();
                                qrcode.Amount = Decimal.Parse(dr["Price"].ToString());
                                qrcode.Barcode_id = int.Parse(dr["Barcode_id"].ToString());
                                qrcode.ChildBarcode_id = int.Parse(dr["ChildBarcode_id"].ToString());
                            }
                            else
                            {
                                qrcode.Scanned_Date = DateTime.Parse(dr["Date"].ToString());
                                barcodes.message = "Failed";
                                barcodes.code = 1;
                                qrcode.Barcode = null;
                                qrcode.Product_Code = null;
                                qrcode.Amount = 0;
                                qrcode.Barcode_id = 0;
                                qrcode.ChildBarcode_id = 0;
                            }
                            ls_qrcodes.Add(qrcode);
                        }
                        barcodes.Coupon_amount = Decimal.Parse(dt1.Rows[0]["TotalValue"].ToString());
                        barcodes.Coupon_count = int.Parse(dt1.Rows[0]["TotalCoupons"].ToString());
                        barcodes.BarcodeInfo = ls_qrcodes;
                    }
                    else
                    {
                        Barcodes qrcodee = new Barcodes();
                        qrcodee.Scanned_Date = System.DateTime.Now;
                        qrcodee.Barcode = null;
                        qrcodee.Coupon_count = 0;
                        qrcodee.Coupon_amount = 0;
                        qrcodee.Amount = 0;
                        qrcodee.Barcode_id = 0;
                        qrcodee.ChildBarcode_id = 0;
                        ls_qrcodes.Add(qrcodee);                     
                        barcodes.BarcodeInfo = ls_qrcodes;
                        barcodes.message = "Failed";
                        barcodes.code = 1;
                    }               
                   
                }
                else
                {
                    Barcodes qrcodee = new Barcodes();
                    qrcodee.Scanned_Date = System.DateTime.Now;                    
                    qrcodee.Barcode = null;
                    qrcodee.Coupon_count = 0;
                    qrcodee.Coupon_amount = 0;
                    qrcodee.Amount = 0;
                    qrcodee.Barcode_id = 0;
                    qrcodee.ChildBarcode_id = 0;
                    ls_qrcodes.Add(qrcodee);                   
                    barcodes.BarcodeInfo = ls_qrcodes;
                    barcodes.message = "Failed";
                    barcodes.code = 1;
                }
                return barcodes;
            }
            catch
            {
                return barcodes;
            }
        }
        public Barcodes deleteqrcodes(int cusid, int agentid,int barcodeid,int cbarcodeid)
        {
            int result = 0;

            DataTable tab = new DataTable();
            Barcodes barcodes = new Barcodes();
            try
            {

                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();

                values.Add("p_customer_id", cusid);
                values.Add("p_agent_id", agentid);
                values.Add("p_barcode_id", barcodeid);
                values.Add("p_childbarcode_id", cbarcodeid);



                tab = con.RunProc("DeleteQRCodes", values);
                if (tab.Rows.Count > 0)
                {

                    foreach (DataRow dr in tab.Rows)
                    {
                        barcodes.message = dr["message"].ToString();
                        barcodes.code = int.Parse(dr["code"].ToString());
                    }
                }
                else
                {
                      barcodes.message ="Deletion failed";
                      barcodes.code = 1;
                }
                return barcodes;
            }
            catch(Exception ex)
            {
                return barcodes;
            }
        }

        public Barcodes.BarcodesData acknowledgeqrcodes(int cusid, int agentid, int barcodeid, string cussign,string paymode)
        {
            List<Barcodes> ls_qrcodes = new List<Barcodes>();
            Barcodes.BarcodesData barcodes = new Barcodes.BarcodesData();
            DataSet ds = new DataSet();
            try
            {

                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();
                values.Add("p_customer_id", cusid);
                values.Add("p_agent_id", agentid);
                values.Add("p_barcode_id", barcodeid);
                values.Add("p_sign", cussign);
                values.Add("p_paymode", paymode);
                ds = con.RunDataSetProc("AcknowledgeBarcodes", values);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    DataTable dt2 = ds.Tables[1];                  
                    if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                    {
                        barcodes.message = dt1.Rows[0]["message"].ToString();
                        barcodes.code = int.Parse(dt1.Rows[0]["code"].ToString());
                        foreach (DataRow dr in dt2.Rows)
                        {
                            Barcodes qrcode = new Barcodes();

                            if (barcodes.code == 0)
                            {
                                qrcode.Scanned_Date = DateTime.Parse(dr["Date"].ToString());
                                qrcode.Barcode = dr["QR_CodeNo"].ToString();
                                qrcode.Amount = Decimal.Parse(dr["Price"].ToString());
                                qrcode.Barcode_id = int.Parse(dr["Barcode_id"].ToString());
                                qrcode.ChildBarcode_id = int.Parse(dr["ChildBarcode_id"].ToString());
                                qrcode.Product_Code = dr["Product_Code"].ToString();
                              
                            }
                            else
                            {
                                qrcode.Scanned_Date = DateTime.Parse(dr["Date"].ToString());
                                barcodes.message = "Failed";
                                barcodes.code = 1;
                                qrcode.Barcode = null;
                                qrcode.Amount = 0;
                                qrcode.Barcode_id = 0;
                                qrcode.ChildBarcode_id = 0;
                                qrcode.Product_Code = null;
                            }
                            ls_qrcodes.Add(qrcode);
                        }
                        barcodes.Coupon_amount = Decimal.Parse(dt1.Rows[0]["TotalValue"].ToString());
                        barcodes.Coupon_count = int.Parse(dt1.Rows[0]["TotalCoupons"].ToString());
                        barcodes.Paymode = dt1.Rows[0]["Paymode"].ToString();
                       
                        //barcodes.Signature = Convert.ToByte(dt1.Rows[0]["Signature"].ToString());
                        //barcodes.Signature = Convert.FromBase64String(dt1.Rows[0]["Signature"].ToString());
                        if (dt1.Rows[0]["Signature"] != null)
                        {

                            //byte[] photo = (byte[])dt1.Rows[0]["Signature"];
                            //var plainTextBytes = Encoding.UTF8.GetBytes(photo.ToString());
                            //barcodes.Customer_Sign = Convert.ToBase64String(plainTextBytes);

                            barcodes.Customer_Sign = dt1.Rows[0]["Signature"].ToString(); 
                          
                        }

                        else
                        {
                            barcodes.Customer_Sign = null;
                        }
                        //byte[] byteArray = (byte[])dt1.Rows[0]["Signature"];
                    
                        //barcodes.Customer_Sign = dt1.Rows[0]["Signature"].ToString();
                        barcodes.BarcodeInfo = ls_qrcodes;
                    }
                    else
                    {
                        Barcodes qrcodee = new Barcodes();
                        qrcodee.Scanned_Date = System.DateTime.Now;
                        qrcodee.Barcode = null;
                        qrcodee.Coupon_count = 0;
                        qrcodee.Coupon_amount = 0;
                        barcodes.Customer_Sign = null;
                        qrcodee.Amount = 0;
                        qrcodee.Product_Code = null;
                        qrcodee.Barcode_id = 0;
                        qrcodee.ChildBarcode_id = 0;
                        ls_qrcodes.Add(qrcodee);
                        barcodes.Customer_Sign = null;
                        barcodes.BarcodeInfo = ls_qrcodes;
                        barcodes.message = "Failed";
                        barcodes.code = 1;                        
                    }

                }
                else
                {
                    Barcodes qrcodee = new Barcodes();
                    qrcodee.Scanned_Date = System.DateTime.Now;
                    qrcodee.Barcode = null;
                    qrcodee.Coupon_count = 0;
                    qrcodee.Coupon_amount = 0;
                    barcodes.Customer_Sign = null;
                    qrcodee.Amount = 0;
                    qrcodee.Barcode_id = 0;
                    qrcodee.Product_Code = null;
                    qrcodee.ChildBarcode_id = 0;
                    ls_qrcodes.Add(qrcodee);
                    barcodes.Customer_Sign = null;
                    barcodes.BarcodeInfo = ls_qrcodes;
                    barcodes.message = "Failed";
                    barcodes.code = 1;
                   
                }
                return barcodes;
            }
            catch(Exception ex)
            {
                return barcodes;
            }
        }
        public Barcodes.BarcodesData submitqrcodes(int cusid, int agentid, int barcodeid)
        {
            List<Barcodes> ls_qrcodes = new List<Barcodes>();
            Barcodes.BarcodesData barcodes = new Barcodes.BarcodesData();
            DataSet ds = new DataSet();
            try
            {

                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();
                values.Add("p_customer_id", cusid);
                values.Add("p_agent_id", agentid);
                values.Add("p_barcode_id", barcodeid);               
                ds = con.RunDataSetProc("SubmitQRCodes", values);

                if (ds.Tables.Count > 0)
                {
                    DataTable dt1 = ds.Tables[0];
                    DataTable dt2 = ds.Tables[1];                  
                    if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                    {
                        barcodes.message = dt1.Rows[0]["message"].ToString();
                        barcodes.code = int.Parse(dt1.Rows[0]["code"].ToString());
                        foreach (DataRow dr in dt2.Rows)
                        {
                            Barcodes qrcode = new Barcodes();

                            if (barcodes.code == 0)
                            {
                                qrcode.Scanned_Date = DateTime.Parse(dr["Date"].ToString());
                                qrcode.Barcode = dr["QR_CodeNo"].ToString();
                                qrcode.Amount = Decimal.Parse(dr["Price"].ToString());
                                qrcode.Barcode_id = int.Parse(dr["Barcode_id"].ToString());
                                qrcode.ChildBarcode_id = int.Parse(dr["ChildBarcode_id"].ToString());
                              
                            }
                            else
                            {
                                qrcode.Scanned_Date = DateTime.Parse(dr["Date"].ToString());
                                barcodes.message = "Failed";
                                barcodes.code = 1;
                                qrcode.Barcode = null;
                                qrcode.Amount = 0;
                                qrcode.Barcode_id = 0;
                                qrcode.ChildBarcode_id = 0;
                            }
                            ls_qrcodes.Add(qrcode);
                        }
                        barcodes.Coupon_amount = Decimal.Parse(dt1.Rows[0]["TotalValue"].ToString());
                        barcodes.Coupon_count = int.Parse(dt1.Rows[0]["TotalCoupons"].ToString());
                        barcodes.Paymode = dt1.Rows[0]["Paymode"].ToString();
                        //barcodes.Signature = Convert.ToByte(dt1.Rows[0]["Signature"].ToString());
                        //barcodes.Signature = Convert.FromBase64String(dt1.Rows[0]["Signature"].ToString());
                        if (dt1.Rows[0]["Signature"] != null)
                        {

                            //byte[] photo = (byte[])dt1.Rows[0]["Signature"];
                            //var plainTextBytes = Encoding.UTF8.GetBytes(photo.ToString());
                            //barcodes.Customer_Sign = Convert.ToBase64String(plainTextBytes);

                            barcodes.Customer_Sign = dt1.Rows[0]["Signature"].ToString(); 
                          
                        }

                        else
                        {
                            barcodes.Customer_Sign = null;
                        }
                        //byte[] byteArray = (byte[])dt1.Rows[0]["Signature"];
                    
                        //barcodes.Customer_Sign = dt1.Rows[0]["Signature"].ToString();
                        barcodes.BarcodeInfo = ls_qrcodes;
                    }
                    else
                    {
                        Barcodes qrcodee = new Barcodes();
                        qrcodee.Scanned_Date = System.DateTime.Now;
                        qrcodee.Barcode = null;
                        qrcodee.Coupon_count = 0;
                        qrcodee.Coupon_amount = 0;
                        barcodes.Customer_Sign = null;
                        qrcodee.Amount = 0;
                        qrcodee.Barcode_id = 0;
                        qrcodee.ChildBarcode_id = 0;
                        ls_qrcodes.Add(qrcodee);
                        barcodes.Customer_Sign = null;
                        barcodes.BarcodeInfo = ls_qrcodes;
                        barcodes.message = "Failed";
                        barcodes.code = 1;                        
                    }

                }
                else
                {
                    Barcodes qrcodee = new Barcodes();
                    qrcodee.Scanned_Date = System.DateTime.Now;
                    qrcodee.Barcode = null;
                    qrcodee.Coupon_count = 0;
                    qrcodee.Coupon_amount = 0;
                    barcodes.Customer_Sign = null;
                    qrcodee.Amount = 0;
                    qrcodee.Barcode_id = 0;
                    qrcodee.ChildBarcode_id = 0;
                    ls_qrcodes.Add(qrcodee);
                    barcodes.Customer_Sign = null;
                    barcodes.BarcodeInfo = ls_qrcodes;
                    barcodes.message = "Failed";
                    barcodes.code = 1;
                   
                }
                return barcodes;
            }
            catch(Exception ex)
            {
                return barcodes;
            }
        }

        public Barcodes.AgentHistory viewagenthistory(int agentid)
        {

            Barcodes.AgentHistory agents = new Barcodes.AgentHistory();
            DataSet ds = new DataSet();
            try
            {

                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();
                values.Add("p_agent_id", agentid);
                ds = con.RunDataSetProc("GetAgentHistory", values);

                if (ds.Tables.Count > 0)
                {

                    DataTable dt1 = ds.Tables[0];
                    DataTable dt2 = ds.Tables[1];
                    if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                    {
                        List<Barcodes.Barcodess> ls_agenthis = new List<Barcodes.Barcodess>();

                        agents.message = dt1.Rows[0]["message"].ToString();
                        agents.code = int.Parse(dt1.Rows[0]["code"].ToString());

                        if (agents.code == 0)
                        {
                            foreach (DataRow dr in dt2.Rows)
                            {

                                Barcodes.Barcodess history = new Barcodes.Barcodess();
                                if (agents.code == 0)
                                {
                                    history.Barcode_no = dr["Barcode_no"].ToString();
                                    history.ChildBarcode_id = int.Parse(dr["ChildBarcode_id"].ToString());
                                    history.Barcode_id = int.Parse(dr["Barcode_id"].ToString());
                                    history.Amount = Decimal.Parse(dr["Amount"].ToString());
                                    history.Scanned_Date = DateTime.Parse(dr["Scanned_Date"].ToString());
                                    //history.Scanned_Date = dr["Scanned_Date"].ToString();

                                }
                                else
                                {

                                }
                                ls_agenthis.Add(history);

                            }

                            List<Barcodes.Scan> ls_his = new List<Barcodes.Scan>();
                            foreach (DataRow drr in dt1.Rows)
                            {

                                Barcodes.Scan view = new Barcodes.Scan();
                                view.Barcode_id = int.Parse(drr["Barcode_id"].ToString());
                                view.Scanned_Date = DateTime.Parse(drr["Date"].ToString());
                                //view.Scanned_Date = drr["Date"].ToString();
                                view.Customer_id = int.Parse(drr["CustomerId"].ToString());
                                view.Customer_name = drr["CustomerName"].ToString();
                                view.Customer_Sign = drr["Signature"].ToString();  
                                view.Amount = Decimal.Parse(drr["Amount"].ToString());
                                view.Status = drr["Status"].ToString();
                                int barcode = int.Parse(drr["Barcode_id"].ToString());
                                view.BarcodeDetails = ls_agenthis.Where(i => i.Barcode_id == barcode).ToList();

                                ls_his.Add(view);
                            }

                            agents.ScanDetails = ls_his;
                        }
                        else
                        {
                            agents.message = "Failed";
                            agents.code = 1;
                        }


                    }
                    else
                    {
                        agents.message = "Failed";
                        agents.code = 1;
                    }

                }
                else
                {
                    agents.message = "Failed";
                    agents.code = 1;
                }
                return agents;
            }
            catch(Exception ex)
            {
                return agents;
            }
        }
        public List<Barcodes> viewchartdata(int agentid)
        {
            List<Barcodes> chartview = new List<Barcodes>();
            DataTable tab = new DataTable();
            try
            {
                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();
                values.Add("p_agent_id", agentid);
                tab = con.RunProc("GetChartData", values);
                if (tab.Rows.Count > 0)
                {

                    foreach (DataRow dr in tab.Rows)
                    {
                        Barcodes charts = new Barcodes();
                        charts.message = dr["message"].ToString();
                        charts.code = int.Parse(dr["code"].ToString());

                        if (charts.code == 0)
                        {
                            charts.month = dr["MonthYear"].ToString();
                            charts.Amount = Decimal.Parse(dr["Amount"].ToString());
                        }
                        else
                        {
                            charts.message = "Failed";
                            charts.code = 1;
                            charts.month = null;
                            charts.Amount = 0;
                        }
                        chartview.Add(charts);
                    }
                }
                //else
                //{
                //    Barcodes charts = new Barcodes();
                //    charts.message = "Failed";
                //    charts.code = 1;
                //    charts.month = null; 
                //    charts.Amount = 0;
                //    chartview.Add(charts);
                //}

                return chartview;
            }
            catch(Exception ex)
            {
                return chartview;
            }
        }

        
        #endregion

    }
}
