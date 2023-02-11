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
    class ArbeitstagController
    {
        public static Boolean checkForCurrentDateInDB()
        {
            try
            {
                List<String> DateList = new List<String>();
                DBController.con.Open();
                string sqlQuery = "SELECT * FROM arbeitstag";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, DBController.con);
                MySqlDataReader reader = cmd.ExecuteReader(); ;
                while (reader.Read())
                {
                    DateList.Add(reader.GetDateTime(1).ToString().Split(" ")[0]);
                }
                if (!DateList.Contains(DateTime.Now.ToString().Split(" ")[0]))
                {
                    reader.Close();
                    setNewDateInDB();
                }
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally { DBController.con.Close(); }


        }


        private static Boolean setNewDateInDB()
        {
            try
            {
                
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = DBController.con;
                cmd.CommandText = $"INSERT INTO arbeitstag(Datum) Values(now())";
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            



        }
    }
}
