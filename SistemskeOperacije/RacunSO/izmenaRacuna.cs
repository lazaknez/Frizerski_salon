using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.RacunSO
{
    public class izmenaRacuna:OpstaSO
    {
        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            Racun r = odo as Racun;
            Sesija.Broker.dajSesiju().azuriraj(odo);
            StavkaRacuna sr = new StavkaRacuna();
            sr.RacunID = r.IdRacun;
            Sesija.Broker.dajSesiju().obrisiSveZaUslov(sr);
            foreach (StavkaRacuna stavka in r.ListaStavki) 
            {
                stavka.RacunID = r.IdRacun;
                Sesija.Broker.dajSesiju().ubaci(stavka);
            }

            return 1;
        }
    }
}
