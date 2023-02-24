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
   public class EmpolyeeBusiness
    {      
      
       public static EmployeeDetails EmployeeDetailsbyid(int empid)
       {
           DataTable tab = new DataTable();
           EmployeeDetails employees = new EmployeeDetails();
           try
           {
               EmployeeModel objproduct = new EmployeeModel();
               employees = objproduct.getempinfobyid(empid);
               return employees;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public static EmployeeDetails UploadEmployeeImage(int empid, string image)
        {
            DataTable tab = new DataTable();
            EmployeeDetails barcodes = new EmployeeDetails();
            try
            {
                EmployeeModel objbarcode = new EmployeeModel();
                barcodes = objbarcode.uploadimage(empid,image);
                return barcodes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
    }
}
