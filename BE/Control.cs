using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Control
    {
        private string id;
        private int tipo;
        private string valor;

        public Control()
        {
            id = "";
            tipo = 0;
            valor = "";
        }
        public Control(string i, int t, string v)
        {
            id = i;
            tipo = t;
            valor = v;
        }
        public string Id { get => id; set => id = value; }
        public int Tipo { get => tipo; set => tipo = value; }
        public string Valor { get => valor; set => valor = value; }
    }
}
