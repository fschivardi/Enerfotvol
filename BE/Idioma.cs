using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Idioma
    {
        private int id;
        private string descripcion;
        private List<Control> controles;

        public Idioma()
        {
            id = 1;
            descripcion = "";
            controles = new List<Control>();
        }
        public Idioma(int i, String d, List<Control> ls)
        {
            id = i;
            descripcion = d;
            controles= ls;
        }
        public int Id { get => id; set => id = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public List<Control> Controles { get => controles; set => controles = value; }
    }
}
