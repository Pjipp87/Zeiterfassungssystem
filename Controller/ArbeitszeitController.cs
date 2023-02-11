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

            List<String> liste = new List<String>();
            try
            {
                DBController.con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = DBController.con;
                cmd.CommandText = "arbeitstagBenutzer";
                // PARAMETER EINFÜGEN
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", mitarbeiternummer.ToString());
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                cmd.Parameters.AddWithValue("@datum", datum);
                cmd.Parameters["@id"].Direction = System.Data.ParameterDirection.Input;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    liste.Add(reader.GetDateTime(0).ToString() + ": " + reader.GetDateTime(1).ToString() + " - " + reader.GetDateTime(1).ToString());
                    MessageBox.Show(reader.GetDateTime(0).ToString() + ": " + reader.GetDateTime(1).ToString() + " - " + reader.GetDateTime(1).ToString());
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
