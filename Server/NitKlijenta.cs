using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Biblioteka;
using Sesija;
using System.Threading;

using SistemskeOperacije.UslugaSO;
using SistemskeOperacije.RacunSO;

namespace Server
{
    public class NitKlijenta
    {
        BinaryFormatter formater;
        NetworkStream tok;

        public NitKlijenta(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();

            ThreadStart ts = obradiKlijenta;
            Thread nit = new Thread(ts);
            nit.Start();
        }

        public void obradiKlijenta() 
        {
            try
            {
                int operacija = 0;
                while (operacija != (int)Operacije.Kraj)
                {
                    TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                    switch (transfer.Operacija)
                    {
                        case Operacije.vratiTipoveUsluga:
                            inicijalizujPodatkeTipUsluge vltu = new inicijalizujPodatkeTipUsluge();
                            transfer.Rezultat = vltu.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.sacuvajUslugu:
                            UnosUsluge uu = new UnosUsluge();
                            transfer.Rezultat = uu.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.PronadjiUsluge:
                            VratiListuUsluga vlu = new VratiListuUsluga();
                            transfer.Rezultat = vlu.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.IzmeniUslugu:
                            IzmenaUsluge iu = new IzmenaUsluge();
                            transfer.Rezultat = iu.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.ObrisiUslugu:
                            ObrisiUslugu ou = new ObrisiUslugu();
                            transfer.Rezultat = ou.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.vratiSveFrizere:
                            vratiListuFrizera vlf = new vratiListuFrizera();
                            transfer.Rezultat = vlf.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.sacuvajRacun:
                            unosRacuna ur = new unosRacuna();
                            transfer.Rezultat = ur.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.ObrisiRacun:
                            obrisiRacun or = new obrisiRacun();
                            transfer.Rezultat = or.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.izmeniRacun:
                            izmenaRacuna ir = new izmenaRacuna();
                            transfer.Rezultat = ir.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.prikaziRacun:
                            vratiListuRacuna vlr = new vratiListuRacuna();
                            transfer.Rezultat = vlr.izvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case Operacije.Kraj:
                            operacija = 1;
                            Server.listaTokovaKlijenata.Remove(tok);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

                Server.listaTokovaKlijenata.Remove(tok);
            }
        }
    }
}
