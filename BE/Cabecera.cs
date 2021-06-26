using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cabecera
    {
        private int nroComprobante;
        private DateTime fecha;
        private int tipo_comprobante;
        private string operacion;
        private Cliente cliente;
        private int idioma;
        private int punto_venta;
        private int tipo_moneda;
        private float cotizacion;
        private DateTime periodo_facturado_desde;
        private DateTime periodo_facturado_hasta;
        private string rubro;
        private float total;
        
        public int NroComprobante { get => nroComprobante; set => nroComprobante = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Tipo_comprobante { get => tipo_comprobante; set => tipo_comprobante = value; }
        public string Operacion { get => operacion; set => operacion = value; }
        public int Idioma { get => idioma; set => idioma = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public int Punto_venta { get => punto_venta; set => punto_venta = value; }
        public int Tipo_moneda { get => tipo_moneda; set => tipo_moneda = value; }
        public float Cotizacion { get => cotizacion; set => cotizacion = value; }
        public DateTime Periodo_facturado_desde { get => periodo_facturado_desde; set => periodo_facturado_desde = value; }
        public DateTime Periodo_facturado_hasta { get => periodo_facturado_hasta; set => periodo_facturado_hasta = value; }
        public String Rubro { get => rubro; set => rubro = value; }
        public float Total { get => total; set => total = value; }
    }
}
