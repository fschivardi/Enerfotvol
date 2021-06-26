using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Almacen
    {
        private int id;
        private String nombre;
        private String descripcion;

        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
    }
}
