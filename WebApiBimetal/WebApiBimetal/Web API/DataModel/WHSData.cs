using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataModel
{
    public class WHSData
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
        //MySqlTransaction tran;
        public DataTable Getpartdetails(string partno)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Getpartdetails_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("in_partno", MySqlDbType.VarChar).Value = partno;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable getinvoicedetails(string invoiceno)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_GetInvoiceDetails_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("in_invoiceno", MySqlDbType.VarChar).Value = invoiceno;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable Updatescanflag(string invoiceno, string barcode)
        {
            
            try
            {
               // tran = con.BeginTransaction();
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Updatescanflag_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("in_invoiceno", MySqlDbType.VarChar).Value = invoiceno;
                cmd.Parameters.Add("in_barcode", MySqlDbType.VarChar).Value = barcode;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //tran.Commit();
                return dt;
            }
            catch (Exception ex)
            {
               // tran.Rollback();
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable getautofillpartnos()
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Getautofillpartnos_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable PrintBarcode(string _productcode, int _Qty, int _insertedby, string _plantlocation)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                if (_plantlocation == "HOSUR")
                {
                    MySqlCommand cmd = new MySqlCommand("WHS_GetRandomNos_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.Add("_qty", MySqlDbType.Int32).Value = _Qty;
                    cmd.Parameters.Add("_productcode", MySqlDbType.VarChar).Value = _productcode;
                    cmd.Parameters.Add("_insertedby", MySqlDbType.Int32).Value = _insertedby;
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                else if (_plantlocation == "COIMBATORE")
                {
                    MySqlCommand cmd1 = new MySqlCommand("WHS_GetRandomNos_Coimbatore_SP", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandTimeout = 0;
                    cmd1.Parameters.Add("_qty", MySqlDbType.Int32).Value = _Qty;
                    cmd1.Parameters.Add("_productcode", MySqlDbType.VarChar).Value = _productcode;
                    cmd1.Parameters.Add("_insertedby", MySqlDbType.Int32).Value = _insertedby;
                    MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                    da1.Fill(dt);
                }
                else
                {
                    MySqlCommand cmd2 = new MySqlCommand("WHS_GetRandomNos_Chennai_SP", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandTimeout = 0;
                    cmd2.Parameters.Add("_qty", MySqlDbType.Int32).Value = _Qty;
                    cmd2.Parameters.Add("_productcode", MySqlDbType.VarChar).Value = _productcode;
                    cmd2.Parameters.Add("_insertedby", MySqlDbType.Int32).Value = _insertedby;
                    MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                    da2.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable showreport(string _invoiceno, string _usercode)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("whs_printinvoice_sp", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("_invoiceno", MySqlDbType.VarChar).Value = _invoiceno;
                cmd.Parameters.Add("_usercode", MySqlDbType.VarChar).Value = _usercode;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable PrintBarcodeInvoice(DateTime _fromdate, DateTime _todate, string _sitelocation)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_PrintInvoiceBarcode_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("_fromdate", MySqlDbType.Date).Value = _fromdate;
                cmd.Parameters.Add("_todate", MySqlDbType.Date).Value = _todate;
                cmd.Parameters.Add("_location", MySqlDbType.VarChar).Value = _sitelocation;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable updatepasswordflag(string _userid, string _mailid, int _otp)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_setforgetpassflag_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("_userid", MySqlDbType.VarChar).Value = _userid;
                cmd.Parameters.Add("_usermailaddress", MySqlDbType.VarChar).Value = _mailid;
                cmd.Parameters.Add("_OTPNum", MySqlDbType.Int32).Value = _otp;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable updatenewpassword(string _userid, string _currentpwd, string _newpwd)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Updatenewpassword_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("_userid", MySqlDbType.VarChar).Value = _userid;
                cmd.Parameters.Add("_currentpwd", MySqlDbType.VarChar).Value = _currentpwd;
                cmd.Parameters.Add("_newpwd", MySqlDbType.VarChar).Value = _newpwd;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet getcomboxvalues()
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand("WHS_GetComboxBoxDatas_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable PrintBarcodeInvoicethrowInvoiceNo(string frominvno, string toinvno, string _sitelocation)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_PrintInvoiceBarcodewithInvNo_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("_FromInvNo", MySqlDbType.VarChar).Value = frominvno;
                cmd.Parameters.Add("_ToInvNo", MySqlDbType.VarChar).Value = toinvno;
                cmd.Parameters.Add("_location", MySqlDbType.VarChar).Value = _sitelocation;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable fillgatepass()
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_FillGatePass_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable printgatepass(string gatepassno)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_PrintGatePass_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("_gatepassno", MySqlDbType.VarChar).Value = gatepassno;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable showscannedbarcode(string _boxno)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Get_ScannedBarcodeWithItemCode_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("in_boxno", MySqlDbType.VarChar).Value = _boxno;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

     #region
        public DataTable get_invoice_no(DateTime invoicedate)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Get_BarcodeReport_ComboboxandgridValues_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("in_action", MySqlDbType.VarChar).Value = "invoiceno";
                cmd.Parameters.Add("in_invoicedate", MySqlDbType.Date).Value = invoicedate;
                cmd.Parameters.Add("in_invoiceno", MySqlDbType.VarChar).Value = "0";
                cmd.Parameters.Add("in_boxno", MySqlDbType.VarChar).Value = "0";
                cmd.Parameters.Add("in_itemcode", MySqlDbType.VarChar).Value = "0";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet get_box_no(DateTime invoicedate, string invoiceno)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand("WHS_Get_BarcodeReport_ComboboxandgridValues_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("in_action", MySqlDbType.VarChar).Value = "boxno";
                cmd.Parameters.Add("in_invoicedate", MySqlDbType.Date).Value = invoicedate;
                cmd.Parameters.Add("in_invoiceno", MySqlDbType.VarChar).Value = invoiceno;
                cmd.Parameters.Add("in_boxno", MySqlDbType.VarChar).Value = "0";
                cmd.Parameters.Add("in_itemcode", MySqlDbType.VarChar).Value = "0";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet get_item_code(DateTime invoicedate, string invoiceno, string boxno)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlCommand cmd = new MySqlCommand("WHS_Get_BarcodeReport_ComboboxandgridValues_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("in_action", MySqlDbType.VarChar).Value = "itemcode";
                cmd.Parameters.Add("in_invoicedate", MySqlDbType.Date).Value = invoicedate;
                cmd.Parameters.Add("in_invoiceno", MySqlDbType.VarChar).Value = invoiceno;
                cmd.Parameters.Add("in_boxno", MySqlDbType.VarChar).Value = boxno;
                cmd.Parameters.Add("in_itemcode", MySqlDbType.VarChar).Value = "0";
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable get_barcode_grid_data(DateTime invoicedate, string invoiceno, string boxno,string itemcode)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("WHS_Get_BarcodeReport_ComboboxandgridValues_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add("in_action", MySqlDbType.VarChar).Value = "griddata";
                cmd.Parameters.Add("in_invoicedate", MySqlDbType.Date).Value = invoicedate;
                cmd.Parameters.Add("in_invoiceno", MySqlDbType.VarChar).Value = invoiceno;
                cmd.Parameters.Add("in_boxno", MySqlDbType.VarChar).Value = boxno;
                cmd.Parameters.Add("in_itemcode", MySqlDbType.VarChar).Value = itemcode;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

     #endregion
       

    }
}
