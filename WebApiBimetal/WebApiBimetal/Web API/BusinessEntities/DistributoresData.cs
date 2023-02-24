using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class DistributoresData
    {
        public int Distributor_Id { get; set; }

        public string Distributor_code { get; set; }

        public string Distributor_name { get; set; }

        public string Location { get; set; }

        public int? Country_Id { get; set; }

        public int? State_Id { get; set; }

        public int? City_Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Pincode { get; set; }

        public string Contact_Person { get; set; }

        public string Mobile_no { get; set; }

        public string Email_id { get; set; }

        public string Bank_name { get; set; }

        public string Branch { get; set; }

        public string Bank_account_no { get; set; }

        public string IFSC_Code { get; set; }

        public DateTime? Inserted_date { get; set; }

        public int? Inserted_by { get; set; }

        public string Is_Removed { get; set; }

        public string IsActive { get; set; }
    }
}
