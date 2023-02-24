using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
  public  class FieldExecutiveData
    {
        public int Executive_Id { get; set; }

        public string Employee_Code { get; set; }

        public string Employee_name { get; set; }

        public string Location { get; set; }

        public int? Country_Id { get; set; }

        public int? State_Id { get; set; }

        public int? City_Id { get; set; }

        public string Contact_no { get; set; }

        public string Email_id { get; set; }

        public DateTime? Inserted_date { get; set; }

        public int? Inserted_by { get; set; }

        public string Is_Removed { get; set; }

        public string IsActive { get; set; }
    }
}
