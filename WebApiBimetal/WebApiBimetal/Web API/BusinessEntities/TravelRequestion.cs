using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
  public  class TravelRequestion
    {
      public int Tr_Req_Id { get; set; }

      public int? Employee_Id { get; set; }

      public string Tr_no { get; set; }

      public string Place { get; set; }

      public DateTime? Datefrom { get; set; }

      public DateTime? Dateto { get; set; }

      public string Purpose { get; set; }

      public string Is_Active { get; set; }

      public DateTime? Created_date { get; set; }

      public DateTime? Deleted_Date { get; set; }

        public string Delete_By { get; set; }

        public string Status { get; set; }

        public string Statge { get; set; }

        public int ProcedDonBy { get; set; }

    }
}
