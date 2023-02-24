using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class InvoiceMasterData : InvoiceChildData
    {
      public int Invoice_Id { get; set; }
      public int Uploaded_By { get; set; }
      public DateTime Uploaded_Date { get; set; }
      public string BarcodeStatus { get; set; }
      public string FileName { get; set; }
      public string EmployeeName { get; set; }
      public string Extension { get; set; }
      public string Is_Removed { get; set; }
      public string Is_Active { get; set; }
     
    }
}
