using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTB
{
    public static class DatabaseConfig
    {
        public static string ConnectionString { get;  set; }
        public static void SetConnection(string userId, string password)
        {
            ConnectionString = $"Data Source=.;Initial Catalog=QLGYM;User ID={userId};Password={password};TrustServerCertificate=True";
        }
    }
}
