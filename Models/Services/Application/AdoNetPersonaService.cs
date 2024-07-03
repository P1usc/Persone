using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

using Persone.Models.ViewModels;
using Persone.Models.Services.Infrastructure;

namespace Persone.Models.Services.Application
{
    public class AdoNetPersonaService:IPersonaServices
    {
        private readonly IDatabaseAccessor db;

        public AdoNetPersonaService(IDatabaseAccessor db){
            this.db = db;
        }

        public List<PersonaViewModel> GetPersone(){
            string query = "SELECT Id, Nome, Cognome, Citta, Eta FROM Persone";
            DataSet dataSet = db.Query(query);

            var dataTable = dataSet.Tables[0];
            var listaPersone = new List<PersonaViewModel>();
            foreach (DataRow personaRow in dataTable.Rows){
                var persona = PersonaViewModel.FromDataRow(personaRow);
                listaPersone.Add(persona);
            }
            return listaPersone;
        }
    }
}