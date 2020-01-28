using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Models
{
    public class LicenciasEstado
    {
        public string Token { get; set; }
        public string IdUser { get; set; }
        public List<Licencia> Licencias { get; set; }
    }
}
