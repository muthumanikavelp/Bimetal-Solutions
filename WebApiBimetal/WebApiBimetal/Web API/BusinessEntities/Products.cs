using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    [DataContract]
    public class Products
    {
        [DataMember]
        public string PId;
        [DataMember]
        public string productname;

    }
}
