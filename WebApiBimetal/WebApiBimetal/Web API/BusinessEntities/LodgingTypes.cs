using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class LodgingTypes
    {
        public int Lodging_Id { get; set; }

        public string Lodging_type { get; set; }

        public string IsRemoved { get; set; }

        public string IsActive { get; set; }
    }
    public class LodgingExpenses
    {
        public int Lodging_Expenses_Id { get; set; }

        public int Lodging_Id { get; set; }

        public int? Employee_Id { get; set; }

        public int? Expenses_ID { get; set; }

        public int? Claim_No { get; set; }

        public string Place { get; set; }

        public DateTime? Date_From { get; set; }

        public DateTime? Date_To { get; set; }

        public decimal? Amount { get; set; }

        public string Description { get; set; }

        public string Is_active { get; set; }

        public DateTime? Created_date { get; set; }

        public DateTime? DeleteDate { get; set; }

        public string DeleteBy { get; set; }

    }

}
