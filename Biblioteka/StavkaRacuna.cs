using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Biblioteka
{
    [Serializable]
    public class StavkaRacuna : OpstiDomenskiObjekat
    {
        int racunID;       
        int rb;       
        int brojMinuta;       
        double cena;       
        Usluga usluga;

        [Browsable(false)]
        public int RacunID { get => racunID; set => racunID = value; }
        public int Rb { get => rb; set => rb = value; }
        public int BrojMinuta { get => brojMinuta; set => brojMinuta = value; }
        public double Cena { get => cena; set => cena = value; }
        public Usluga Usluga { get => usluga; set => usluga = value; }

        #region ODO
        [Browsable(false)]
        public string tabela
        {
            get { return "StavkaRacuna"; }
        }
        [Browsable(false)]
        public string kljuc
        {
            get { return null; }
        }
        [Browsable(false)]
        public string uslovJedan
        {
            get { return null; }
        }
        [Browsable(false)]
        public string uslovDva
        {
            get { return "IDRacuna="+RacunID; }
        }
        [Browsable(false)]
        public string uslovTri
        {
            get { return null; }
        }
        [Browsable(false)]
        public string azuriranje
        {
            get { return null; }
        }
        [Browsable(false)]
        public string upisivanje
        {
            get { return "values ("+ RacunID + "," + Rb + "," + BrojMinuta + "," + Cena + "," + Usluga.IdUsluga+")"; }
        }

      

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            StavkaRacuna sr = new StavkaRacuna();
            sr.RacunID = Convert.ToInt32(red[0]);
            sr.Rb = Convert.ToInt32(red[1]);
            sr.BrojMinuta = Convert.ToInt32(red[2]);
            sr.Cena = Convert.ToDouble(red[3]);
            sr.Usluga = new Usluga();
            sr.Usluga.IdUsluga = Convert.ToInt32(red[4]);

            return sr;

        } 
        #endregion
    }
}
