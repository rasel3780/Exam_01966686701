using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace RegistrationForm.Models
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Hobby { get; set; }
        public string Password { get; set; }

        public int Register(Employee user)
        {
            string conString = DbConnection.GetConnectionString();
            using (SqlConnection _connection = new SqlConnection(conString))
            {
                _connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = _connection;
                    cmd.CommandText = "dbo.sp_SaveUser";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@FirstName", user.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", user.LastName));
                    cmd.Parameters.Add(new SqlParameter("@MobileNumber", user.MobileNumber));
                    cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
                    cmd.Parameters.Add(new SqlParameter("@Address", user.Address));
                    cmd.Parameters.Add(new SqlParameter("@DateOfBirth", user.DateOfBirth));
                    cmd.Parameters.Add(new SqlParameter("@Gender", user.Gender));
                    cmd.Parameters.Add(new SqlParameter("@Hobby", user.Hobby));
                    cmd.Parameters.Add(new SqlParameter("@Password", user.Password));

                    int res = cmd.ExecuteNonQuery();
                    return res;
                }
            }

        }
    }
}