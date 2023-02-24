using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Barcodes
    {
        [DataMember]
        public int Barcode_id { get; set; }
        [DataMember]
        public int Invoice_chd_id { get; set; }
        [DataMember]
        public string Barcode { get; set; }
        [DataMember]
        public decimal Barcode_amount { get; set; }
        [DataMember]
        public string Is_Removed { get; set; }
        [DataMember]
        public string Is_Active { get; set; }
        [DataMember]
        public string Is_Printed { get; set; }
        [DataMember]
        public int Generated_by { get; set; }
        [DataMember]
        public DateTime Generated_date { get; set; }    
        [DataMember]
        public DateTime Scanned_Date { get; set; }
        [DataMember]
        public int Agent_id { get; set; }
        [DataMember]
        public int Customer_id { get; set; }
         [DataMember]
        public string Scan_mode { get; set; }        
        [DataMember]
        public string Customer_Sign { get; set; }
        //[DataMember]
        //public byte[] Signature;
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int Coupon_count { get; set; }
        [DataMember]
        public decimal Coupon_amount { get; set; }
        [DataMember]
        public string IsRemoved { get; set; }
        [DataMember]
        public int ChildBarcode_id { get; set; }       
        [DataMember]
        public decimal Amount { get; set; }
        [DataMember]
        public string Barcode_no { get; set; }
        [DataMember]
        public int  code { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string month { get; set; }      
        [DataMember]
        public string Paymode { get; set; }
        [DataMember]
        public string Product_Code { get; set; }

        [DataContract]
        public class BarcodesData
        {
            [DataMember]
            public int code { get; set; }
            [DataMember]
            public string message { get; set; }
            [DataMember]
            public Decimal Coupon_amount { get; set; }
            [DataMember]
            public int Coupon_count { get; set; }
            [DataMember]
            public string Customer_Sign { get; set; }
            [DataMember]
            public string Paymode { get; set; }
            //[DataMember]
            //public byte[] Signature;
            [DataMember]
            public List<Barcodes> BarcodeInfo;

        }
        [DataContract]
        public class AgentHistory
        {
            [DataMember]
            public int code { get; set; }
            [DataMember]
            public string message { get; set; }          
            [DataMember]
            public List<Scan> ScanDetails;
            //[DataMember]
            //public List<Barcodes> BarcodeDetails;
        }
        [DataContract]
        public class Scan
        {
            [DataMember]
            public int Barcode_id { get; set; }
            [DataMember]
            public int Customer_id { get; set; }
            [DataMember]
            public string Customer_name { get; set; }
            [DataMember]
            public string Status { get; set; }
            [DataMember]
            public decimal Amount { get; set; }
            [DataMember]
            public DateTime Scanned_Date { get; set; }
            [DataMember]
            public string Customer_Sign { get; set; }
            [DataMember]
            public List<Barcodess> BarcodeDetails;
        }
        [DataContract]
        public class Barcodess
        {
            [DataMember]
            public string Barcode_no { get; set; }
            [DataMember]
            public int ChildBarcode_id { get; set; }
            [DataMember]
            public int Barcode_id { get; set; }
            [DataMember]
            public decimal Amount { get; set; }
            [DataMember]
            public DateTime Scanned_Date { get; set; }

        }

    }
   

}
