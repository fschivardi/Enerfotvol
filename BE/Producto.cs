using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Producto
    {
        private string codigo;
        private string sku;
        private string nombre;
        private string descripcion;
        private TipoProducto tipo;       
        private float precio_unitario_sin_iva;
        private float alicuota;
        private int puntostock;
        private bool estado;

        public Producto()
        {
            codigo = "";
            sku = "";
            nombre = "";
            descripcion = "";
            tipo = new BE.TipoProducto();
            precio_unitario_sin_iva = 0;
            alicuota = 21;
            puntostock = 0;
            estado = true;
        }

        public String Codigo { get => codigo; set => codigo = value; }
        public String SKU { get => sku; set => sku = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public TipoProducto Tipo { get => tipo; set => tipo = value; }        
        public float Precio_unitario_sin_iva { get => precio_unitario_sin_iva; set => precio_unitario_sin_iva = value; }
        public float Alicuota { get => alicuota; set => alicuota = value; }
        public int PuntoStock { get => puntostock; set => puntostock = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
