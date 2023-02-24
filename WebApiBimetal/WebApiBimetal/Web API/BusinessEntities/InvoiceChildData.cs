using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class InvoiceChildData
    {
       public int Invoice_chd_Id { get; set; }
       public int Invoice_Id { get; set; }
       public string Product_Code { get; set; }
       public string InvoiceNo { get; set; }
       public DateTime InvoiceDate { get; set; }
       public string Distributor_Code { get; set; }
       public string  Distributor_name { get; set; }
       public decimal Rate { get; set; }
       public int Quantity { get; set; }
       public decimal Amount { get; set; }
       public decimal IGSTper { get; set; }
       public decimal IGSTAmount { get; set; }
       public decimal CGSTper { get; set; }
        public decimal CGSTAmount { get; set; }
       public decimal SGSTper { get; set; }
       public decimal SGSTAmount { get; set; }
       public decimal Total { get; set; }
       public string barcode_generated { get; set; }
       public string Inserted_by { get; set; }
       public string Is_Removed { get; set; }
       public string IsActive { get; set; }
       public string invoiDate { get; set; }
    }
}
