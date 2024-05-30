using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ECommerce
{
    internal class DatabaseOperations
    {
        public MySqlConnection Connect()
        {
            MySqlConnection mysql = new MySqlConnection(ConfigurationManager.ConnectionStrings["ecommerceConnection"].ConnectionString);
            MySqlConnection.ClearPool(mysql);
            return mysql;
        }
    }
}
