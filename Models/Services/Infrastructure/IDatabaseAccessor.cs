using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Persone.Models.Services.Infrastructure
{
    public interface IDatabaseAccessor
    {
        DataSet Query(string query);
    }
}