using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persone.Models.ViewModels;

namespace Persone.Models.Services
{
    public interface IPersonaServices
    {
        List<PersonaViewModel> GetPersone();
    }
}