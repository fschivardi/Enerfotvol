using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Proveedor
    {
        private int id;
        private String nombre;
        private String descripcion;
        private String direccion;
        private String telefono;
        private String sitioweb;
        private String mail;
        private bool estado;

        public int Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public String Direccion { get => direccion; set => direccion = value; }
        public String Telefono { get => telefono; set => telefono = value; }
        public String SitioWeb { get => sitioweb; set => sitioweb = value; }
        public String Mail { get => mail; set => mail = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
