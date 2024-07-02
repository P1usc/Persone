using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persone.Models.ViewModels
{
    public class PersonaViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string citta { get; set; }
        public int eta { get; set; }
    }
}