using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ListaPrecio
    {
        private int id;
        private string nombre;
        private string descripcion;
        private List<Producto> productos;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public List<Producto> Productos { get => productos; set => productos = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
