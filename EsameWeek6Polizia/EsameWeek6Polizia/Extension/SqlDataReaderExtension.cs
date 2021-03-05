using EsameWeek6Polizia.Classi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EsameWeek6Polizia.Extension
{
    public static class SqlDataReaderExtension
    {
        public static Agente GetAgente(this SqlDataReader reader)
        {
            return new Agente()
            {
                Nome = (string) reader["Nome"],
                Cognome = (string) reader["Cognome"],
                CodiceFiscale = (string) reader["CodiceFiscale"],
                DataDiNascita = (DateTime)reader["DataDiNascita"],
                AnniDiServizio = (int)reader["AnniDiServizio"],
            };
        }
    }
}
