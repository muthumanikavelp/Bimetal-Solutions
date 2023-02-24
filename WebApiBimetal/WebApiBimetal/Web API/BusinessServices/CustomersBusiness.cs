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
    public class CustomersBusiness
    {
        public static List<Customers> GetCustomersList(int Executive_Id)
        {
            DataTable tab = new DataTable();
            List<Customers> lProducts;
            try
            {
                CustomersData objproduct = new CustomersData();
                lProducts = objproduct.getallcustomers(Executive_Id);
                return lProducts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
