using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Comprobante
    {
        private Cabecera cabecera;
        private Detalle detalle;

        public Cabecera Cabecera { get => cabecera; set => cabecera = value; }
        public Detalle Detalle { get => detalle; set => detalle = value; }
    }
}
