using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace DataModel
{
  public  class Logindata
    {
      /// <summary>
      /// -----Charan
      /// </summary>
      /// <param name="userid"></param>
      /// <param name="pwd"></param>
      /// <param name="ug"></param>
      /// <param name="email"></param>
      /// <param name="active"></param>
      /// <returns></returns>
      ///
      
      /// <summary>
      /// ----Gayatri
      /// </summary>
      /// <param name="uname"></param>
      /// <param name="pwd"></param>
      /// <param name="ugroupid"></param>
        /// <returns></returns>
        #region
       
        public DataTable getlogindata(string uname, string pwd, Char Mob_Flag)
        {
            DataTable tab = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("p_username", uname);
                values.Add("p_password", pwd);
                values.Add("p_MobFlag", Mob_Flag);
                tab = con.RunProc("ValidateLogin", values);
                return tab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public DataTable changepassword(int empid, string pwd,string npwd,string conpwd,string flag)
        {
            DataTable tab = new DataTable();
            try
            {
                Dictionary<string, Object> values = new Dictionary<string, object>();
                DataConnection con = new DataConnection();
                values.Add("p_empid", empid);
                values.Add("p_password", pwd);
                values.Add("p_newpassword", npwd);
                values.Add("p_conpassword", conpwd);
                values.Add("p_flag", flag);
                
                tab = con.RunProc("ChangePassword", values);
                return tab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
