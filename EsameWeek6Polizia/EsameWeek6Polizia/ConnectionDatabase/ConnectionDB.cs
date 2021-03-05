using EsameWeek6Polizia.Classi;
using EsameWeek6Polizia.Extension;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EsameWeek6Polizia.ConnectionDatabase
{
    public class ConnectionDB
    {
        //stringa per la connessione al db, db: POLIZIA
        const string connectionString= @"Persist Security Info = False; Integrated Security = true; Initial Catalog = POLIZIA; Server = .\SQLEXPRESS";

        //mostrare tutti gli agenti
        public static void MostraTuttiGliAgenti()
        {
            //utilizzo la modilità connessa per stampare la tabella Agente_Di_Polizia nel db POLIZIA
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando per selezionare tutti gli agenti
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = connection;
                selectCommand.CommandType = System.Data.CommandType.Text;
                selectCommand.CommandText = "SELECT * FROM Agente_Di_Polizia";

                //eseguo il comando
                SqlDataReader reader = selectCommand.ExecuteReader();

                //stampo a schermo gli agenti
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetAgente().ToString());
                }

                //chiudo la connessione e il reader
                reader.Close();
                connection.Close();
            }
        }

        //Mostrare gli agenti assegnati ad una determinata area data da input dell’utente
        public static void AgentiPerArea()
        {
            //utilizzo la modalità connessa
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT A.Nome,A.Cognome,A.CodiceFiscale,A.DataDiNascita,A.AnniDiServizio FROM (SELECT * FROM Agente_Di_Polizia INNER JOIN Servizio ON ID = AgenteID) AS A INNER JOIN Area_Metropolitana ON AreaID = Area_Metropolitana.ID WHERE CodiceArea = @AREA;";

                //parametri
                Console.WriteLine("Scrivi il Codice Area per cui vuoi filtrare gli Agenti di Polizia");
                string area = Console.ReadLine();
                command.Parameters.AddWithValue("@AREA", area);

                //eseguo il comando
                SqlDataReader reader = command.ExecuteReader();

                //stampo a schermo gli agenti
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetAgente().ToString());
                }

                //chiudo la connessione e il reader
                reader.Close();
                connection.Close();
            }
        }

        //ho creato questa funzione per mostrare il nome di tutti i codici area per cui si posso filtrare gli agenti
        public static void MostraTuttiICodiceArea()
        {
            //utilizzo la modilità connessa per stampare la tabella Agente_Di_Polizia nel db POLIZIA
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //apro la connessione
                connection.Open();

                //creo il comando per selezionare tutti gli agenti
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = connection;
                selectCommand.CommandType = System.Data.CommandType.Text;
                selectCommand.CommandText = "SELECT CodiceArea FROM Area_Metropolitana";

                //eseguo il comando
                SqlDataReader reader = selectCommand.ExecuteReader();

                //stampo a schermo gli agenti
                while (reader.Read())
                {
                    Console.WriteLine(reader["CodiceArea"]);
                }

                //chiudo la connessione e il reader
                reader.Close();
                connection.Close();
            }
        }






    }
}
