using System;
using System.Collections.Generic;
using System.Text;

namespace EsameWeek6Polizia.Classi
{
    //utilizzo una classe astratta persona perchè la classe deve implementare il metodo Equals e per questo non
    //potrei usare un interfaccia (vuole solo metodi astratti)
    //L'ho definita astratta anche se non ha nessun metodo astratto
    public abstract class Persona
    {
        //proprietà
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }

        //costruttori
        public Persona()
        {
            Nome = "Anonimo";
            Cognome = "Anonimo";
            CodiceFiscale = "XXXXXX00X00X000X";
        }
        public Persona(string nome, string cognome, string codiceF)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codiceF;
        }

        //metodi
        public override bool Equals(object obj)
        {
            //due persone sono uguali se hanno lo stesso codice fiscale
            return obj is Persona p && CodiceFiscale == p.CodiceFiscale;
        }
    }
}
