using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persone.Models.Services;
using Persone.Models.ViewModels;

namespace Persone.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaServices PersonaServices;
        public PersonaController(IPersonaServices personaServices){
            this.PersonaServices = personaServices;
        }
       
        public IActionResult Index()
        {
            //var persone = PersonaServices.GetPersone();
            List<PersonaViewModel> persone = PersonaServices.GetPersone();
            return View(persone);
        }

        public IActionResult Detail(int id)
        {
            var persone = PersonaServices.GetPersone();
            var persona = persone.FirstOrDefault(p => p.id == id);  // Usa 'id' anziché 'Id'
            PersonaViewModel viewModel = new PersonaViewModel
            {
                id = persona.id,
                nome = persona.nome,
                cognome = persona.cognome,
                citta = persona.citta,
                eta = persona.eta
            };

            return View(viewModel);
        }

        
    }
}