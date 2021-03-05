using EsameWeek6Polizia.Classi;
using EsameWeek6Polizia.ConnectionDatabase;
using System;

namespace EsameWeek6Polizia
{
    class Program
    {
        static void Main(string[] args)
        {
            //TEST

            ////test ToString() ok
            //Agente a = new Agente("Giorgia", "Rari", "RRAGRG12E34T567M", 10);
            //Console.WriteLine(a.ToString());
            ////test Equals() ok
            //Agente b = new Agente("Giorgia", "Rari", "RRAGRG12E34T567M", 10);
            //bool uguali = a.Equals(b);
            //Console.WriteLine(uguali);
            ////test Mostra tutti gli agenti ok
            //ConnectionDB.MostraTuttiGliAgenti();
            ////test Agenti per area ok
            //Console.WriteLine("------Agenti Per Area ---------");
            //ConnectionDB.AgentiPerArea();
            ////test inserisci agente OK
            //Console.WriteLine("------insersci Agente ---------");
            //DisconnectionDB.InserisciAgente();


            //Menu per la gestione
            char key = 'i';

            while(key!= 'q')
            {
                Console.WriteLine("");
                Console.WriteLine("------BENEVENUTO NEL MENU' DI GESTIONE AGENTE DI POLIZIA!---------");
                Console.WriteLine("Elenco di Azioni possibili, premi la lettera corrispondente all'azione desiderata:");
                Console.WriteLine(" a) Stampa l'elenco completo degli Agenti di Polizia,");
                Console.WriteLine(" b) Stampa l'elenco degli Agenti presenti in una determinata area,");
                Console.WriteLine(" c) Inserisci un nuovo Agente di Polizia,");
                Console.WriteLine(" q) Premi 'q' per uscire.");
                Console.WriteLine("");

                key = Convert.ToChar(Console.ReadLine());

                switch (key)
                {
                    case 'a':
                        ConnectionDB.MostraTuttiGliAgenti();
                        break;
                    case 'b':
                        Console.WriteLine("Codici aree:");
                        Console.WriteLine("");
                        ConnectionDB.MostraTuttiICodiceArea();
                        ConnectionDB.AgentiPerArea();
                        break;
                    case 'c':
                        DisconnectionDB.InserisciAgente();
                        break;
                    case 'q':
                        break;
                }

            }
            



        }
    }
}
