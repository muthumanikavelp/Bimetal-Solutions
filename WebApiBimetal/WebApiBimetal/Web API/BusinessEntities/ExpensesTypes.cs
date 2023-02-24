using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class ExpensesTypes
    {
        public int Expenses_ID { get; set; }

        public string Expenses_Type { get; set; }

        public string Is_Active { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
