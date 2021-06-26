using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Componente
    {
        protected int id;
        private string permiso;
        protected string descripcion;
        private int tipo;

        public Int32 Id { get => id; set => id = value; }
        public String Permiso { get => permiso; set => permiso = value; }

        public String Descripcion { get => descripcion; set => descripcion = value; }
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public abstract IList<Componente> Hijos { get; }

        public abstract void AgregarHijo(Componente c);
        public abstract void QuitarHijo(Componente c);
        public abstract void VaciarHijos();

    }
}
