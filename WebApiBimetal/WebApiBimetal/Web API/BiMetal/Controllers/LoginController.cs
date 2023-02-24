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

namespace BiMetal.Controllers
{
    public class LoginController : ApiController
    {
        log4net.ILog logger4net = log4net.LogManager.GetLogger(typeof(LoginController));
        [Route("GetLoginInfo")]

        [HttpPost]
        public EmployeeDetails GetLoginInfo()
        {
            EmployeeDetails users = new EmployeeDetails();
            try
            {
                EmployeeDetails user = new EmployeeDetails();

                // Data Reterive From Post
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                user = (EmployeeDetails)JsonConvert.DeserializeObject(post_data, user.GetType());

                //
                users = LoginBusiness.GetLoginInfo(user.UserName, user.Password, user.Mob_Flag);
                return users;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return users;
            }
        }

        [Route("ChangePassword")]
        [HttpPost]
        public EmployeeDetails ChangePassword()
        {
            EmployeeDetails users = new EmployeeDetails();
            try
            {
                EmployeeDetails user = new EmployeeDetails();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;

                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                user = (EmployeeDetails)JsonConvert.DeserializeObject(post_data, user.GetType());
                users = LoginBusiness.ChangePassword(user.Employee_Id, user.Password, user.NewPassword, user.ConfirmPassword, user.Password_flag);
                return users;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return users;
            }
        }

        [Route("GetLoginInfo1")]
        [HttpPost]
        public EmployeeDetails GetLoginInfo1([FromBody] string userName, string Password, char Mob_flag)
        {
            EmployeeDetails users = new EmployeeDetails();
            try
            {
                users = LoginBusiness.GetLoginInfo(userName, Password, Mob_flag);
                return users;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return users;
            }
        }
       
    }
}
