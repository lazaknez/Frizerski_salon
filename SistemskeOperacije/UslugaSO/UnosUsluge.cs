using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.UslugaSO
{
    public class UnosUsluge:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Usluga u = odo as Usluga;
            u.IdUsluga = Sesija.Broker.dajSesiju().dajSifru(odo);
            return Sesija.Broker.dajSesiju().ubaci(u);
        }
    }
}
