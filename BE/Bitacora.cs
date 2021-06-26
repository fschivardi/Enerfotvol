using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bitacora
    {
        private int id;
        private string objeto;
        private DateTime fechaHora;
        private Evento evento;
        private string autor;
        private DigitoVerificador digitoV;

        public Bitacora()
        {
            id = 0;
            objeto = "";
            fechaHora = DateTime.Now;
            evento = new Evento();
            autor = "";
            digitoV = new DigitoVerificador();

        }

        public int Id { get => id; set => id = value; }
        public String Objeto { get => objeto; set => objeto = value; }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public BE.Evento Evento { get => evento; set => evento = value; }
        public String Autor { get => autor; set => autor = value; }
        public DigitoVerificador DigitoV { get => digitoV; set => digitoV = value; }
    }
}
