using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AutoBusiness
    {
        public AutoRepository ar;
        public AutoBusiness()
        {

            this.ar = new AutoRepository();

        }
        public List<Automobil> GetAutomobilis()
        {
            return this.ar.GetAutomobilis();
        }
        public bool insertAuto(Automobil a)
        {
            int result = this.ar.insertAuto(a);
            if (result != 0)
            
                return true;
                return false;
            
        }

        public List<Automobil> jeftinijeOd(decimal min)
        {

            return this.ar.GetAutomobilis().Where(Automobil => Automobil.cena < min).ToList();

        }
        public bool deleteAuto(string automobilMarka)
        {
            int result = this.ar.deleteAuto(automobilMarka);
            if (result != 0)

                return true;
            return false;

        }
        public List<Automobil> MarkaAuta(string Marka)
        {

            return this.ar.GetAutomobilis().Where(Automobil => Automobil.marka == Marka).ToList();

        }
        public List<Automobil> najvecaCena(decimal cena)
        {

            return this.ar.GetAutomobilis().Where(Automobil => Automobil.cena > cena).ToList();

        }
        public bool UpdateAuto(Automobil a)
        {
            int result = this.ar.UpdateAuto(a);
            if (result != 0)
                return true;
            else
                return false;

        }
    }
    }
