using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class Mapper<T>
    {
        internal Acceso con;

        protected bool conpropia;

        public abstract int Crear(T objeto);
        public abstract int Actualizar(T objeto);
        public abstract int Borrar(T objeto);

        public abstract List<T> Listar();
        protected void Abrir()
        {
            if (conpropia)
            {
                con.Abrir();
            }
        }
        protected void Cerrar()
        {
            if (conpropia)
            {
                con.Cerrar();
            }
        }


        

    }
}
