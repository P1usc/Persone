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
        

        public static PersonaViewModel FromDataRow(DataRow personaRow){
            var personaViewModel = new PersonaViewModel{
                nome=Convert.ToString(personaRow ["Nome"]),
                cognome=Convert.ToString(personaRow ["Cognome"]),
                id=Convert.ToInt32(personaRow ["Id"])
            };
            return personaViewModel;
        }
    }
}