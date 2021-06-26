using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Idioma
    {
        public List<BE.Idioma> CargarIdiomas()
        {
            DAL.Idioma mapperIdioma = new DAL.Idioma();
            List<BE.Idioma> ls = new List<BE.Idioma>();
            ls = mapperIdioma.Listar();
            return ls;
        }
    }
}
