using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DigitoVerificador
    {
        private string tabla;
        private string dVV;
        private string dVH;

        public DigitoVerificador()
        {
            dVH = "";
            tabla = "";
            dVV = "";
        }
        public DigitoVerificador(string dvh, string tab, string dvv)
        {
            dVH = dvh;
            tabla = tab;
            dVV = dvv;
        }


        public String DVH { get => dVH; set => dVH = value; }
        public String Tabla { get => tabla; set => tabla = value; }
        public String DVV { get => dVV; set => dVV = value; }
    }
}
