using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Subcategory
    {

        public int Menu_Id { get; set; }

        public int Cat_id { get; set; }

        public string Sub_menu { get; set; }

    }
    public class categories
    {

        public int Menu_Id { get; set; }

        public string MenuName { get; set; }

        public int value { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

    }
}
