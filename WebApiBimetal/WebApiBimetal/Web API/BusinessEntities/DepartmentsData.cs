using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
  public class DepartmentsData
    {
        public int Department_Id { get; set; }

        public string Department { get; set; }

        public string IsRemoved { get; set; }

        public string IsActive { get; set; }
    }
}
