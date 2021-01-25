using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Biblioteka;

namespace SistemskeOperacije.RacunSO
{
    public class vratiListuRacuna:OpstaSO
    {

        public override object Izvrsi(Biblioteka.OpstiDomenskiObjekat odo)
        {
            List<Racun> listaRacuna = Sesija.Broker.dajSesiju().dajSveZaUslovDva(odo).OfType<Racun>().ToList<Racun>();
            foreach (Racun r in listaRacuna) 
            {
                r.Frizer = Sesija.Broker.dajSesiju().dajZaUslovJedan(r.Frizer) as Frizer;
                StavkaRacuna sr = new StavkaRacuna();
                sr.RacunID = r.IdRacun;
                List<StavkaRacuna> listaStavki = Sesija.Broker.dajSesiju().dajSveZaUslovDva(sr).OfType<StavkaRacuna>().ToList<StavkaRacuna>();
                foreach (StavkaRacuna stavka in listaStavki) 
                {
                    stavka.Usluga = Sesija.Broker.dajSesiju().dajZaUslovJedan(stavka.Usluga) as Usluga;
                    r.ListaStavki.Add(stavka);
                }
            }

            return listaRacuna;
        }
    }
}
