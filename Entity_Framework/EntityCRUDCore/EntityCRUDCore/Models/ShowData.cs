using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCRUDCore.Models
{
    public class ShowData
    {
        public void ShowUserData()
        {
            string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=BizRuntime;Persist Security Info=True;User ID=sa;Password=prince";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select * from tblRegistration", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            }
        }
    }
}
