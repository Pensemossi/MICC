using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Model.Models;

namespace Base.Model.Dtos
{
    public class VisitaAnexoDto
    {
        public Int64 IdInspeccion { get; set; }
        public Int64 IdInspeccionVisita { get; set; }

        public string sFoto1 { get; set; } //temporal por desarrollo
        public string sFoto2 { get; set; } //temporal por desarrollo
        public string sFoto3 { get; set; } //temporal por desarrollo
        public string sFoto4 { get; set; } //temporal por desarrollo
        public string sTitulo1 { get; set; }
        public string sTitulo2 { get; set; }
        public string sTitulo3 { get; set; }
        public string sTitulo4 { get; set; }
        public int iRegistraFotos { get; set; }

        public Location Location { get; set; }
    }
}
