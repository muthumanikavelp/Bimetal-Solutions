using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Countries:states
    {
        public int country_Id { get; set; }

        public string Country_name { get; set; }

        public string IsRemoved { get; set; }

        public string IsActive { get; set; }
    }
    public class states:cities
    {
        public int State_Id { get; set; }

        public string State_name { get; set; }

        public int? Country_Id { get; set; }

        public string IsRemoved { get; set; }

        public string IsActive { get; set; }

    }

    public class cities
    {
        public int City_Id { get; set; }

        public string City_name { get; set; }

        public int State_Id { get; set; }

        public string IsRemoved { get; set; }

        public string IsActive { get; set; }

    }
}
