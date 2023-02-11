using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zeiterfassungssystem.Model;

namespace Zeiterfassungssystem.Controller
{
    class UserController
    {
        public static Boolean getAllUsers()
        {
            try
            {
                DBController.con.Open();
                string sqlQuery = "SELECT * FROM benutzer";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, DBController.con);
                MySqlDataReader reader= cmd.ExecuteReader(); ;

                while (reader.Read())
                {
                    new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3), false, reader.GetBoolean(4), reader.GetString(5));
                }
                Console.WriteLine(User.userList.Count);
                return true;

            } catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally { DBController.con.Close(); }   


        }
    }
}
