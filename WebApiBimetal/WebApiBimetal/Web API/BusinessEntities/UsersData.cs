using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BusinessEntities
{
    [DataContract]
    public class UsersData
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int User_Group_id { get; set; }
        [DataMember]
        public string IsActive { get; set; }
        [DataMember]
        public int code { get; set; }
        [DataMember]
        public string message { get; set; }
    }
     [DataContract]
    public class UserGroups
    {
        [DataMember]
        public int User_Group_Id { get; set; }
        [DataMember]
        public string User_Group_name { get; set; }
        [DataMember]
        public string IsActive { get; set; }

    }

}
