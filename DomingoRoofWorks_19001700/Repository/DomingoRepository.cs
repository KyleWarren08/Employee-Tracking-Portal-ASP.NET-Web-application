using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DomingoRoofWorks_19001700.Models;

namespace DomingoRoofWorks_19001700.Repository
{
    public class DomingoRepository
    {
        private SqlConnection conn;
        //To handle any connections to the database and the operations following
        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            conn = new SqlConnection(constr);
        }


        //Get/Return a view of all employees
        public List<EmployeeModel> GetAllEmployees()
        {
            Connection();
            List<EmployeeModel> EmployeeList = new List<EmployeeModel>();

            SqlCommand GetCommand = new SqlCommand("View_All_Employees", conn);
            GetCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(GetCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();
            //Bind EmployeeModel generic list using a data row
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeList.Add(new EmployeeModel
                {
                    Employee_ID = Convert.ToString(dr["Employee_ID"]),
                    Employee_Name = Convert.ToString(dr["Employee_Name"])
                }
                );
            }
            return EmployeeList;
        }

        //Add Employees
        public bool AddEmployee(EmployeeModel obj)
        {
            Connection();
            SqlCommand AddCommand = new SqlCommand("Create_Employees", conn);
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.Parameters.AddWithValue("@Employee_ID", obj.Employee_ID);
            AddCommand.Parameters.AddWithValue("@Employee_Name", obj.Employee_Name);
            conn.Open();
            int i = AddCommand.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Update an existing employee
        public bool UpdateEmployee(EmployeeModel obj)
        {
            Connection();
            SqlCommand UpdateCommand = new SqlCommand("Update_Employee", conn);

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.AddWithValue("@Employee_ID", obj.Employee_ID);
            UpdateCommand.Parameters.AddWithValue("@Employee_Name", obj.Employee_Name);

            conn.Open();
            int i = UpdateCommand.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //Delete Employee
        public bool DeleteEmployee(String Employee_ID)
        {
            Connection();
            SqlCommand DeleteCommand = new SqlCommand("DeleteEmployeebyID", conn);
            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.AddWithValue("@Employee_ID", Employee_ID);

            conn.Open();
            int i = DeleteCommand.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Get/Return a view of all Job_Cards
        public List<Job_CardModel> GetAllJob_Cards()
        {
            Connection();
            List<Job_CardModel> Job_CardList = new List<Job_CardModel>();

            SqlCommand GetCommand = new SqlCommand("View_All_Job_Cards", conn);
            GetCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(GetCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();
            //Bind JobCardModel generic list using a data row
            foreach (DataRow dr in dt.Rows)
            {
                Job_CardList.Add(new Job_CardModel
                {
                    Job_Card = Convert.ToString(dr["Job_Card"]),
                    Job_Type_ID = Convert.ToString(dr["Job_Type_ID"]),
                    Days_For_Job = Convert.ToInt32(dr["Days_For_Job"])
                }
                );
            }
            return Job_CardList;
        }

        //Add Job_Cards
        public bool AddJob_Card(Job_CardModel obj)
        {
            Connection();
            SqlCommand AddCommand = new SqlCommand("Create_New_Job_Card", conn);
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.Parameters.AddWithValue("@Job_Card", obj.Job_Card);
            AddCommand.Parameters.AddWithValue("@Job_Type_ID", obj.Job_Type_ID);
            AddCommand.Parameters.AddWithValue("@Days_For_Job", obj.Days_For_Job);
            conn.Open();
            int i = AddCommand.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete Job_Card
        public bool DeleteJob_Card(String Job_Card)
        {
            Connection();
            SqlCommand DeleteCommand = new SqlCommand("DeleteJob_CardbyID", conn);
            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.AddWithValue("@Job_Card", Job_Card);

            conn.Open();
            int i = DeleteCommand.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Get/Return a view of all Invoices
        public List<InvoiceModel> GetAllInvoices()
        {
            Connection();
            List<InvoiceModel> InvoiceList = new List<InvoiceModel>();

            SqlCommand GetCommand = new SqlCommand("View_All_Invoices", conn);
            GetCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(GetCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();
            //Bind InvoiceModel generic list using a data row
            foreach (DataRow dr in dt.Rows)
            {
                InvoiceList.Add(new InvoiceModel
                {
                    Invoice_ID = Convert.ToString(dr["Invoice_ID"]),
                    Invoice_Material_ID = Convert.ToString(dr["Invoice_Material_ID"]),
                    Customer_ID = Convert.ToString(dr["Customer_ID"]),
                    Job_Card = Convert.ToString(dr["Job_Card"])
                }
                );
            }
            return InvoiceList;
        }

        //Add Invoice
        public bool AddInvoice(InvoiceModel obj)
        {
            Connection();
            SqlCommand AddCommand = new SqlCommand("Create_New_Invoices", conn);
            AddCommand.CommandType = CommandType.StoredProcedure;
            AddCommand.Parameters.AddWithValue("@Invoice_ID", obj.Invoice_ID);
            AddCommand.Parameters.AddWithValue("@Invoice_Material_ID", obj.Invoice_Material_ID);
            AddCommand.Parameters.AddWithValue("@Customer_ID", obj.Customer_ID);
            AddCommand.Parameters.AddWithValue("@Job_Card", obj.Job_Card);
            conn.Open();
            int i = AddCommand.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete Invoice
        public bool DeleteInvoice(String Invoice_ID)
        {
            Connection();
            SqlCommand DeleteCommand = new SqlCommand("DeleteInvoicebyID", conn);
            DeleteCommand.CommandType = CommandType.StoredProcedure;
            DeleteCommand.Parameters.AddWithValue("@Invoice_ID", Invoice_ID);

            conn.Open();
            int i = DeleteCommand.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Get/Return a view of all Job_Types
        public List<Job_TypeModel> GetAllJob_Types()
        {
            Connection();
            List<Job_TypeModel> Job_TypeList = new List<Job_TypeModel>();

            SqlCommand GetCommand = new SqlCommand("View_All_Job_Types", conn);
            GetCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(GetCommand);
            DataTable dt = new DataTable();

            conn.Open();
            da.Fill(dt);
            conn.Close();
            //Bind Job_TypeModel generic list using a data row
            foreach (DataRow dr in dt.Rows)
            {
                Job_TypeList.Add(new Job_TypeModel
                {
                    Job_Type_ID = Convert.ToString(dr["Job_Type_ID"]),
                    Daily_Rate = Convert.ToDouble(dr["Daily_Rate"])
                }
                );
            }
            return Job_TypeList;
        }

        public bool UpdateJob_Type(Job_TypeModel obj)
        {
            Connection();
            SqlCommand UpdateCommand = new SqlCommand("Update_Job_Type", conn);

            UpdateCommand.CommandType = CommandType.StoredProcedure;
            UpdateCommand.Parameters.AddWithValue("@Job_Type_ID", obj.Job_Type_ID);
            UpdateCommand.Parameters.AddWithValue("@Daily_Rate", obj.Daily_Rate);

            conn.Open();
            int i = UpdateCommand.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}