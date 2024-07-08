using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Persone.Models.ViewModels;
using Persone.Models.Services.Infrastructure;
using Persone.Models.InputModels;
using Persone.Controllers;

namespace Persone.Models.Services.Application
{
    public class AdoNetPersonaService:IPersonaServices
    {
        private readonly IDatabaseAccessor db;

        public AdoNetPersonaService(IDatabaseAccessor db){
            this.db = db;
        }

        public List<PersonaViewModel> GetPersone(){
            FormattableString query = $"SELECT Id, Nome, Cognome, Citta, Eta FROM Persone";
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
            FormattableString query = $@"SELECT Id, Nome, Cognome, Citta, Eta FROM Persone WHERE Id = {id}
            ; SELECT Id, Marca, Modello FROM MAcchine WHERE PersonaId={id}";
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

        public PersonaDetailViewModel CreatePersona(PersonaCreateInputModel input){
            string nome = input.Nome;
            string cognome = input.Cognome;
            string citta = input.Citta;
            int eta = input.Eta;
            var dataSet= db.Query($@"INSERT INTO Persone (Nome, Cognome, Citta, Eta) VALUES ({nome}, {cognome}, {citta}, {eta});
            SELECT last_insert_rowid();");
            int personaId = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
            PersonaDetailViewModel persona = GetPersona(personaId);
            return persona;
        }
       public void DeletePersona(int id)
        {
            FormattableString query = $@"DELETE FROM Persone WHERE Id = {id}";
            db.ExecuteNonQuery(query);

        }        
    }
}