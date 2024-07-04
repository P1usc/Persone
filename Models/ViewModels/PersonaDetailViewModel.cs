using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Persone.Models.ViewModels
{
    public class PersonaDetailViewModel : PersonaViewModel
    {
        public string citta { get; set; }
        public int eta { get; set; }
        public List<MacchinaViewModel> macchine { get; set; }

        public static new PersonaDetailViewModel FromDataRow(DataRow personaRow){
            var personaViewModel = new PersonaDetailViewModel{
                nome=Convert.ToString(personaRow ["Nome"]),
                cognome=Convert.ToString(personaRow ["Cognome"]),
                id=Convert.ToInt32(personaRow ["Id"]),
                citta=Convert.ToString(personaRow ["Citta"]),
                eta=Convert.ToInt32(personaRow ["Eta"]),
                macchine=new List<MacchinaViewModel>()
            };
            return personaViewModel;
        }

    }
}