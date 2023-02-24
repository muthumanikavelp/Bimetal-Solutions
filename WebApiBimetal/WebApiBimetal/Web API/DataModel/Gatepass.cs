using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace DataModel
{
    public class Gatepass
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

        //1
        public DataTable GenerateGatepassNo(string P_Driver_VehicleNo, string p_Driver_MobileNo, int p_Inserted_By)
        {
            //List<GatepassEntities> lstGatepass = new List<GatepassEntities>();
            try
            {
                DataTable tab = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Set_GenerateGatepassNo_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Driver_VehicleNo", MySqlDbType.VarChar).Value = P_Driver_VehicleNo;
                cmd.Parameters.Add("p_Driver_MobileNo", MySqlDbType.VarChar).Value = p_Driver_MobileNo;
                cmd.Parameters.Add("p_Inserted_By", MySqlDbType.Int32).Value = p_Inserted_By;
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tab);
                con.Close();               

                return tab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //2
        public DataTable VerifyInvoiceNo(Int32 P_Gatepass_GID, string P_InvoiceNo, Int32 p_Inserted_By)
        {
            DataTable tab = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("WHS_Set_VerifyInvoice_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Gatepass_GID", MySqlDbType.Int32).Value = P_Gatepass_GID;
                cmd.Parameters.Add("P_InvoiceNo", MySqlDbType.VarChar).Value = P_InvoiceNo;
                cmd.Parameters.Add("p_Inserted_By", MySqlDbType.Int32).Value = p_Inserted_By;
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tab);
                con.Close();
                //if (tab.Rows.Count > 0)
                //{

                //    foreach (DataRow dr in tab.Rows)
                //    {
                //        GatepassEntities ObjGatepass = new GatepassEntities(); 
                //        ObjGatepass.Gatepass_GID = Convert.ToInt32(dr["Gatepass_Invoice_Gid"]);
                //        ObjGatepass.message = dr["msg"].ToString();
                //        lstGatepass.Add(ObjGatepass);
                //    }
                //}
                //else
                //{
                //    GatepassEntities ObjGatepass = new GatepassEntities(); 
                //    ObjGatepass.Gatepass_GID = 0;
                //    ObjGatepass.message = "Failure";
                //    lstGatepass.Add(ObjGatepass);
                //}

                return tab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //3
        public Int32 UpdateNetWeight(Int32 P_Gatepass_GID, decimal P_Netwieght, string P_InvoiceNo, int P_Inserted_By)
        {
            int data = 0;
            try
            {
                DataTable tab = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Set_InvoiceDetails_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Gatepass_GID", MySqlDbType.Int32).Value = P_Gatepass_GID;
                cmd.Parameters.Add("P_InvoiceNo", MySqlDbType.VarChar).Value = P_InvoiceNo;
                cmd.Parameters.Add("P_Netwieght", MySqlDbType.Decimal).Value = P_Netwieght;
                cmd.Parameters.Add("P_Inserted_By", MySqlDbType.Decimal).Value = P_Inserted_By;
                con.Open();
                data = cmd.ExecuteNonQuery();
                con.Close();
               
                return data;
            }
            catch (Exception ex)
            {
                return data;
                throw ex;
                
            }
        }

        //4 
        public List<GatepassEntities> GetGatepassInvoiceDetails(Int32 P_Gatepass_Gid, string P_Action)
        {
            DataTable tab = new DataTable();
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("WHS_Get_GatepassInvoice_Details_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Gatepass_Gid", MySqlDbType.Int32).Value = P_Gatepass_Gid;
                cmd.Parameters.Add("P_Action", MySqlDbType.VarChar).Value = P_Action; 
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tab);
                con.Close();
               
                if (tab.Rows.Count > 0)
                {
                    foreach (DataRow dr in tab.Rows)
                    {
                        GatepassEntities ObjGatepassEntities = new GatepassEntities();
                        ObjGatepassEntities.InvoiceNo = dr["Invoice_No"].ToString();
                        ObjGatepassEntities.Actual_Cases = string.IsNullOrEmpty(dr["Actual_Cases"].ToString()) ? 0 : Convert.ToInt32(dr["Actual_Cases"]);
                        ObjGatepassEntities.Scanned_Cases = string.IsNullOrEmpty(dr["Scanned_Cases"].ToString()) ? 0 : Convert.ToInt32(dr["Scanned_Cases"]);
                        ObjGatepassEntities.Pending_Cases = string.IsNullOrEmpty(dr["Pending_Cases"].ToString()) ? 0 : Convert.ToInt32(dr["Pending_Cases"]);
                        ObjGatepassEntities.GatepassNo = dr["Gatepass_No"].ToString();
                        ObjGatepassEntities.Driver_VehicleNo = dr["Driver_VehicleNo"].ToString();
                        ObjGatepassEntities.Driver_MobileNo = dr["Driver_MobileNo"].ToString();
                        //ObjGatepassEntities.Netwieght = string.IsNullOrEmpty(dr["Netweight"].ToString()) ? 0 : Convert.ToDecimal(dr["Netweight"]);
                        ObjGatepassEntities.AirwayBillNo = dr["AirwayBillNo"].ToString();
                        ObjGatepassEntities.LLRNo = dr["LLRNo"].ToString();
                        ObjGatepassEntities.CurStatus = dr["Status"].ToString();
                        //ObjGatepassEntities.Gatepass_Invoice_Gid = Convert.ToInt32(dr["Gatepass_Invoice_GID"]);
                        ObjGatepassEntities.Gatepass_GID = Convert.ToInt32(dr["Gatepass_Gid"]);
                        ObjGatepassEntities.message = "Success";
                        lstGatepassEntities.Add(ObjGatepassEntities);
                    }
                }
                else
                {
                    GatepassEntities ObjGatepassEntities = new GatepassEntities();
                    ObjGatepassEntities.Gatepass_GID = 0;
                    ObjGatepassEntities.message = "Failure";
                    lstGatepassEntities.Add(ObjGatepassEntities);
                }

                return lstGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //5
        public DataTable UpdateAirwayBillNo(string P_InvoiceNo, Int32 P_Gatepass_Gid, string P_AirwayBillNo, string P_Status)
        {
            DataTable tab = new DataTable();
            try
            {
                GatepassEntities ObjGatepass = new GatepassEntities();
                List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
                MySqlCommand cmd = new MySqlCommand("WHS_Set_AirwayBillNoLLRNo_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Gatepass_Gid", MySqlDbType.Int32).Value = P_Gatepass_Gid;
                cmd.Parameters.Add("P_InvoiceNo", MySqlDbType.VarChar).Value = P_InvoiceNo;
                cmd.Parameters.Add("P_AirwayBillNo", MySqlDbType.VarChar).Value = P_AirwayBillNo;
                cmd.Parameters.Add("P_LLRNo", MySqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("P_Status", MySqlDbType.VarChar).Value = P_Status;
                cmd.Parameters.Add("P_Action", MySqlDbType.VarChar).Value = "AirwayBill";
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tab);
                con.Close();
                //if (data > 0)
                //{
                //    ObjGatepass.InvoiceNo = P_InvoiceNo;
                //    ObjGatepass.Gatepass_GID = P_Gatepass_Gid;
                //    ObjGatepass.message = "Success";
                //}
                //else
                //{
                //    ObjGatepass.InvoiceNo = P_InvoiceNo;
                //    ObjGatepass.Gatepass_GID = P_Gatepass_Gid;
                //    ObjGatepass.message = "Failure"; 
                //} 

                return tab;
            }
            catch (Exception ex)
            { 
                throw ex;

            }
        }

        //6
        public DataTable UpdateLLRNo(string P_InvoiceNo, Int32 P_Gatepass_Gid, string P_LLRNo, string P_Status)
        {
            DataTable tab = new DataTable();
            try
            {
                GatepassEntities ObjGatepass = new GatepassEntities();
                List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
                MySqlCommand cmd = new MySqlCommand("WHS_Set_AirwayBillNoLLRNo_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Gatepass_Gid", MySqlDbType.Int32).Value = P_Gatepass_Gid;
                cmd.Parameters.Add("P_InvoiceNo", MySqlDbType.VarChar).Value = P_InvoiceNo;
                cmd.Parameters.Add("P_AirwayBillNo", MySqlDbType.VarChar).Value =""; 
                cmd.Parameters.Add("P_LLRNo", MySqlDbType.VarChar).Value = P_LLRNo;
                cmd.Parameters.Add("P_Status", MySqlDbType.VarChar).Value = P_Status;
                cmd.Parameters.Add("P_Action", MySqlDbType.VarChar).Value = "LLRNo";
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tab);
                con.Close();

                return tab;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //7
        public List<GatepassEntities> FetchGatepassSummary(Int32 P_Login_Gid, string P_Status)
        {
            DataTable tab = new DataTable();
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("WHS_Get_FetchGatepassSummary_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Login_Gid", MySqlDbType.Int32).Value = P_Login_Gid;
                cmd.Parameters.Add("P_Status", MySqlDbType.VarChar).Value = P_Status;
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tab);
                con.Close();
               
                if (tab.Rows.Count > 0)
                {
                    foreach (DataRow dr in tab.Rows)
                    {
                        GatepassEntities ObjGatepassEntities = new GatepassEntities();
                        ObjGatepassEntities.NoofInvoices = string.IsNullOrEmpty(dr["No_Of_Invoices"].ToString()) ? 0 : Convert.ToInt32(dr["No_Of_Invoices"]); 
                        ObjGatepassEntities.GatepassNo = dr["Gatepass_No"].ToString();
                        ObjGatepassEntities.DateTime = Convert.ToDateTime(dr["DateTime"].ToString()); 
                        ObjGatepassEntities.Gatepass_GID = Convert.ToInt32(dr["Gatepass_Gid"]);
                        ObjGatepassEntities.message = "Success";
                        lstGatepassEntities.Add(ObjGatepassEntities);
                    }
                }
                else
                {
                    GatepassEntities ObjGatepassEntities = new GatepassEntities();
                    ObjGatepassEntities.Gatepass_GID = 0;
                    ObjGatepassEntities.message = "Failure";
                    lstGatepassEntities.Add(ObjGatepassEntities);
                }

                return lstGatepassEntities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //8
        public GatepassEntities UpdateStatus(Int32 P_Gatepass_Gid,  string P_Status)
        {
            DataTable tab = new DataTable();
            try
            {
                GatepassEntities ObjGatepass = new GatepassEntities();
                List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
                MySqlCommand cmd = new MySqlCommand("WHS_Set_AirwayBillNoLLRNo_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Gatepass_Gid", MySqlDbType.Int32).Value = P_Gatepass_Gid;
                cmd.Parameters.Add("P_InvoiceNo", MySqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("P_AirwayBillNo", MySqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("P_LLRNo", MySqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("P_Status", MySqlDbType.VarChar).Value = P_Status;
                cmd.Parameters.Add("P_Action", MySqlDbType.VarChar).Value = "Submit";
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tab);
                con.Close();
                if (tab.Rows.Count > 0)
                {
                    ObjGatepass.Gatepass_GID = P_Gatepass_Gid;
                    ObjGatepass.message = "Success";
                }
                else
                {
                    ObjGatepass.Gatepass_GID = P_Gatepass_Gid;
                    ObjGatepass.message = "Failure";
                }

                return ObjGatepass;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //9
        public GatepassEntities DeleteInvoice(Int32 P_Gatepass_Gid, string p_InvoiceNo, string P_Action)
        {
            int data = 0;
            try
            {
                GatepassEntities ObjGatepass = new GatepassEntities();
                List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
                MySqlCommand cmd = new MySqlCommand("WHS_Set_DeleteInvoice_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Gatepass_Gid", MySqlDbType.Int32).Value = P_Gatepass_Gid;
                cmd.Parameters.Add("p_InvoiceNo", MySqlDbType.VarChar).Value = p_InvoiceNo; 
                cmd.Parameters.Add("P_Action", MySqlDbType.VarChar).Value = P_Action;
                con.Open();
                data = cmd.ExecuteNonQuery();
                con.Close();
                if (data > 0)
                {
                    ObjGatepass.Gatepass_GID = P_Gatepass_Gid;
                    ObjGatepass.message = "Success";
                }
                else
                {
                    ObjGatepass.Gatepass_GID = P_Gatepass_Gid;
                    ObjGatepass.message = "Failure";
                }

                return ObjGatepass;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataTable GetScannedCasesByGatePassGID(int p_Gatepass_GID)
        {
            //List<GatepassEntities> lstGatepass = new List<GatepassEntities>();
            try
            {
                DataTable tab = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Get_ScannedCaseCount_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("p_Gatepass_GID", MySqlDbType.Int32).Value = p_Gatepass_GID;
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tab);
                con.Close();

                return tab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
