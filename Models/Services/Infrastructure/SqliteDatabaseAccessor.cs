using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.Sqlite;

namespace Persone.Models.Services.Infrastructure
{
    public class SqliteDatabaseAccessor : IDatabaseAccessor
    {
        public DataSet Query(FormattableString formattableQuery)
        {
            var queryArguments = formattableQuery.GetArguments();
            var sqliteParameters = new List<SqliteParameter>();
            for(var i = 0; i < queryArguments.Length; i++){
                var parameter = new SqliteParameter(i.ToString(), queryArguments[i]);
                sqliteParameters.Add(parameter);
                queryArguments[i]="@"+i;
            }
            string query = formattableQuery.ToString();
            using (var conn = new SqliteConnection("Data Source=Data/Persona.db"))
            {
                conn.Open();
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddRange(sqliteParameters);
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dataSet = new DataSet();
                        dataSet.EnforceConstraints = false;
                         do{
                            var dataTable = new DataTable();
                            dataSet.Tables.Add(dataTable);
                            dataTable.Load(reader);
                        } while (!reader.IsClosed);
                        
                        return dataSet;
                    }
                }
            }
        }
        public int ExecuteNonQuery(FormattableString formattableQuery)
        {
            var queryArguments = formattableQuery.GetArguments();
            var sqliteParameters = new List<SqliteParameter>();
            for (var i = 0; i < queryArguments.Length; i++)
            {
                var parameter = new SqliteParameter("@" + i, queryArguments[i]);
                sqliteParameters.Add(parameter);
                queryArguments[i] = "@" + i;
            }
            string query = formattableQuery.ToString();

            using (var conn = new SqliteConnection("Data Source=Data/Persona.db"))
            {
                conn.Open();
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddRange(sqliteParameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
