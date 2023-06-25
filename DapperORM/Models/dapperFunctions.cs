using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;

namespace DapperORM.Models
{
    public static class dapperFunctions
    {
        public static string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Dapper;Integrated Security=true;";

        public static void StoreProcedureNoReply(string storeprocname, DynamicParameters param)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                con.Execute(storeprocname, param, commandType: CommandType.StoredProcedure);
            }
        }

        public static T StoreProcedureWithReply<T>(string storeprocname, DynamicParameters param)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                return (T)Convert.ChangeType(con.ExecuteScalar(storeprocname, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        public static IEnumerable<T> StoreProcedureList<T>(string storeprocname, DynamicParameters param)
        {
    
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                
                return con.Query<T>(storeprocname, param, commandType: CommandType.StoredProcedure);
            }
        }


        public static void noreturn(string storeproc, DynamicParameters param)
        {
            string conString = "Server=(localdb)\\MSSQLLocalDB; Database=Dapper; Integrated Security=true";
            using (SqlConnection con =new SqlConnection(conString))
            {
                con.Open() ;
                con.Execute(storeproc, param, commandType: CommandType.StoredProcedure);
            }
        }
        public static T returnScalar<T>(string storeproc, DynamicParameters param)
        {
            string conString = "Server=(localdb)\\MSSQLLocalDB ; Database=Dapper; Integrated Security=true;";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                return (T)Convert.ChangeType(con.ExecuteScalar(storeproc, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }
        public static IEnumerable<T> Returnlistofarray<T>(string storeproc, DynamicParameters param)
        {
            string conString = "Server=(localdb)\\MSSQLLocalDB ; Database=Dapper; Integrated Security: true";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                return con.Query<T>(storeproc, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}