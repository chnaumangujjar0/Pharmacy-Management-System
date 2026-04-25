// DBHelper.cs — Add this file to your project
using System;
using Microsoft.Data.SqlClient;

namespace PharmacyMS
{
    public static class DBHelper
    {
        public static string ConnectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=PharmacyDB;Integrated Security=True;Trust Server Certificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}