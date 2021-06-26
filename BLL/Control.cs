using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Control
    {
        public List<BE.Permiso> CargarForm(BE.Idioma i)
        {
            DAL.Control mapperControl = new DAL.Control();
            List<BE.Permiso> ls = new List<BE.Permiso>();
            ls = mapperControl.CargarControles(i);
            return ls;
        }

        public string CargarDialogo(BE.Idioma i, String cod)
        {
            DAL.Control mapperControl = new DAL.Control();
            return mapperControl.CargarDialogo(i, cod);
        }
    }
}
