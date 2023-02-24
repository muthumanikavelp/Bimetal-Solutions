using BusinessEntities;
using BusinessServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BiMetal.Controllers
{
    public class EmployeesController : ApiController
    {

        log4net.ILog logger4net = log4net.LogManager.GetLogger(typeof(EmployeesController));
        //Employees Profile(View Profile Provision)
        [Route("GetEmployeeDetailsbyid")]
        [HttpPost]
        public EmployeeDetails GetEmployeeDetailsbyid()
        {
            EmployeeDetails employee = new EmployeeDetails();
            try
            {
                EmployeeDetails emp = new EmployeeDetails();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                emp = (EmployeeDetails)JsonConvert.DeserializeObject(post_data, emp.GetType());

                employee = EmpolyeeBusiness.EmployeeDetailsbyid(emp.Employee_Id);
                return employee;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return employee;
            }
        }

        //Upload Image(Employees)
        [Route("UploadEmployeeImage")]
        [HttpPost]
        public EmployeeDetails UploadEmployeeImage()
        {
            EmployeeDetails employee = new EmployeeDetails();
            try
            {
                EmployeeDetails emp = new EmployeeDetails();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();             
                emp = (EmployeeDetails)JsonConvert.DeserializeObject(post_data, emp.GetType());               
                string image = emp.Image;              
                employee = EmpolyeeBusiness.UploadEmployeeImage(emp.Employee_Id, emp.Image);             
                return employee;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return employee;
            }
        }        
    }
}
