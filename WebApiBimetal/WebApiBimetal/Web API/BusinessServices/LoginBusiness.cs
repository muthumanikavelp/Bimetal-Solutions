using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel;
namespace BusinessServices
{
    public class LoginBusiness
    {
        /// <summary>
        /// Charan
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pwd"></param>
        /// <param name="ug"></param>
        /// <param name="email"></param>
        /// <param name="active"></param>
        /// <returns></returns>
            

      
     
        /// <summary>
        ///----Gayatri---
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="usergroupid"></param>
        /// <returns></returns>
        #region    
        public static EmployeeDetails GetLoginInfo(string username, string password, Char Mob_Flag)
        {

            DataTable tab = new DataTable();
            EmployeeDetails user = new EmployeeDetails();
            try
            {
                Logindata objproduct = new Logindata();
                tab = objproduct.getlogindata(username, password, Mob_Flag);
                if (tab.Rows.Count > 0)
                {
                    foreach (DataRow dr in tab.Rows)
                    {
                        user.code = int.Parse(dr["Code"].ToString());
                        if (user.code == 0)
                        {
                            user.Employee_Id = int.Parse(dr["Employee_Id"].ToString());
                            //user.Deapartment_Id = int.Parse(dr["Deapartment_Id"].ToString());
                            user.Name = dr["Name"].ToString();
                            user.message = "Success";
                            user.Password_flag = dr["Password_flag"].ToString();
                            if (dr["Image"] != null)
                            {
                                //byte[] photo = (byte[])dr["Image"];
                                //var plainTextBytes = Encoding.UTF8.GetBytes(photo.ToString());
                                //user.Image = Convert.ToBase64String(plainTextBytes);
                                user.Image = dr["Image"].ToString(); 
                            }

                            else
                            {
                                user.Image = null;
                            }
                        }
                        else
                        {
                            user.Employee_Id = 0;
                            //user.Deapartment_Id = 0;
                            user.Name = null;
                            user.message = dr["Message"].ToString();
                            user.Image = null;
                            user.Password_flag = null;
                        }
                    }
                }
                else
                {
                    user.Employee_Id = 0;
                    //user.Deapartment_Id = 0;
                    user.Name = null;
                    user.message = "Failed";
                    user.Image = null;
                    user.Password_flag = null;
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region
        public DataTable Checkvaliduser(EmployeeDetails users)
        {
            DataConnection objData = new DataConnection();
            //int ret=0;
            //DataTable dt = new DataTable();
            try
            {
                return objData.Checkvaliduser(users);
                //DataConnection objData = new DataConnection();
                //dt = objData.Checkvaliduser(users);
                //if (dt.Rows.Count > 0)
                //{
                //    string message=dt.Rows[0][0].ToString();
                //    if (message == "validuser")
                //    {
                //        ret = 1;
                //    }
                //    else
                //    {
                //        ret = 0;
                //    }
                //}
                //return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion



        public static EmployeeDetails ChangePassword(int empid, string password,string newpassword,string confirmpassword,string flag)
        {

            DataTable tab = new DataTable();
            EmployeeDetails user = new EmployeeDetails();
            try
            {
                Logindata objproduct = new Logindata();
                tab = objproduct.changepassword(empid, password, newpassword, confirmpassword, flag);
                if (tab.Rows.Count > 0)
                {
                    foreach (DataRow dr in tab.Rows)
                    {
                        user.code = int.Parse(dr["Code"].ToString());                                             
                        user.message = dr["Message"].ToString();

                        if (user.code==0)
                        {
                            user.Password_flag = dr["Password_flag"].ToString();
                        }
                        else
                        {
                            user.Password_flag = null;
                        }
                    }
                }
                else
                {
                    user.code = 1;
                    user.message = "Change Password Process Failed";
                    user.Password_flag = null;
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
