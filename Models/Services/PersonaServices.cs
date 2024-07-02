using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persone.Models.ViewModels;


namespace Persone.Models.Services
{
    public class PersonaServices
    {
        public static List<PersonaViewModel> GetPersone(){
            var Listapersone = new List<PersonaViewModel>(){
            new PersonaViewModel{
                id = 1,
                nome = "Mario",
                cognome = "Rossi",
                citta = "Milano",
                eta = 20
            },
            new PersonaViewModel{
                id = 2,
                nome = "Marco",
                cognome = "Bianchi",
                citta = "Torino",
                eta = 25
            },
            new PersonaViewModel{
                id = 3,
                nome = "Giuseppe",
                cognome = "Verdi",
                citta = "Roma",
                eta = 28
            }
        };
        return Listapersone;
        }

    }
}