using Sample_Project.Interfaces;
using System.Configuration;
using System.Data.SqlClient;

namespace Sample_Project
{
    public class DbConnector : IDbConnector
    {
        public SqlConnection OpenConnection(string connectionStringName = "DefaultConnection")
        {
            string constr = ConfigurationManager.ConnectionStrings[connectionStringName].ToString();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            return con;
        }
    }
}