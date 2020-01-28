using Base.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Dtos
{
    public class LicenciaDto
    {
        public string Token { get; set; }
        public string IdUser { get; set; }
        public Int64 IdSolicitudPadre { get; set; }
        public Int64 IdSolicitudLicencia { get; set; }
        public string Empresa { get; set; } 
        public string ClaseSolicitud { get; set; } 
        public string FechaDiligenciamiento { get; set; }
        public string NroRadicado { get; set; }
        public string TipoLicencia { get; set; }
        public string Estado { get; set; }

        public Location Location { get; set; }
        public List<Licencia> Licencias { get; set; }

    }
}
