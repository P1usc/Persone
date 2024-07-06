using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persone.Models.ViewModels;
using Persone.Models.InputModels;


namespace Persone.Models.Services.Application
{
    public class PersonaServices : IPersonaServices
    {
        public List<PersonaViewModel> GetPersone(){
            var Listapersone = new List<PersonaViewModel>(){
                new PersonaViewModel{
                    id = 1,
                    nome = "Mario",
                    cognome = "Rossi",
                    
                },
                new PersonaViewModel{
                    id = 2,
                    nome = "Marco",
                    cognome = "Bianchi",
                    
                },
            
            };
            return Listapersone;
        }

        public PersonaDetailViewModel GetPersona(int id){
            var persona = new PersonaDetailViewModel(){
                id=id,
                nome=$"Nome{id}",
                cognome=$"Cognome{id}",
                eta=id,
                citta=$"Citta{id}",
                macchine= new List<MacchinaViewModel>()
            };

            for(var i=1; i<=5; i++){
                var macchina= new MacchinaViewModel{
                    marca=$"Marca{i}",
                    modello=$"Modello{i}",
                };
                persona.macchine.Add(macchina);
            }
            return persona;
        }

        public PersonaDetailViewModel CreatePersona(PersonaCreateInputModel input){
            throw new NotImplementedException();
        }
    }
}