using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Productsdata
    {
        public int Product_Id { get; set; }

        public string Product_Code { get; set; }

        public string Prodect_Description { get; set; }

        public decimal? ListPrice { get; set; }

        public DateTime? Inserted_date { get; set; }

        public int? Inserted_By { get; set; }

        public string Is_Removed { get; set; }

        public string IsActive { get; set; }
    }
}
