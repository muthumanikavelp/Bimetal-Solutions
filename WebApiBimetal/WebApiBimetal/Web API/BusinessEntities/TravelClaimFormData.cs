using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class TravelClaimFormData
    {
        public int Travl_cl_Id { get; set; }

        public int? Employee_Id { get; set; }

        public int? Claim_No { get; set; }

        public DateTime? Claim_date { get; set; }

        public decimal? Gross_Claim { get; set; }

        public decimal? Net_Claim { get; set; }

        public decimal? Total_Amount { get; set; }

        public int? Travel_Requisition_no { get; set; }

        public DateTime? Date_From { get; set; }

        public DateTime? Date_To { get; set; }

        public string Place { get; set; }

        public string Purpose { get; set; }

        public DateTime Created_date { get; set; }

        public string Status { get; set; }

        public DateTime? DeleteDate { get; set; }

        public string DeleteBy { get; set; }

        public string ProcedDonBy { get; set; }

    }
}
