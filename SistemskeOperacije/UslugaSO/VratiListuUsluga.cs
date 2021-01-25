using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.UslugaSO
{
    public class VratiListuUsluga:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Usluga u = odo as Usluga;
            List<Usluga> lista= Sesija.Broker.dajSesiju().dajSveZaUslovDva(odo).OfType<Usluga>().ToList<Usluga>();
            foreach (Usluga us in lista) 
            {
                us.TipUsluge = u.TipUsluge;
            }
            return lista;
        }
    }
}
