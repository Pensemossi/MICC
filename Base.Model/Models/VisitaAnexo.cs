using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Models
{
    public class VisitaAnexo
    {
        public Int64 IdInspeccion { get; set; }
        public Int64 IdInspeccionVisita { get; set; }

        public Object sFoto1 { get; set; } 
        public Object sFoto2 { get; set; } 
        public Object sFoto3 { get; set; } 
        public Object sFoto4 { get; set; }
        public string sTitulo1 { get; set; }
        public string sTitulo2 { get; set; }
        public string sTitulo3 { get; set; }
        public string sTitulo4 { get; set; }
        public int iRegistraFotos { get; set; }
        /* consulta */
        public string Token { get; set; }
    }
}

