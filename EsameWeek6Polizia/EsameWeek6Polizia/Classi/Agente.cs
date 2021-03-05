using System;
using System.Collections.Generic;
using System.Text;

namespace EsameWeek6Polizia.Classi
{
    //la classe agente deriva le proprietà e i metodi dalla classe astratta Persona 
    public class Agente : Persona
    {
        //proprietà
        public DateTime DataDiNascita { get; set; }
        public int AnniDiServizio { get; set; }

        //costruttori
        public Agente()
        {
            DataDiNascita = DateTime.Now;
            AnniDiServizio = 0;

        }
        public Agente(string nome, string cognome, string codiceF, int anniS) : base(nome, cognome, codiceF)
        {
            //in questo modo derivo il costruttore da Persona(classe base)
            DataDiNascita = DateTime.Now;
            AnniDiServizio = anniS;
        }

        //metodi
        public override string ToString()
        {
            //I dati relativi ad un agente devono essere mostrati a schermo:
            //Codice Fiscale – Nome Cognome – AnnidiServizio anni di servizio

            return CodiceFiscale + " - " + Nome + " " + Cognome + " - " + AnniDiServizio + " anni di servizio";
        }
    }
}
