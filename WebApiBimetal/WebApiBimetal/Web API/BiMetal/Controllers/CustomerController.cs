using BusinessEntities;
using BusinessServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiMetal.Controllers
{
    public class CustomerController : ApiController
    {
        log4net.ILog logger4net = log4net.LogManager.GetLogger(typeof(CustomerController));
        ////Customers Name List(Coupon Redemption Provision)
        //[Route("GetCustomersNameList")]
        //[HttpGet]
        //public List<Customers> GetCustomersList()
        //{
        //    List<Customers> ls_customers = new List<Customers>();

        //    try
        //    {
        //        ls_customers = CustomersBusiness.GetCustomersList();
        //        return ls_customers;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger4net.Error(ex.ToString());
        //        return ls_customers;
        //    }
        //}    


        [Route("GetCustomersNameList")]
        [HttpPost]
        public List<Customers> GetCustomersList()
        {
            List<Customers> ls_customers = new List<Customers>();
            try
            {
                Customers cus = new Customers();
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                cus = (Customers)JsonConvert.DeserializeObject(post_data, cus.GetType());
                ls_customers = CustomersBusiness.GetCustomersList(cus.Executive_Id);
                return ls_customers;

            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return ls_customers;
            }
        }        
    }
}
