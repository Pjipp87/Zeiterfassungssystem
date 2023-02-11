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
        public static Boolean arbeitsBegin() {

            try
            {
                DBController.con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection= DBController.con;



                return true;
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally { DBController.con.Close(); }
            
        
        
        
        
        }

        public static Boolean arbeitsEnde() { return true; }
    }
}
