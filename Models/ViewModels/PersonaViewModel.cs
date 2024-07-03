using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;


namespace Persone.Models.ViewModels
{
    public class PersonaViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string citta { get; set; }
        public int eta { get; set; }

        public static PersonaViewModel FromDataRow(DataRow personaRow){
            var personaViewModel = new PersonaViewModel{
                nome=Convert.ToString(personaRow ["Nome"]),
                cognome=Convert.ToString(personaRow ["Cognome"]),
                citta=Convert.ToString(personaRow ["Citta"]),
                eta=Convert.ToInt32(personaRow ["Eta"]),
                id=Convert.ToInt32(personaRow ["Id"])
            };
            return personaViewModel;
        }
    }
}