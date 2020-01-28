using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Models
{
    public class Movimiento
    {

        public string NroDocSoporte { get; set; }
        public string TipoDocSoporte { get; set; }
        public string Empresa { get; set; }
        public string sucursal { get; set; }
        public string sustancia { get; set; }
        public int NoCcite1 { get; set; }
        public string TipoMovimiento { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public double CantidadMovimiento { get; set; }
        public string UnidadMedida { get; set; }
        public string TerceroNombre { get; set; }
        public string TerceroDoc { get; set; }
        public string TerceroNoCcite { get; set; }


    }
}
