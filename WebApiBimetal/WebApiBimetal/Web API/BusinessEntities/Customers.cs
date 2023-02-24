using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    [DataContract]
    public class Customers
    {

        [DataMember]
        public string Customer_Id { get; set; }
        [DataMember]
        public string Customer_Name { get; set; }
        [DataMember]
        public string code { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public int Executive_Id { get; set; }



        //public List<Customers> People { get; set; }
        //[DataMember]
        //public string Customer_code { get; set; }
       
        //[DataMember]
        //public string Location { get; set; }
        //[DataMember]
        //public string Country_Id { get; set; }
        //[DataMember]
        //public string StateId { get; set; }
        //[DataMember]
        //public string City_Id { get; set; }
        //[DataMember]
        //public string Contact_person { get; set; }
        //[DataMember]
        //public string Mobile_no { get; set; }
        //[DataMember]
        //public string Email_id { get; set; }
        //[DataMember]
        //public string Bank_name { get; set; }
        //[DataMember]
        //public string Branch { get; set; }
        //[DataMember]
        //public string Bank_account_no { get; set; }
        //[DataMember]
        //public string IFSC_code { get; set; }
        //[DataMember]
        //public DateTime Inserted_date { get; set; }
        //[DataMember]
        //public string Inserted_by { get; set; }
        //[DataMember]
        //public string Is_Removed { get; set; }
        //[DataMember]
        //public string IsActive { get; set; }
        //[DataMember]
        //public string DeleteDate { get; set; }
        //[DataMember]
        //public string DeleteBy { get; set; }

    

       
    }
    //[DataContract]
    //public class CustomerList
    //{
    //    [DataMember]
    //    public List<CustomerList> custlist;

    //}

}
