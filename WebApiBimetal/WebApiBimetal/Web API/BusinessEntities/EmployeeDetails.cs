using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{


    public class EmployeeDetails : UsersData
    {
        [DataMember]
        public int Employee_Id { get; set; }
        [DataMember]
        public string Employee_Code { get; set; }
        [DataMember]
        public string Employee_name { get; set; }
        [DataMember]
        public int Deapartment_Id { get; set; }
        [DataMember]
        public string Grade { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public string Designation { get; set; }
        [DataMember]
        public int Country_Id { get; set; }
        [DataMember]
        public int State_id { get; set; }
        [DataMember]
        public int City_Id { get; set; }
        [DataMember]
        public string Reporting_to { get; set; }
        [DataMember]
        public string Expense_approver { get; set; }
        [DataMember]
        public string Mobile_no { get; set; }
        [DataMember]
        public string Email_id { get; set; }
        [DataMember]
        public string Account_No { get; set; }
        [DataMember]
        public string Bank { get; set; }
        [DataMember]
        public string Branch { get; set; }
        [DataMember]
        public string IFSC_code { get; set; }
        [DataMember]
        public DateTime Inserted_date { get; set; }
        [DataMember]
        public int Inserted_by { get; set; }
        [DataMember]
        public string Is_Removed { get; set; }
        [DataMember]
        public string IsActive { get; set; }
        [DataMember]
        public DateTime DeleteDate { get; set; }
        [DataMember]
        public string DeleteBy { get; set; }
        [DataMember]
        public string Employee_Type { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int code { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Image { get; set; }
        //[DataMember]
        //public byte[] Photo { get; set; }
        [DataMember]
        public string NewPassword { get; set; }
        [DataMember]
        public string ConfirmPassword { get; set; }
        [DataMember]
        public string Password_flag { get; set; }

        [DataMember]
        public string partno { get; set; }

        [DataMember]
        public Char Mob_Flag { get; set; }
        
    }

}
