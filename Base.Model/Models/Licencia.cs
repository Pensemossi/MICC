using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Models
{
    public class Licencia
    {
        public string IdUser { get; set; }
        public Int64 IdSolicitudPadre { get; set; }
        public Int64 IdSolicitudLicencia { get; set; }
        public string Empresa { get; set; }
        public string ClaseSolicitud { get; set; }
        public string FechaDiligenciamiento { get; set; }
        public string NroRadicado { get; set; }
        public string TipoLicencia { get; set; }
        public string Estado { get; set; }

        /* consulta */
        public string Token { get; set; }
    }
}
