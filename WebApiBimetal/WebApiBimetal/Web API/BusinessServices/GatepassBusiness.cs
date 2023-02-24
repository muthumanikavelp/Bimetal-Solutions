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
    public class GatepassBusiness
    {
        public static GatepassEntities GenerateGatepassNo(string P_Driver_VehicleNo, string p_Driver_MobileNo, int p_Inserted_By)
        {
            DataTable tab = new DataTable();
            GatepassEntities ObjGatepassEntities = new GatepassEntities();
            try
            {
                Gatepass ObjGatepass = new Gatepass();
                tab = ObjGatepass.GenerateGatepassNo(P_Driver_VehicleNo, p_Driver_MobileNo, p_Inserted_By);
                if (tab.Rows.Count > 0)
                {
                    //foreach (DataRow dr in tab.Rows)
                    //{
                    ObjGatepassEntities.GatepassNo = tab.Rows[0]["GatepassNo"].ToString();
                    ObjGatepassEntities.Gatepass_GID = Convert.ToInt32(tab.Rows[0]["GatepassGid"]);
                    ObjGatepassEntities.message = "Success";
                    //}
                }
                else
                {
                    ObjGatepassEntities.GatepassNo = null;
                    ObjGatepassEntities.Gatepass_GID = 0;
                    ObjGatepassEntities.message = "Failure";
                }
                return ObjGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static GatepassEntities VerifyInvoiceNo(Int32 P_Gatepass_GID, string P_InvoiceNo, Int32 p_Inserted_By)
        {
            DataTable dt = new DataTable();
            try
            {
                Gatepass ObjGatepass = new Gatepass();
                GatepassEntities ObjGatepassEntities = new GatepassEntities();
                dt = ObjGatepass.VerifyInvoiceNo(P_Gatepass_GID, P_InvoiceNo, p_Inserted_By);
                if (dt.Rows.Count > 0)
                {
                    //    foreach (DataRow dr in dt.Rows)
                    //    {

                    ObjGatepassEntities.Gatepass_Invoice_Gid = Convert.ToInt32(dt.Rows[0]["Gatepass_Invoice_Gid"]);
                    ObjGatepassEntities.message = dt.Rows[0]["msg"].ToString();
                    ObjGatepassEntities.InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
                    ObjGatepassEntities.Gatepass_GID = Convert.ToInt32(dt.Rows[0]["Gatepass_GID"]);
                    //}
                }
                else
                {
                    //GatepassEntities ObjGatepassEntities = new GatepassEntities();
                    ObjGatepassEntities.Gatepass_Invoice_Gid = 0;
                    ObjGatepassEntities.InvoiceNo = "";
                    ObjGatepassEntities.Gatepass_GID = 0;
                    ObjGatepassEntities.message = "Failure";
                }
                return ObjGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static GatepassEntities UpdateNetWeight(Int32 P_Gatepass_GID, decimal P_Netwieght, string P_InvoiceNo, int P_Inserted_By)
        {
            GatepassEntities ObjGatepassEntities = new GatepassEntities();
            int data = 0;
            try
            {
                Gatepass ObjGatepass = new Gatepass();
                data = ObjGatepass.UpdateNetWeight(P_Gatepass_GID, P_Netwieght, P_InvoiceNo, P_Inserted_By);
                if (data > 0)
                {
                    ObjGatepassEntities.message = "Success";
                }
                else
                {
                    ObjGatepassEntities.message = "Failure";
                }
                //return ObjGatepassEntities;
                //Gatepass ObjGatepass = new Gatepass();
                //dt = ObjGatepass.UpdateNetWeight(P_Gatepass_Invoice_Gid, NetWeight);
                //if (dt.Rows.Count > 0)
                //{
                //    ObjGatepassEntities.AirwayBillNo = dt.Rows[0]["AirwayBillNo"].ToString();
                //    ObjGatepassEntities.LLRNo = dt.Rows[0]["LLRNo"].ToString();
                //    ObjGatepassEntities.Driver_VehicleNo = dt.Rows[0]["Driver_VehicleNo"].ToString();
                //    ObjGatepassEntities.Driver_MobileNo = dt.Rows[0]["Driver_MobileNo"].ToString();
                //    ObjGatepassEntities.GatepassNo = dt.Rows[0]["Gatepass_No"].ToString();
                //    ObjGatepassEntities.InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
                //    ObjGatepassEntities.Gatepass_GID = Convert.ToInt32(dt.Rows[0]["Gatepass_GID"]);
                //    ObjGatepassEntities.message = "Success";
                //}
                //else
                //{
                //    ObjGatepassEntities.AirwayBillNo = "";
                //    ObjGatepassEntities.LLRNo = "";
                //    ObjGatepassEntities.Driver_VehicleNo = "";
                //    ObjGatepassEntities.Driver_MobileNo = "";
                //    ObjGatepassEntities.GatepassNo = "";
                //    ObjGatepassEntities.InvoiceNo = "";
                //    ObjGatepassEntities.Gatepass_GID = 0;
                //    ObjGatepassEntities.message = "Failure";
                //}
                return ObjGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //4        
        public static List<GatepassEntities> GetGatepassInvoiceDetails(Int32 P_Gatepass_Gid, string P_Action)
        {
            DataTable tab = new DataTable();
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            try
            {
                Gatepass ObjGatepass = new Gatepass();
                lstGatepassEntities = ObjGatepass.GetGatepassInvoiceDetails(P_Gatepass_Gid, P_Action);
                return lstGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //5
        public static GatepassEntities UpdateAirwayBillNo(string P_InvoiceNo, Int32 p_Gatepass_GID, string P_AirwayBillNo, string P_Status)
        {
            try
            {
                GatepassEntities ObjGatepassEntities = new GatepassEntities();
                DataTable dt = new DataTable();
                try
                {
                    //Gatepass ObjGatepass = new Gatepass();
                    //data = ObjGatepass.UpdateNetWeight(P_Gatepass_Invoice_Gid, NetWeight);
                    //if (data > 0)
                    //{
                    //    ObjGatepassEntities.message = "Success"; 
                    //}
                    //else
                    //{ 
                    //    ObjGatepassEntities.message = "Failure"; 
                    //}
                    //return ObjGatepassEntities;
                    Gatepass ObjGatepass = new Gatepass();
                    dt = ObjGatepass.UpdateAirwayBillNo(P_InvoiceNo, p_Gatepass_GID, P_AirwayBillNo, P_Status);
                    if (dt.Rows.Count > 0)
                    {
                        ObjGatepassEntities.AirwayBillNo = dt.Rows[0]["AirwayBillNo"].ToString();
                        ObjGatepassEntities.LLRNo = dt.Rows[0]["LLRNo"].ToString();
                        ObjGatepassEntities.Driver_VehicleNo = dt.Rows[0]["Driver_VehicleNo"].ToString();
                        ObjGatepassEntities.Driver_MobileNo = dt.Rows[0]["Driver_MobileNo"].ToString();
                        ObjGatepassEntities.GatepassNo = dt.Rows[0]["Gatepass_No"].ToString();
                        ObjGatepassEntities.InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
                        ObjGatepassEntities.Gatepass_GID = Convert.ToInt32(dt.Rows[0]["Gatepass_GID"]);
                        ObjGatepassEntities.message = "Success";
                    }
                    else
                    {
                        ObjGatepassEntities.AirwayBillNo = "";
                        ObjGatepassEntities.LLRNo = "";
                        ObjGatepassEntities.Driver_VehicleNo = "";
                        ObjGatepassEntities.Driver_MobileNo = "";
                        ObjGatepassEntities.GatepassNo = "";
                        ObjGatepassEntities.InvoiceNo = "";
                        ObjGatepassEntities.Gatepass_GID = 0;
                        ObjGatepassEntities.message = "Failure";
                    }
                    return ObjGatepassEntities;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return ObjGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //6
        public static GatepassEntities UpdateLLRNo(string P_InvoiceNo, Int32 p_Gatepass_GID, string P_LLRNo, string P_Status)
        {
            try
            {
                DataTable dt = new DataTable();
                Gatepass ObjGatepass = new Gatepass();
                GatepassEntities ObjGatepassEntities = new GatepassEntities();
                //ObjGatepassEntities = ObjGatepass.UpdateLLRNo(P_InvoiceNo, p_Gatepass_GID, P_LLRNo, P_Status);
                dt = ObjGatepass.UpdateLLRNo(P_InvoiceNo, p_Gatepass_GID, P_LLRNo, P_Status);
                if (dt.Rows.Count > 0)
                {
                    ObjGatepassEntities.AirwayBillNo = dt.Rows[0]["AirwayBillNo"].ToString();
                    ObjGatepassEntities.LLRNo = dt.Rows[0]["LLRNo"].ToString();
                    ObjGatepassEntities.Driver_VehicleNo = dt.Rows[0]["Driver_VehicleNo"].ToString();
                    ObjGatepassEntities.Driver_MobileNo = dt.Rows[0]["Driver_MobileNo"].ToString();
                    ObjGatepassEntities.GatepassNo = dt.Rows[0]["Gatepass_No"].ToString();
                    ObjGatepassEntities.InvoiceNo = dt.Rows[0]["InvoiceNo"].ToString();
                    ObjGatepassEntities.Gatepass_GID = Convert.ToInt32(dt.Rows[0]["Gatepass_GID"]);
                    ObjGatepassEntities.message = "Success";
                }
                else
                {
                    ObjGatepassEntities.AirwayBillNo = "";
                    ObjGatepassEntities.LLRNo = "";
                    ObjGatepassEntities.Driver_VehicleNo = "";
                    ObjGatepassEntities.Driver_MobileNo = "";
                    ObjGatepassEntities.GatepassNo = "";
                    ObjGatepassEntities.InvoiceNo = "";
                    ObjGatepassEntities.Gatepass_GID = 0;
                    ObjGatepassEntities.message = "Failure";
                }

                return ObjGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //7        
        public static List<GatepassEntities> FetchGatepassSummary(Int32 P_Login_Gid, string P_Status)
        {
            DataTable tab = new DataTable();
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            try
            {
                Gatepass ObjGatepass = new Gatepass();
                lstGatepassEntities = ObjGatepass.FetchGatepassSummary(P_Login_Gid, P_Status);
                return lstGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //8
        public static GatepassEntities UpdateStatus(Int32 P_Gatepass_Gid, string P_Status)
        {
            try
            {
                Gatepass ObjGatepass = new Gatepass();
                GatepassEntities ObjGatepassEntities = new GatepassEntities();
                ObjGatepassEntities = ObjGatepass.UpdateStatus(P_Gatepass_Gid, P_Status);

                return ObjGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //9
        public static GatepassEntities DeleteInvoice(Int32 P_Gatepass_Gid, string p_InvoiceNo, string P_Action)
        {
            try
            {
                Gatepass ObjGatepass = new Gatepass();
                GatepassEntities ObjGatepassEntities = new GatepassEntities();
                ObjGatepassEntities = ObjGatepass.DeleteInvoice(P_Gatepass_Gid, p_InvoiceNo, P_Action);

                return ObjGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //10
        public static GatepassEntities GetScannedCasesByGatePassGID(int p_Gatepass_GID)
        {
            DataTable tab = new DataTable();
            GatepassEntities ObjGatepassEntities = new GatepassEntities();
            try
            {
                Gatepass ObjGatepass = new Gatepass();
                tab = ObjGatepass.GetScannedCasesByGatePassGID(p_Gatepass_GID);
                if (tab.Rows.Count > 0)
                {
                    ObjGatepassEntities.NoofScannedCases = Convert.ToInt32(tab.Rows[0]["No_Of_Cases"]);
                    ObjGatepassEntities.Gatepass_GID = Convert.ToInt32(tab.Rows[0]["GatePass_Gid"]); ;
                    ObjGatepassEntities.message = "Success";
                }
                else
                {
                    ObjGatepassEntities.NoofScannedCases = 0;
                    ObjGatepassEntities.Gatepass_GID = 0;
                    ObjGatepassEntities.message = "Failure";
                }
                return ObjGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
