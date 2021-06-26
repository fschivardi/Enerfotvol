using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TipoDocumento
    {
        private int id;
        private string descripcion;

        public int Id { get => id; set => id = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
    }
}
