using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persone.Models.Services;

namespace Persone.Controllers
{
    public class PersonaController : Controller
    {
       
        public IActionResult Index()
        {
            var persone = PersonaServices.GetPersone();
            return View(persone);
        }

        public IActionResult Detail(int id)
        {
            return View();
        }

        
    }
}