using System.Data.SqlClient;

namespace Sample_Project.Interfaces
{
    public interface IDbConnector
    {
        SqlConnection OpenConnection(string connectionStringName);
    }
}