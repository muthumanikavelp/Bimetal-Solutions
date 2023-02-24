using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
  public  class AdvancerequestForm:EmployeeDetails
  {     
          public int Add_Req_Cl_Id { get; set; }

          public int? Employee_Id { get; set; }

          public string Ar_No { get; set; }

          public string Ar_Type { get; set; }

          public DateTime? Ar_date { get; set; }

          public DateTime? Liq_Date { get; set; }

          public string Purpose { get; set; }

          public string Is_Active { get; set; }

          public DateTime? Created_date { get; set; }

          public DateTime? DeleteDate { get; set; }

          public string DeleteBy { get; set; }

          public string Status { get; set; }

          public string Statge { get; set; }

          public int ProcedDonBy { get; set; }

    }
}
