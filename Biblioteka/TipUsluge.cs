using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Biblioteka
{
    [Serializable]
    public class TipUsluge:OpstiDomenskiObjekat
    {
        int idTipaUsluge;        
        string naziv;

        public int IdTipaUsluge { get => idTipaUsluge; set => idTipaUsluge = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public override string ToString()
        {
            return Naziv;
        }

        #region ODO
        public string tabela
        {
            get { return "TipUsluge"; }
        }

        public string kljuc
        {
            get { return "IDTipUsluge"; }
        }

        public string uslovJedan
        {
            get { return "IDTipUsluge="+IdTipaUsluge; }
        }

        public string uslovDva
        {
            get { return null; }
        }

        public string uslovTri
        {
            get { return null; }
        }

        public string azuriranje
        {
            get { return null; }
        }

        public string upisivanje
        {
            get { return null; }
        }

       

        public OpstiDomenskiObjekat napuni(DataRow red)
        {
            TipUsluge tu = new TipUsluge();
            tu.IdTipaUsluge = Convert.ToInt32(red[0]);
            tu.Naziv = red[1].ToString();

            return tu;
        } 
        #endregion
    }
}
