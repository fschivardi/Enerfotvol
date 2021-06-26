using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Cliente
    {
        private int id;
        private TipoDocumento documento_tipo;
        private int documento_nro;
        private string razon_social;
        private string email;
        private string domicilio;
        private Provincia provincia;
        private bool envia_por_mail;
        private int condicion_pago;
        private string condicion_pago_otra;
        private string condicion_iva;

        public int Id { get => id; set => id = value; }
        public TipoDocumento Documento_tipo { get => documento_tipo; set => documento_tipo = value; }
        public int Documento_nro { get => documento_nro; set => documento_nro = value; }
        public String Razon_social { get => razon_social; set => razon_social = value; }
        public String Email { get => email; set => email = value; }
        public String Domicilio { get => domicilio; set => domicilio = value; }
        public Provincia Provincia { get => provincia; set => provincia = value; }
        public bool Envia_por_mail { get => envia_por_mail; set => envia_por_mail = value; }
        public int Condicion_pago { get => condicion_pago; set => condicion_pago = value; }
        public String Condicion_pago_otra { get => condicion_pago_otra; set => condicion_pago_otra = value; }
        public String Condicion_iva { get => condicion_iva; set => condicion_iva = value; }
    }
}
