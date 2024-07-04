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

        public PersonaDetailViewModel GetPersona(int id){
            string query = "SELECT Id, Nome, Cognome, Citta, Eta FROM Persone WHERE Id ="
            +id + ";SELECT Id, Marca, Modello FROM MAcchine WHERE PersonaId="+id;
            DataSet dataSet = db.Query(query);
            var personaDataTable = dataSet.Tables[0];
            if(personaDataTable.Rows.Count != 1){
                throw new InvalidOperationException($"Persona con id = {id} non trovata");
            }
            var personaRow = personaDataTable.Rows[0];
            var personaDetailViewModel = PersonaDetailViewModel.FromDataRow(personaRow);

            var macchinaDataTable = dataSet.Tables[1];
            foreach(DataRow macchinaRow in macchinaDataTable.Rows){
                var macchina = MacchinaViewModel.FromDataRow(macchinaRow);
                personaDetailViewModel.macchine.Add(macchina);
            }

            return personaDetailViewModel;
        }
    }
}