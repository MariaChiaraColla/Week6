using EsameWeek6Polizia.Classi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EsameWeek6Polizia.ConnectionDatabase
{
    public class DisconnectionDB
    {
        //stringa per la connessione al db, db: POLIZIA
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog = POLIZIA; Server = .\SQLEXPRESS";

        //Dare la possibilità all’utente di inserire un nuovo record di agente. (Modalità disconnessa)
        public static void InserisciAgente()
        {
            //utilizzo la modalità disconnessa
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //creo l'adapter
                SqlDataAdapter adapter = new SqlDataAdapter();

                //creo il comando select
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = connection;
                selectCommand.CommandType = System.Data.CommandType.Text;
                selectCommand.CommandText = "SELECT * FROM Agente_Di_Polizia";

                //creo il comando insert
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText = "INSERT INTO Agente_Di_Polizia VALUES(@Nome,@Cognome,@CodiceFiscale,@DataDiNascita,@AnniDiServizio)";

                //parametri
                insertCommand.Parameters.Add("@Nome", System.Data.SqlDbType.NVarChar, 255, "Nome");
                insertCommand.Parameters.Add("@Cognome", System.Data.SqlDbType.NVarChar, 255, "Cognome");
                insertCommand.Parameters.Add("@CodiceFiscale", System.Data.SqlDbType.NVarChar, 16, "CodiceFiscale");
                insertCommand.Parameters.Add("@DataDiNascita", System.Data.SqlDbType.DateTime, 255, "DataDiNascita");
                insertCommand.Parameters.Add("@AnniDiServizio", System.Data.SqlDbType.Int, 255, "AnniDiServizio");

                //associazione dei comandi con l'adapter
                adapter.SelectCommand = selectCommand;
                adapter.InsertCommand = insertCommand;

                //creo il data set
                DataSet dataSet = new DataSet();

                //eseguo i comandi
                try
                {
                    //apro la connessione
                    connection.Open();

                    //riempio il data set
                    adapter.Fill(dataSet, "Agente_Di_Polizia");

                    //leggo la tabella
                    //foreach (DataRow row in dataSet.Tables["Agente_Di_Polizia"].Rows) //legge le singole righe della tab
                    //{
                    //    Console.WriteLine(row["Nome"]);
                    //}

                    //creo una nuova riga: data row
                    DataRow agente = dataSet.Tables["Agente_Di_Polizia"].NewRow(); //riga vuota

                    //chiedo all'utente i parametri
                    Console.WriteLine("Inserisci un nuovo Agente: ");
                    Console.WriteLine(" -Nome: ");
                    string nome = Console.ReadLine();

                    Console.WriteLine(" -Cognome: ");
                    string cognome = Console.ReadLine();

                    Console.WriteLine(" -Codice Fiscale: ");
                    string codiceF = Console.ReadLine();

                    Console.WriteLine(" -Data di nascita: ");
                    string dataN = Console.ReadLine();

                    Console.WriteLine(" -Anni di servizio: ");
                    string anniS = Console.ReadLine();

                    //popolo la nuova riga
                    agente["Nome"] = nome; 
                    agente["Cognome"] = cognome;
                    agente["CodiceFiscale"] = codiceF;
                    agente["DataDiNascita"] = dataN;
                    agente["AnniDiServizio"] = anniS;

                    // modifico il data set in locale
                    dataSet.Tables["Agente_Di_Polizia"].Rows.Add(agente); 

                    //aggiorno il db vero e proprio
                    adapter.Update(dataSet, "Agente_Di_Polizia");

                    Console.WriteLine("Agente aggiunto con successo!");

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    //chiudo la connessione
                    connection.Close();
                }
            }
        }




    }
}
