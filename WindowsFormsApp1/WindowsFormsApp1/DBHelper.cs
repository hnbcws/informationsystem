using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DBHelper
    {
        private static string str = "server=.;database=information;user=sa;pwd=123";
        private static SqlConnection con;
        public static bool DBreader(string sql, params SqlParameter[] parameters)
        {

            dbconnect();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            
            cmd.Parameters.AddRange(parameters);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                dr.Close();
                return true;

            }
            else
            {
                return false;
            }

        }


        public static bool DBquery(string sql, params SqlParameter[] parameters) {

            //con.Open();
            dbconnect();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
           
            cmd.Parameters.AddRange(parameters);
            int count = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            if (count > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                return false;
            }
         


        }
 


        public static void dbconnect() {
            con= new SqlConnection(str);
            con.Open();
           


        }


      
    }
}
