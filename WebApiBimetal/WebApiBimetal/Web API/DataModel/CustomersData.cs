using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class CustomersData
    {
        public List<Customers> getallcustomers(int Executive_Id)
        {

            DataTable tab = new DataTable();
            List<Customers> lcustomers = new List<Customers>();
            try
            {
                
                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();
                values.Add("p_Executive_Id", Executive_Id);
                tab = con.RunProc("GetCustomerNameList",values);
                if(tab.Rows.Count>0)
                {
                   
                    foreach (DataRow dr in tab.Rows)
                    {
                        Customers cus = new Customers();
                        cus.Customer_Name = dr["Customer_Name"].ToString();
                        cus.Customer_Id = dr["Customer_Id"].ToString();
                        cus.message = "Success";
                        cus.code = "0";
                        lcustomers.Add(cus);
                    }
                }
                else
                {
                    Customers cuss = new Customers();
                    cuss.Customer_Name = null;
                    cuss.Customer_Id = null;
                    cuss.message = "Failure";
                    cuss.code = "1";
                    lcustomers.Add(cuss);
                }
                
                return lcustomers;
            }
            catch
            {
                return lcustomers;
            }
        }
    }
}
