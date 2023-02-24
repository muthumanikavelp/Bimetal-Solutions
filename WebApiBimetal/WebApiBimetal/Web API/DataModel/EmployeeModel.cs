using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System;
using System.IO;

namespace DataModel
{
    public class EmployeeModel
    {

        //public DataTable Get_All_Employees(int empid)
        //{
        //    DataTable tab = new DataTable();
        //    try
        //    {
        //        Dictionary<string, Object> values = new Dictionary<string, object>();
        //        DataConnection con = new DataConnection();
        //        values.Add("p_emp_id", empid);
        //        tab = con.RunProc("Get_All_Employee", values);
        //        return tab;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}



        //public int insert_employee(EmployeeDetails p)
        //{
        //    int i = 0;
        //    DataTable tab = new DataTable();
        //    DataConnection con = new DataConnection();
        //    try
        //    {
        //        Dictionary<string, Object> values = new Dictionary<string, object>();
        //        values.Add("@Employee_Code", p.Employee_Code);
        //        values.Add("@Employee_name", p.Employee_name);
        //        values.Add("@Employee_password", p.Password);
        //        values.Add("@Deapartment_Id", p.Deapartment_Id);
        //        values.Add("@Grade", p.Grade);
        //        values.Add("@Location", p.Location);
        //        values.Add("@Designation", p.Designation);
        //        values.Add("@Country_Id", p.Country_Id);
        //        values.Add("@State_id", p.State_id);
        //        values.Add("@City_Id", p.City_Id);
        //        values.Add("@Reporting_to", p.Reporting_to);
        //        values.Add("@Expense_approver", p.Expense_approver);
        //        values.Add("@Moile_no", p.Mobile_no);
        //        values.Add("@Email_id", p.Email_id);
        //        values.Add("@Account_No", p.Account_No);
        //        values.Add("@Bank", p.Bank);
        //        values.Add("@Branch", p.Branch);
        //        values.Add("@IFSC_code", p.IFSC_code);
        //        values.Add("@Inserted_date", p.Inserted_date);
        //        values.Add("@Inserted_by", p.Inserted_by);
        //        values.Add("@Is_Removed", p.Is_Removed);
        //        values.Add("@IsActive", p.IsActive);

        //        tab = con.RunProc("insert_employee", values);
        //        if (tab.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in tab.Rows)
        //            {
        //                i = int.Parse(dr["Id"].ToString());

        //            }
        //        }
        //        return i;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public EmployeeDetails getempinfobyid(int empid)
        {
            EmployeeDetails employees = new EmployeeDetails();
            DataTable tab = new DataTable();          
            try
            {
                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();
                values.Add("p_emp_id", empid);
                tab = con.RunProc("GetEmployeesById", values);
               
                if (tab.Rows.Count > 0)
                {
                    employees.code= int.Parse(tab.Rows[0]["code"].ToString());
                    if(employees.code==0)
                    {
                        employees.message = "Success";                      
                        employees.Employee_name = tab.Rows[0]["Employee_name"].ToString();
                        employees.Employee_Id = int.Parse(tab.Rows[0]["Employee_Id"].ToString());
                        employees.Email_id = tab.Rows[0]["Email_id"].ToString();
                        employees.Mobile_no = tab.Rows[0]["Moile_no"].ToString();
                        employees.Location = tab.Rows[0]["Location"].ToString();                     
                        employees.Bank = tab.Rows[0]["Bank"].ToString();
                        employees.Branch = tab.Rows[0]["Branch"].ToString();
                        employees.City_Id = int.Parse(tab.Rows[0]["City_Id"].ToString());
                        employees.Country_Id = int.Parse(tab.Rows[0]["Country_Id"].ToString());
                        employees.State_id = int.Parse(tab.Rows[0]["State_id"].ToString());                      
                        employees.Employee_Code = tab.Rows[0]["Employee_Code"].ToString();                       
                        employees.IFSC_code = tab.Rows[0]["IFSC_code"].ToString();
                        employees.Account_No = tab.Rows[0]["Account_No"].ToString();
                        employees.Employee_Type = tab.Rows[0]["Employee_Type"].ToString();
                        employees.Address = tab.Rows[0]["Address"].ToString();
                        if (tab.Rows[0]["Image"] != null)
                        {
                            //byte[] photo = (byte[])tab.Rows[0]["Image"];
                            //var plainTextBytes = Encoding.UTF8.GetBytes(photo.ToString());
                            //employees.Image = Convert.ToBase64String(plainTextBytes);
                            employees.Image = tab.Rows[0]["Image"].ToString();
                        }

                        else
                        {
                            employees.Image = null;
                        }
                    }
                    else
                    {
                        employees.code = 1;
                        employees.message = "Failed";                     
                        employees.Employee_name = null; 
                        employees.Employee_Id = 0;
                        employees.Email_id = null;
                        employees.Mobile_no = null;
                        employees.Location = null;                        
                        employees.Account_No = null;
                        employees.Bank = null;
                        employees.Branch = null;
                        employees.City_Id = 0;
                        employees.Country_Id =0;
                        employees.State_id = 0;                        
                        employees.Employee_Code =null;                      
                        employees.IFSC_code = null;                     
                        employees.Account_No = null;
                        employees.Employee_Type = null;
                        employees.Address = null;
                        employees.Image = null;
                        
                    }
                   
                    return employees;
                }
                else
                {
                    employees.code = 1;
                    employees.message = "Failed";
                    employees.Employee_name = null;
                    employees.Employee_Id = 0;
                    employees.Email_id = null;
                    employees.Mobile_no = null;
                    employees.Location = null;
                    employees.Account_No = null;
                    employees.Bank = null;
                    employees.Branch = null;
                    employees.City_Id = 0;
                    employees.Country_Id = 0;
                    employees.State_id = 0;
                    employees.Employee_Code = null;
                    employees.IFSC_code = null;
                    employees.Account_No = null;
                    employees.Employee_Type = null;
                    employees.Address = null;
                    employees.Image = null;

                    return employees;
                }

            }
            catch(Exception ex)
            {
                return employees;
            }
        }
        public EmployeeDetails uploadimage(int empid,string image)
        {
            int result = 0;

            DataTable tab = new DataTable();
            EmployeeDetails barcodes = new EmployeeDetails();
            try
            {

                DataConnection con = new DataConnection();
                Dictionary<String, Object> values = new Dictionary<string, object>();

                values.Add("p_emp_id", empid);
                values.Add("p_sign", image);

                tab = con.RunProc("UploadEmployeeImage", values);
                if (tab.Rows.Count > 0)
                {

                    foreach (DataRow dr in tab.Rows)
                    {
                        barcodes.message = dr["message"].ToString();
                        barcodes.code = int.Parse(dr["code"].ToString());
                        if (dr["Image"] != null)
                        {
                            //byte[] photo = (byte[])dr["Image"];
                            //var plainTextBytes = Encoding.UTF8.GetBytes(photo.ToString());
                            //barcodes.Image = Convert.ToBase64String(plainTextBytes);
                            barcodes.Image = dr["Image"].ToString();

                        }

                        else
                        {
                            barcodes.Image = null;
                        }                      
                    }
                }
                else
                {
                    barcodes.message = "Image Upload failed";
                    barcodes.code = 1;
                }
                return barcodes;
            }
            catch (Exception ex)
            {
                return barcodes;
            }
        }
    }
}
