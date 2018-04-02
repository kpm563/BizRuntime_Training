using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Name required!")]
        [RegularExpression(@"^[A-Z a-z 0-9]{6,15}$", ErrorMessage = "Enter valid UserName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email required!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9._-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,3}$", ErrorMessage = "Enter a valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required!")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*\d)(?=.*[@ $ # & * ]{2})(?=.*[A-Z])(?=.*[a-z]).{8,12}$", ErrorMessage =
            "Enter a valid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mobile required!")]
        [RegularExpression(@"^[6-9][0-9]{9}$", ErrorMessage = "Enter a valid Phone")]
        public string Mobile { get; set; }

        [RegularExpression(@"^[A-Z a-z]{1,50}$", ErrorMessage = "Enter a valid Address")]
        public string Address { get; set; }
    }

    public class Login
    {
        [Required(ErrorMessage = "Enter your username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { set; get; }

        public string Message { set; get; }
    }

    public class ValidateData
    {
        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=BizRuntime;Persist Security Info=True;User ID=sa;Password=prince";

        public void AddUser(Registration user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string str = "insert into UserRecord (UserName,Email,Password,Phone,Address) values('" + user.Name + "','" + user.Email + "','" + user.Password + "','" + user.Mobile + "','" + user.Address + "')";
                SqlCommand cmd = new SqlCommand(str, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public bool LoginUser(Login user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from UserRecord where UserName='" + user.UserName + "' and Password='" + user.Password + "'", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (rdr["UserName"].ToString().Equals(user.UserName) && rdr["password"].ToString().Equals(user.Password))
                        return true;
                }
            }
            return false;
        }
    }
}
