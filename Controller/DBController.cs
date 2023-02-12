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
        //public static MySqlConnection con = new MySqlConnection(@"server=localhost;user=root;database=zeiterfassungtest;password=");
        public static MySqlConnection con = new MySqlConnection(@"server=192.168.178.39;user=MasterUser;database=zeiterfassungtest;password=");
    }
}
