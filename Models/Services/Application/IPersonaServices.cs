using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persone.Models.ViewModels;
using Persone.Models.InputModels;

namespace Persone.Models.Services.Application
{
    public interface IPersonaServices
    {
        List<PersonaViewModel> GetPersone();

        PersonaDetailViewModel GetPersona(int id);

        PersonaDetailViewModel CreatePersona(PersonaCreateInputModel input);
        void DeletePersona(int id);
    }
}