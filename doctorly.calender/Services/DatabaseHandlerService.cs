using System.Data;
using System.Data.SqlClient;

namespace doctorly.calender.Services
{
    public class DatabaseHandlerService : IDatabaseHandler
    {
        public IDbConnection GetDbConnection()
        {
            return new SqlConnection("Data Source=156.38.224.15;Initial Catalog=ntengaco_doctorly;User ID=ntengaco_doctorly_user;Password=88ki!18aW");
        }
    }
}
