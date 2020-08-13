using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUserManager.Helper
{
    class DatabaseHelper
    {
        private static  string getConnectionString(string nameDatabase)
        {
            return "";
        }
        public static Dictionary<string, string>  getListLocalServer()
        {
            List<string> nameDbs = new List<string>();
            string connectionString = "Data Source=.; Integrated Security=True;";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nameDbs.Add(dr[0].ToString());
                        }
                    }
                }
            }
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            int i = 0;
            foreach (var item in nameDbs)
            {
                comboSource.Add(i + "", item.ToString());
                i++;
            }
            return comboSource;

        }

    }
}
