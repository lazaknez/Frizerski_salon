using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace Biblioteka
{
    [Serializable]
    public class Usluga:OpstiDomenskiObjekat
    {
        int idUsluga;      
        string naziv;       
        string opis;
        double cenaPoMinutu;    
        TipUsluge tipUsluge;

        public int IdUsluga { get => idUsluga; set => idUsluga = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Opis { get => opis; set => opis = value; }
        public double CenaPoMinutu { get => cenaPoMinutu; set => cenaPoMinutu = value; }
        public TipUsluge TipUsluge { get => tipUsluge; set => tipUsluge = value; }


        public override string ToString()
        {
            return Naziv;
        }

        #region ODO
        [Browsable(false)]
        public string tabela
        {
            get { return "Usluga"; }
        }
        [Browsable(false)]
        public string kljuc
        {
            get { return "IDUsluga"; }
        }
        [Browsable(false)]
        public string uslovJedan
        {
            get { return "IDUsluga=" + IdUsluga; }
        }
        [Browsable(false)]
        public string uslovDva
        {
            get { return "IDTipUsluge="+TipUsluge.IdTipaUsluge; }
        }
        [Browsable(false)]
        public string uslovTri
        {
            get { return null; }
        }
        [Browsable(false)]
        public string azuriranje
        {
            get { return "CenaPoMinutu="+CenaPoMinutu; }
        }
        [Browsable(false)]
        public string upisivanje
        {
            get { return "values ("+ IdUsluga + ",'" + Naziv + "','" + Opis + "'," + CenaPoMinutu + "," + TipUsluge.IdTipaUsluge+")"; }
        }

      
        public OpstiDomenskiObjekat napuni(DataRow red)
        {

            Usluga u = new Usluga();

            
            u.IdUsluga = Convert.ToInt32(red[0]);
            u.Naziv = red[1].ToString();
            u.Opis = red[2].ToString();
            u.CenaPoMinutu = Convert.ToDouble(red[3]);
            u.TipUsluge = new TipUsluge();
            u.TipUsluge.IdTipaUsluge = Convert.ToInt32(red[4]);

            return u;
        }
        #endregion

    }
}
