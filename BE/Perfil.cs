using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Perfil : Componente
    {
        private IList<Componente> hijos;


        public Perfil()
        {
            hijos = new List<Componente>();
            id = 0;
            descripcion = "";
        }

        public override IList<Componente> Hijos
        {
            get { return hijos.ToArray(); }

        }

        public override void AgregarHijo(Componente c)
        {
            hijos.Add(c);
        }
        public override void QuitarHijo(Componente c)
        {
            hijos.Remove(c);
        }
        public override void VaciarHijos()
        {
            hijos = new List<Componente>();
        }

    }
}

