using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.RacunSO
{
    public class unosRacuna:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Racun r = odo as Racun;
            r.IdRacun = Sesija.Broker.dajSesiju().dajSifru(odo);
            Sesija.Broker.dajSesiju().ubaci(r);
            foreach (StavkaRacuna sr in r.ListaStavki) 
            {
                sr.RacunID = r.IdRacun;
                Sesija.Broker.dajSesiju().ubaci(sr);
            }

            return 1;
        }
    }
}
