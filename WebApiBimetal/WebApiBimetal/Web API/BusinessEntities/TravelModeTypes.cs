using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class TravelModeTypes
    {
        public int TravelMode_Id { get; set; }

        public string TravelType { get; set; }

        public string IsRemoved { get; set; }

        public string IsActive { get; set; }
    }
    public class TicketExpenses
    {
        public int Ticket_Expenses_Id { get; set; }

        public int? TravelMode_Id { get; set; }

        public int? Employee_Id { get; set; }

        public int? Expenses_ID { get; set; }

        public int? Claim_No { get; set; }

        public DateTime? date { get; set; }

        public string Place_From { get; set; }

        public string Place_To { get; set; }

        public decimal? Amount { get; set; }

        public string Description { get; set; }

        public string Is_Active { get; set; }

        public DateTime? Created_Date { get; set; }

        public DateTime? DeleteDate { get; set; }

        public string DeleteBy { get; set; }

    }
}
