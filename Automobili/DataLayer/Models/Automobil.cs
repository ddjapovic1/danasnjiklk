using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
   public class Automobil
    {
        public Automobil(int id, string marka, int godinaProizvodnje, decimal cena, int zapreminaMotora)
        {
            this.id = id;
            this.marka = marka;
            this.godinaProizvodnje = godinaProizvodnje;
            this.cena = cena;
            this.zapreminaMotora = zapreminaMotora;
        }

        public int id { get; set; }
       public string marka { get; set; }
        public int godinaProizvodnje { get; set; }
        public decimal cena { get; set; }
        public int zapreminaMotora { get; set; }

        public override string ToString()
        {
            return $"{id}-{marka}-{godinaProizvodnje}-{cena}-{zapreminaMotora}.";
        }


    }
}
