using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Concepto
    {
        private float cantidad;
        private bool afecta_stock;
        private float bonificacion_porcentaje;
        private Producto producto;

        public float Cantidad { get => cantidad; set => cantidad = value; }
        public bool Afecta_stock { get => afecta_stock; set => afecta_stock = value; }
        public float Bonificacion_porcentaje { get => bonificacion_porcentaje; set => bonificacion_porcentaje = value; }
        public Producto Producto { get => producto; set => producto = value; }
    }
}
