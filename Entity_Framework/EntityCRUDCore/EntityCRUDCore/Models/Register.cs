using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCRUDCore.Models
{
    public class Register
    {
        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=BizRuntime;Persist Security Info=True;User ID=sa;Password=prince";

        public void AddUser(Registration user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string ConString = "INSERT INTO tblRegistration (Name, Email, Age, Mobile, City) VALUES('" + user.Name + "','" + user.Email + "','" + user.Age + "','" + user.Mobile + "','" + user.City + "')";
                SqlCommand command = new SqlCommand(ConString, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
