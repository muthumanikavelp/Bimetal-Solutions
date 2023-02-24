using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.Web;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using BusinessEntities;





/**********************************************************************************
 * File : DataConnection.cs
 * Purpose : All data connection related operations are encapsulated here.
 * Author : Ramia R
 * *********************************************************************************/


namespace DataModel
{
    public class DataConnection
    {

        ///<summary>This data adapter is used for all queries to the database.</summary>
        private MySqlDataAdapter da;
        ///<summary>This is the connection that is used by the data adapter for all queries.</summary>
        //private SqlConnection con;
        private MySqlConnection  con;
        ///<summary>Used to get very small bits of data from the db when the data adapter would be overkill.  For instance retrieving the response after a command is sent.</summary>
        private MySqlDataReader dr;
        ///<summary>Stores the string of the command that will be sent to the database.</summary>
        private MySqlCommand cmd;
        ///<summary>After inserting a row, this variable will contain the primary key for the newly inserted row.  This can frequently save an additional query to the database.</summary>
        public int InsertID;

        ///<summary>Constructor sets the connection values.</summary>
        public DataConnection()
        {
            con = new MySqlConnection (ConfigurationManager.AppSettings["ConnectionString"].ToString());
            //dr = null;
            cmd = new MySqlCommand();
            cmd.Connection = con;
            //table=new DataTable();
        }

        ///<summary>Sets the connection to an alternate database for backup purposes.  Currently only used during conversions to do a quick backup first, and in FormConfig to get db names.</summary>
        public DataConnection(string db)
        {
            con = new MySqlConnection();
            //dr = null;
            cmd = new MySqlCommand();
            cmd.Connection = con;
            //table=new DataTable(null);
        }

        ///<summary>Tests to see if the connection with specified database is valid and accepting commands.</summary>
        public bool IsValid()
        {
            try
            {
                con.Open();
                cmd.CommandText = "update preference set valuestring = '0' where valuestring = '0'";
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {//(SqlDriverCS.SqlException ex){
                return false;
            }
            return true;
        }

        public bool DbExists()
        {
            try
            {
                con.Open();
                con.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        ///<summary>Fills table with data from the database.</summary>
        public DataTable GetTable(string command)
        {
            cmd.CommandText = command;
            DataTable table = new DataTable();
            try
            {
                da = new MySqlDataAdapter(cmd);
                da.Fill(table);
                con.Close();
            }
            catch (SqlException e)
            {
                //MsgBoxCopyPaste MB = new MsgBoxCopyPaste(Lan.g("DataConnection", "Error in query:") + "\r\n"
                //    + e.Message + "\r\n" + "\r\n"
                //    + command);
                //MB.ShowDialog();
                //MessageBox.Show(command);
            }
            //System.Net.Sockets.SocketException will be thrown if database connection is unavailable.
            //SocketException should be handled by the calling function.
            //usually only a problem for timed refreshes.
            //catch(SqlException e){
            //	MessageBox.Show("Error: "+e.Message+","+cmd.CommandText);
            //}
            finally
            {
                con.Close();
            }
            return table;
        }

        ///<summary>Sends a non query command to the database and returns the number of rows affected. If true, then InsertID will be set to the value of the primary key of the newly inserted row.</summary>
        public int NonQ(string command)
        {
            return NonQ(command, false);
        }

        ///<summary>Sends a non query command to the database and returns the number of rows affected. If true, then InsertID will be set to the value of the primary key of the newly inserted row.</summary>
        public int NonQ(string command, bool getInsertID)
        {
            cmd.CommandText = command;
            int rowsChanged = 0;
            try
            {
                con.Open();
                rowsChanged = cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                ////MsgBoxCopyPaste MB = new MsgBoxCopyPaste(Lan.g("DataConnection", "Error in query:") + "\r\n"
                ////    + e.Message + "\r\n" + "\r\n"
                ////    + command);
                ////MB.ShowDialog();
                //MessageBox.Show("Error: "+e.Message+","+cmd.CommandText);
            }
            //catch{
            //	MessageBox.Show("Error: "+);
            //}
            finally
            {
                con.Close();
            }
            return rowsChanged;
        }

        ///<summary>Submits an array of commands in sequence. Used in conversions. Throws an exception if unsuccessful.  Returns the number of rows affected</summary>
        public int NonQ(string[] commands)
        {
            int rowsChanged = 0;
            con.Open();
            for (int i = 0; i < commands.Length; i++)
            {
                cmd.CommandText = commands[i];
                //Debug.WriteLine(cmd.CommandText);
                rowsChanged += cmd.ExecuteNonQuery();
            }
            con.Close();
            return rowsChanged;
        }

        ///<summary>Although this might be slightly faster, its use is being dropped because data will always be returned in datasets.  Use this for count(*) queries.  They are always guaranteed to return one and only one value.  Use(d) datareader instead of datatable, so faster.  Can also be used when retrieving prefs manually, since they will also return exactly one value</summary>
        public string GetCount(string command)
        {
            cmd.CommandText = command;
            con.Open();
            dr = (MySqlDataReader)cmd.ExecuteReader();
            dr.Read();
            string retVal = dr[0].ToString();
            con.Close();
            return retVal;
        }
        //balaji-execute query with parameters and return no of rows affected
        public int NonQWP(string command, Dictionary<string, Object> values)
        {
            int rowsChanged = 0;
            cmd.CommandText = command;
            con.Open();
            try
            {
                foreach (string s in values.Keys)
                {
                    cmd.Parameters.AddWithValue(s, values[s]);
                }
                rowsChanged = cmd.ExecuteNonQuery();
                con.Close();
                return rowsChanged;
            }
            catch (SqlException ex)
            {
                con.Close();
                return -1;
            }
        }
        //balaji - Execute query and return first row of first column
        public string ExeQWP(string command, Dictionary<string, Object> values = null)
        {

            cmd.CommandText = command;
            con.Open();
            try
            {
                if (values != null)
                    foreach (string s in values.Keys)
                    {
                        cmd.Parameters.AddWithValue(s, values[s]);
                    }
                object value = cmd.ExecuteScalar();
                con.Close();
                if (value == null)
                { return ""; }
                else { return value.ToString(); }

            }
            catch (Exception ex)
            {
                con.Close();
                return "";
            }
        }



        //Retrives the number of rows available in the given table-Divya Maheswari K

        public int RowCount(string command)
        {
            int count;
            cmd.CommandText = command;
            DataTable table = new DataTable();
            try
            {
                da = new MySqlDataAdapter(cmd);
                da.Fill(table);
                count = table.Rows.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return count;

        }

        //--Divya Maheswari
        public int RowId(string command)
        {
            int rowid;
            cmd.CommandText = command;
            con.Open();
            try
            {
                dr = (MySqlDataReader)cmd.ExecuteReader();
                dr.Read();
                rowid = Convert.ToInt32(dr[0].ToString());
                con.Close();
                return rowid;
            }
            catch (SqlException ex)
            {
                throw ex;

            }


        }

        //---Divya
        public DataTable RunProcWP(string command)
        {
            DataTable temp = new DataTable();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            try
            {
                //Dim parmReturnValue As SqlParameter

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(temp);
                return temp;
            }
            catch (Exception ex)
            {
                return temp;

            }

        }
        public DataSet RunDataSetProc(string command, Dictionary<string, Object> values = null)
        {
            DataSet temp = new DataSet();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            try
            {
                //Dim parmReturnValue As SqlParameter
                foreach (string key in values.Keys)
                {
                    cmd.Parameters.AddWithValue(key, values[key]);

                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(temp);
                return temp;
            }
            catch (Exception ex)
            {
                return temp;

            }

        }

        public DataTable RunProc(string command, Dictionary<string, Object> values = null)
        {
            DataTable temp = new DataTable();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            try
            {
                //Dim parmReturnValue As SqlParameter
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {

                        cmd.Parameters.AddWithValue(key, values[key]);


                    }
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(temp);
                return temp;
            }
            catch (Exception ex)
            {
                return temp;

            }

        }

        //run procedure and return no.of rows affected
        //public int RunDmlProc(string command, Dictionary<string, Object> values = null)
        //{
        //    int rowsChanged = 0;
        //    cmd.CommandText = command;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        //Dim parmReturnValue As SqlParameter
        //        if (values != null)
        //        {

        //            foreach (string key in values.Keys)
        //            {

        //                cmd.Parameters.AddWithValue(key, values[key]);


        //            }
        //        }
        //        con.Open();
        //        rowsChanged = cmd.ExecuteNonQuery();
        //        con.Close();
        //        return rowsChanged;
        //    }
        //    catch (Exception ex)
        //    {
        //        return rowsChanged;

        //    }

        //}

        public int RunDmlProc(string command, Dictionary<string, Object> values = null)
        {
            int rowsChanged = 0;
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            string retval = string.Empty;
            try
            {
                //Dim parmReturnValue As SqlParameter
                if (values != null)
                {

                    foreach (string key in values.Keys)
                    {

                        if (values[key] == "out")
                        {
                            cmd.Parameters.Add(key, MySqlDbType.VarChar);
                            cmd.Parameters[key].Direction = ParameterDirection.Output;

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(key, values[key]);
                        }
                    }
                }
                con.Open();
                rowsChanged = cmd.ExecuteNonQuery();
                retval = (string)cmd.Parameters["p_out_result"].Value;
                con.Close();
                return Convert.ToInt32(retval);
            }
            catch (Exception ex)
            {
                return rowsChanged;

            }

        }

        //run proc and return 1st row value
        public string RunExecProc(string command, Dictionary<string, Object> values = null)
        {
            string row = "";
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                //Dim parmReturnValue As SqlParameter
                if (values != null)
                {

                    foreach (string key in values.Keys)
                    {

                        cmd.Parameters.AddWithValue(key, values[key]);


                    }
                }
                con.Open();
                cmd.CommandTimeout = 0;
                row = cmd.ExecuteScalar().ToString();
                con.Close();
                return row;
            }
            catch (Exception ex)
            {
                return row;

            }

        }
        //Divya Retrives the record from database and returns the rows affescted by passing a set of values --Divya Mheswari k(Used in Scheduledata Bussiness File)

        public int ExeRdrWP(string command, Dictionary<string, Object> values)
        {
            int row = 0;
            Object obj = new Object();
            cmd.CommandText = command;
            con.Open();
            try
            {
                foreach (string s in values.Keys)
                {
                    cmd.Parameters.AddWithValue(s, values[s]);
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    row = row + 1;
                }
                con.Close();
                return row;

            }
            catch (SqlException ex)
            {

                con.Close();
                return -1;
            }
        }

        public DataTable RunTypeProc(string command, Dictionary<string, Object> values = null)
        {
            DataTable temp = new DataTable();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            try
            {
                //Dim parmReturnValue As SqlParameter
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        if (key != "@ProgramNameList")
                        {
                            cmd.Parameters.AddWithValue(key, values[key]);
                        }
                        else
                        {

                            MySqlParameter tvparam = cmd.Parameters.AddWithValue("@ProgramNameList", values[key]);
                            tvparam.MySqlDbType = MySqlDbType.String;
                        }
                    }
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(temp);
                return temp;
            }
            catch (Exception ex)
            {
                return temp;

            }

        }

        public DataTable Checkvaliduser(EmployeeDetails users)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand("WHS_Checkvaliduser_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_username", MySqlDbType.VarChar).Value = users.UserName;
                cmd.Parameters.Add("In_password", MySqlDbType.VarChar).Value = users.Password;
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
