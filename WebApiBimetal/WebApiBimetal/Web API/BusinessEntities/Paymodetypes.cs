using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Paymodetypes
    {
        public int Pyment_Id { get; set; }

        public string Paymode { get; set; }

        public string IsRemoved { get; set; }

        public string IsActive { get; set; }
    }
}
