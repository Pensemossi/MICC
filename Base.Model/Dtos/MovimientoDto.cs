using Base.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Model.Dtos
{
    public class MovimientoDto
    {
        public string NroDocSoporte { get; set; }
        public long IdConsulta { get; set; }

        public Location Location { get; set; }
        public List<Movimiento> Movimientos { get; set; }

    }
}
