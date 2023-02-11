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


        public static Boolean getArbeitstagBenutzer(int mitarbeiternummer, DateTime datum)
        {
            try
            {
                DBController.con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = DBController.con;
                cmd.CommandText = "arbeitstagBenutzer";
                // PARAMETER EINFÜGEN
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
    }
}
