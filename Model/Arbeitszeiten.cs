using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungssystem.Model
{
    internal class Arbeitszeiten
    {
        private String anfang;
        private String ende;
        private String stunden;
        public static List<Arbeitszeiten> arbeitszeitenList = new List<Arbeitszeiten>();

        public Arbeitszeiten(String anfang, String ende, String stunden)
        {
            this.anfang= anfang;
            this.ende= ende;
            this.stunden= stunden;

            arbeitszeitenList.Add(this);
        }

        public String Anfang
        {
            get { return anfang; }
        }

        public String Ende
        {
            get { return ende; }
        }

        public String Stunden
        {
            get { return stunden; }
        }
    }
}
