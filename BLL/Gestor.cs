using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public abstract class Gestor<T>
    {
        public abstract bool Crear(T objeto);
        public abstract bool Actualizar(T objeto);
        public abstract bool Borrar(T objeto);
        public abstract List<T> Listar(T objeto);
        public abstract List<T> Listar();
        
    }
}
