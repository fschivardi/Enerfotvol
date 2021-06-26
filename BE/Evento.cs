using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Evento
    {
        private int id;
        private string descripcion;
        private bool critico;

        public Evento()
        {
            id = 0;
            descripcion = "";
            critico = false;
        }

        public Evento(int i, string d, bool c)
        {
            id = i;
            descripcion = d;
            critico = c;
        }
        public int Id { get => id; set => id = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public bool Critico { get => critico; set => critico = value; }
        public override string ToString()
        {
            return descripcion.ToString();
        }
    }
}
