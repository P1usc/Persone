using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persone.Models.InputModels
{
    public class PersonaCreateInputModel
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Citta { get; set; }
        public int Eta { get; set; }
    }
}