using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace BusinessEntities
{
    [DataContract]
    public class GatepassEntities
    {
        [DataMember]
        public string Driver_VehicleNo { get; set; }
        [DataMember]
        public string Driver_MobileNo { get; set; }
        [DataMember]
        public int Login_GID { get; set; }
        [DataMember]
        public int Gatepass_GID { get; set; }
        [DataMember]
        public string InvoiceNo { get; set; }
        [DataMember]
        public int Gatepass_Invoice_Gid { get; set; }
        [DataMember]
        public decimal Netwieght { get; set; }
        [DataMember]
        public string AirwayBillNo { get; set; }
        [DataMember]
        public char Status { get; set; }
        [DataMember]
        public string GatepassNo { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string Action { get; set; }
        [DataMember]
        public string LLRNo { get; set; }
        [DataMember]
        public string CurStatus { get; set; }
        [DataMember]
        public Int32 Actual_Cases { get; set; }
        [DataMember]
        public Int32 Scanned_Cases { get; set; }
        [DataMember]
        public Int32 NoofInvoices { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }
        [DataMember]
        public string FileString { get; set; }
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public string Extension { get; set; }
        [DataMember]
        public string DocumentGroup { get; set; }
        [DataMember]
        public string DocumentName { get; set; }
        [DataMember]
        public Int32 Pending_Cases { get; set; }
        [DataMember]
        public Int32 NoofScannedCases { get; set; }
    }
}
