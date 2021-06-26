using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Idioma
    {
        public List<BE.Idioma> Listar()
        {
            Acceso con = new Acceso();
            List<BE.Idioma> ls = new List<BE.Idioma>();

            con.Abrir();
            DataTable dt = con.Leer("CargarIdiomas");
            con.Cerrar();
            
            foreach (DataRow row in dt.Rows)
            {
                BE.Idioma i = new BE.Idioma();
                i.Id = Int32.Parse(row["Id_Idioma"].ToString());                    
                i.Descripcion = row["Idioma"].ToString();
                CargarControles(i);
                ls.Add(i);
            }
            
            return ls;
        }

        private void CargarControles(BE.Idioma i)
        {
            Acceso con = new Acceso();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", i.Id));
            con.Abrir();
            DataTable dt = con.Leer("CargarControles",par);
            con.Cerrar();

            foreach (DataRow row in dt.Rows)
            {
                BE.Control c = new BE.Control();
                c.Id = row["Id_Control"].ToString();
                c.Valor = row["Valor"].ToString();
                c.Tipo = Convert.ToInt32(row["Id_TipoControl"]);                
                i.Controles.Add(c);
            }
        }
    }
}
