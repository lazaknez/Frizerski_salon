using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Biblioteka
{
    [Serializable]
    public class Frizer : OpstiDomenskiObjekat
    {
        public override string ToString()
        {
            return ImePrezime;
        }

        int idFrizer;      
        string imePrezime;

        public int IdFrizer { get => idFrizer; set => idFrizer = value; }
        public string ImePrezime { get => imePrezime; set => imePrezime = value; }

        #region ODO
        [Browsable(false)]
        public string tabela
        {
            get { return "Frizer"; }
        }
        [Browsable(false)]
        public string kljuc
        {
            get { return null; }
        }
        [Browsable(false)]
        public string uslovJedan
        {
            get { return "IDFrizera="+IdFrizer; }
        }
        [Browsable(false)]
        public string uslovDva
        {
            get { return null; }
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
            get { return null; }
        }

      

        public OpstiDomenskiObjekat napuni(System.Data.DataRow red)
        {
            Frizer f = new Frizer();
            f.IdFrizer = Convert.ToInt32(red[0]);
            f.ImePrezime = red[1].ToString();
            return f;
        } 
        #endregion
    }
}
