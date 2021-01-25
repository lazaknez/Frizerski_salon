using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Biblioteka
{
    [Serializable]
    public class Racun : OpstiDomenskiObjekat
    {
        int idRacun;       
        DateTime datumKreiranja;
        Double iznos;
        Frizer frizer;       
        BindingList<StavkaRacuna> listaStavki;

        [DisplayName("RacunID")]
        public int IdRacun { get => idRacun; set => idRacun = value; }
        public DateTime DatumKreiranja { get => datumKreiranja; set => datumKreiranja = value; }
        public double Iznos { get => iznos; set => iznos = value; }
        [Browsable(false)]
        public Frizer Frizer { get => frizer; set => frizer = value; }
        public BindingList<StavkaRacuna> ListaStavki { get => listaStavki; set => listaStavki = value; }


        public Racun()
        {
            ListaStavki = new BindingList<StavkaRacuna>();
        }

        #region ODO
        [Browsable(false)]
        public string tabela
        {
            get { return "Racun"; }
        }
        [Browsable(false)]
        public string kljuc
        {
            get { return "IDRacuna"; }
        }
        [Browsable(false)]
        public string uslovJedan
        {
            get { return "IDRacuna="+IdRacun; }
        }
        [Browsable(false)]
        public string uslovDva
        {
            get { return "IDFrizera="+Frizer.IdFrizer; }
        }
        [Browsable(false)]
        public string uslovTri
        {
            get { return null; }
        }
        [Browsable(false)]
        public string azuriranje
        {
            get { return "DatumFormiranja='"+ DatumKreiranja.ToString("yyyy-MM-dd")+"', Iznos="+ Iznos + ", IDFrizera=" + frizer.IdFrizer+""; }
        }
        [Browsable(false)]
        public string upisivanje
        {
            get { return " values ("+IdRacun+",'"+DatumKreiranja.ToString("yyyy-MM-dd")+"',"+Iznos+","+Frizer.IdFrizer+")"; }
        }

      

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Racun r = new Racun();
            r.IdRacun = Convert.ToInt32(red[0]);
            r.DatumKreiranja = Convert.ToDateTime(red[1]);
            r.Iznos = Convert.ToDouble(red[2]);
            r.Frizer = new Frizer();
            r.Frizer.IdFrizer = Convert.ToInt32(red[3]);
            return r;
        } 
        #endregion
    }
}
