using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Zeiterfassungssystem.Controller
{
    class ArbeitszeitController
    {
        public static Boolean arbeitsBegin(int mitarbeiternummer) {

            try
            {
                DBController.con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection= DBController.con;

                cmd.CommandText = "arbeitsbegin";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ma", mitarbeiternummer.ToString());
                cmd.Parameters["@ma"].Direction = System.Data.ParameterDirection.Input;
                cmd.ExecuteNonQuery();

                return true;
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally { DBController.con.Close(); }
            
        
        
        
        
        }

        public static Boolean arbeitsEnde(int mitarbeiternummer) {
            try
            {
                DBController.con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = DBController.con;
                cmd.CommandText = "arbeitsende";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ma", mitarbeiternummer.ToString());
                cmd.Parameters["@ma"].Direction = System.Data.ParameterDirection.Input;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally { DBController.con.Close(); }
        }


        public static List<String> getArbeitstagBenutzer(int mitarbeiternummer, String datum)
        {

            List<String> liste = new List<string>(); 
            try
            {
                DBController.con.Open();
                string sqlQuery = $"SELECT arbeitstag.Datum, arbeitszeit.arbeitsbegin,arbeitszeit.arbeitsende , TIMEDIFF(arbeitszeit.arbeitsende, arbeitszeit.arbeitsbegin) as 'Stunden' FROM arbeitstag JOIN arbeitszeit ON arbeitstag.id = arbeitszeit.arbeitstag_id WHERE arbeitszeit.benutzer_id = '{mitarbeiternummer}' AND arbeitstag.Datum = '{datum}';";
                MySqlCommand cmd = new MySqlCommand(sqlQuery, DBController.con);
                MySqlDataReader reader = cmd.ExecuteReader();
               
                while (reader.Read()) {
                    liste.Add(reader.GetString(1).Split(":")[0]+":"+reader.GetString(1).Split(":")[1] + "\t"+ reader.GetString(2).Split(":")[0] + ":" + reader.GetString(2).Split(":")[1]+ "\tStunden: "+ reader.GetString(3).Split(":")[0] + ":" + reader.GetString(3).Split(":")[1]);                    
                }
                return liste;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return liste;
            }
            finally { DBController.con.Close(); }
        }
    }
}
