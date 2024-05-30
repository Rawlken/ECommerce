using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ECommerce
{
    internal static class LoginInfo
    {
        public static string nickname;
        public static string email;
        public static int id;
        public static bool isSupplier = false;
    }
}
