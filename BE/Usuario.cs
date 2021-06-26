using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        private string id;
        private string nombre;
        private string apellido;
        private string descripcion;
        private string encPassword;
        private string salt;
        private List<Componente> perfil;
        private string mail;
        private DateTime ultimoLogin;
        private DateTime ultimoIntentoF;
        private int intentosF;
        private bool bloqueado;
        private bool estado;

        public Usuario()
        {
            id = "";
            nombre = "";
            apellido = "";
            descripcion = "";
            encPassword = "";
            salt = "";
            mail = "";
            perfil = new List<Componente>();
            ultimoLogin = DateTime.MinValue;
            ultimoIntentoF = DateTime.MinValue;
            intentosF = 0;
            bloqueado = false;
            estado = true;
        }

        public Usuario(string i, string n, string a, string d, string m)
        {
            id = i;
            nombre = n;
            apellido = a;
            descripcion = d;
            encPassword = "";
            salt = "";
            mail = m;
            perfil = new List<Componente>();
            ultimoLogin = DateTime.MinValue;
            ultimoIntentoF = DateTime.MinValue;
            intentosF = 0;
            bloqueado = false;
            estado = true;
        }

        public String Id { get => id; set => id = value; }
        public String Nombre { get => nombre; set => nombre = value; }
        public String Apellido { get => apellido; set => apellido = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public String EncPassword { get => encPassword; set => encPassword = value; }
        public String Salt { get => salt; set => salt = value; }
        public List<Componente> Perfil { get => perfil; set => perfil = value; }
        public string Mail { get => mail; set => mail = value; }
        public DateTime UltimoLogin { get => ultimoLogin; set => ultimoLogin = value; }
        public DateTime UltimoIntentoF { get => ultimoIntentoF; set => ultimoIntentoF = value; }
        public int IntentosF { get => intentosF; set => intentosF = value; }
        public bool Bloqueado { get => bloqueado; set => bloqueado = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
