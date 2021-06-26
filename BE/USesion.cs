using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class USesion
    {
        private static USesion sesion;
        private Usuario usuarioSesion;
        private Idioma idiomaSesion;

        private USesion()
        {

        }
        public static USesion GetInstance
        {
            get
            {
                if (sesion == null) sesion = new USesion();
                return sesion;
            }
        }
        public BE.Usuario UsuarioSesion { get => usuarioSesion; set => usuarioSesion = value; }
        public BE.Idioma IdiomaSesion { get => idiomaSesion; set => idiomaSesion = value; }
    }
}
