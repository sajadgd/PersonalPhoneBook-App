using FirstApp.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Services
{
    class ContactRepository : IContactRepository
    {
        private string _myConnection = "Data Source=DESKTOP-ALNK7H1\\SQL2019;Initial Catalog=Contact_DB; User ID= sa ;Password=1";

        public bool Delete(int contactid)
        {
            SqlConnection connection = new SqlConnection(_myConnection);
            try
            {
                string query = "Delete From MyContacts Where ContactId = @ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactid);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch 
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Insert(string name, string family, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(_myConnection);
            try
            {
                string query = "Insert Into MyContacts(Name,Family,Mobile,Email,Age,Address) values(@Name,@Family,@Mobile,@Email,@Age,@Address)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string parameter)
        {
            string query = "Select * From MyContacts WHERE Name LIKE @parameter OR Family LIKE @parameter";
            SqlConnection connection = new SqlConnection(_myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter","%" + parameter + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From MyContacts";
            SqlConnection connection = new SqlConnection(_myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int contactId)
        {
            string query = "Select * From MyContacts Where ContactId =" + contactId;
            SqlConnection connection = new SqlConnection(_myConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int contactid, string name, string family, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(_myConnection);
            try
            {
                string query = "Update MyContacts Set Name=@Name,Family=@Family,Mobile=@Mobile,Email=@Email,Age=@Age,Address=@Address Where ContactId=@ID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactid);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
