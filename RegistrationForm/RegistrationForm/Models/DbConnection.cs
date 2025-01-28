using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RegistrationForm.Models
{
    public class DbConnection
    {
        protected readonly SqlConnection _connection;

        public static string GetConnectionString()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            return conString;
        }
    }
}