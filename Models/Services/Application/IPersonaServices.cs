using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persone.Models.ViewModels;

namespace Persone.Models.Services.Application
{
    public interface IPersonaServices
    {
        List<PersonaViewModel> GetPersone();

        PersonaDetailViewModel GetPersona(int id);
    }
}