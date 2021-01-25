using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using Biblioteka;

namespace KontrolerAplikacioneLogike
{
    public class KontrolerAL
    {
        TcpClient klijent;
        BinaryFormatter formater;
        NetworkStream tok;

        public bool poveziSeNaServer()
        {
            try
            {
                klijent = new TcpClient("127.0.0.1", 20000);
                tok = klijent.GetStream();
                formater = new BinaryFormatter();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }



        public List<TipUsluge> vratiTipoveUsluga(TipUsluge tipUsluge)
        {
            // slanje
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiTipoveUsluga;
            transfer.TransferObjekat = tipUsluge;
            formater.Serialize(tok, transfer);

            // prijem
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (transfer.Rezultat as List<OpstiDomenskiObjekat>).OfType<TipUsluge>().ToList<TipUsluge>();
        }

        public object sacuvajUslugu(Usluga u)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajUslugu;
            transfer.TransferObjekat = u;
            formater.Serialize(tok, transfer);

           
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public List<Usluga> vratiUsluge(Usluga u)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.PronadjiUsluge;
            transfer.TransferObjekat = u;
            formater.Serialize(tok, transfer);


            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as List<Usluga>;
        }

        public object izmeniUslugu(Usluga usluga)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.IzmeniUslugu;
            transfer.TransferObjekat = usluga;
            formater.Serialize(tok, transfer);


            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object obrisiUslugu(Usluga usluga)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.ObrisiUslugu;
            transfer.TransferObjekat = usluga;
            formater.Serialize(tok, transfer);


            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object obrisiRacun(Racun r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.ObrisiRacun;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);
            
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object izmeniRacun(Racun r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.izmeniRacun;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public object unesiRacun(Racun r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.sacuvajRacun;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat;
        }

        public List<Racun> pretraziRacune(Racun r)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.prikaziRacun;
            transfer.TransferObjekat = r;
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as List<Racun>;
        }

        public List<Frizer> vratiSveFrizere()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = Operacije.vratiSveFrizere;
            transfer.TransferObjekat = new Frizer();
            formater.Serialize(tok, transfer);

            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (transfer.Rezultat as List<OpstiDomenskiObjekat>).OfType<Frizer>().ToList<Frizer>();
        }
    }
}
