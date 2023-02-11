using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungssystem
{
    class DBController
    {
        public static MySqlConnection con = new MySqlConnection(@"server=localhost;user=root;database=zeiterfassungtest;password=");
    }
}
