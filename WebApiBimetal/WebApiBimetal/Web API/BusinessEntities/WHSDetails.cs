using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class WHSDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string message { get; set; }
        public string partno { get; set; }
        public string invoiceno { get; set; }
        public string _productcode { get; set; }
        public int _Qty { get; set; }
        public int _insertedby { get; set; }
        public string _barcode { get; set; }
        public DateTime _fromdate { get; set; }
        public DateTime _todate { get; set; }

        public string _userid { get; set; }
        public string _toemailid { get; set; }
        public int _otpnumber { get; set; }
        public string _currentpwd { get; set; }
        public string _newpwd { get; set; }
        public string _frominvno { get; set; }
        public string _toinvno { get; set; }
        public string _sitelocation { get; set; }
        public string _gatepassno { get; set; }
        public string _boxno { get; set; }

        public string _plantlocation { get; set; }

        public DateTime invoicedate_ { get; set; }
        public string invoiceno_ { get; set; }
        public string invoceboxno_ { get; set; }
        public string invoiceitemcode_ { get; set; }
    }
}
