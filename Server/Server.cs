using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Server
{
    public class Server
    {
        Socket soket;
        public static List<NetworkStream> listaTokovaKlijenata = new List<NetworkStream>();
        public bool pokreniServer()
        {
            try
            {
                soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                EndPoint ep = new IPEndPoint(IPAddress.Any, 20000);
                soket.Bind(ep);


                ThreadStart ts = osluskuj;
                Thread nit = new Thread(ts);
                nit.Start();


                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public void osluskuj()
        {
            try
            {
                soket.Listen(6);
                while (true)
                {
                    Socket klijent = soket.Accept();
                    NetworkStream tok = new NetworkStream(klijent);

                    listaTokovaKlijenata.Add(tok);
                    new NitKlijenta(tok);
                }
            }
            catch (Exception)
            {


            }
        }

        public bool zaustaviServer()
        {
            try
            {
                soket.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
