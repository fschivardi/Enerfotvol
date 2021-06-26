using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class TipoProducto
    {
        private int id;
        private string descripcion;

        public TipoProducto()
        {
            id = 0;
            descripcion = "";
        }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return descripcion;
        }
    }
}
