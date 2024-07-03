using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persone.Models.ViewModels;


namespace Persone.Models.Services.Application
{
    public class PersonaServices:IPersonaServices
    {
        public List<PersonaViewModel> GetPersone(){
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
            
        };
        return Listapersone;
        }

    }
}