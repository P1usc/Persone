using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Persone.Models.ViewModels;

namespace Persone.Models.ViewModels
{
    public class MacchinaViewModel
    {
        public int id { get; set; }
        public string marca { get; set; }
        public string modello { get; set; }

        public static MacchinaViewModel FromDataRow(DataRow macchinaRow){
            var macchinaViewModel = new MacchinaViewModel{
                marca=Convert.ToString(macchinaRow ["Marca"]),
                modello=Convert.ToString(macchinaRow ["Modello"]),
                id=Convert.ToInt32(macchinaRow ["Id"])
            };
            return macchinaViewModel;
        }
    }
}