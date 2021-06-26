using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace DAL
{
    public class Control
    {
        public String CargarDialogo(BE.Idioma id, String ctrl)
        {
            Acceso con = new Acceso();
            DataTable dt = new DataTable();
            List<SqlParameter> par = new List<SqlParameter>();

            par.Add(con.CrearParametro("@IDIOMA", id.Id));
            par.Add(con.CrearParametro("@IDMENU", ctrl));

            con.Abrir();
            dt = con.Leer("CargarDialogo", par);
            con.Cerrar();

            String dialogo = dt.Rows[0]["Descripcion"].ToString();
            
            con = null;

            return dialogo;
        }

        public List<BE.Permiso> CargarControles(BE.Idioma id)
        {
            Acceso con = new Acceso();
            DataTable dt = new DataTable();
            List<BE.Permiso> ls = new List<BE.Permiso>();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@IDIOMA", id.Id));
            
            con.Abrir();
            dt = con.Leer("ListarControles", par);
            con.Cerrar();
            
            foreach (DataRow row in dt.Rows)
            {
                BE.Permiso r = new BE.Permiso();
                r.Id = Convert.ToInt32(row["Id_Menu"]);
                r.Permiso = row["Nombre"].ToString();
                r.Descripcion = row["Descripcion"].ToString();
                
                ls.Add(r);
            }
            con = null;
            return ls;
        }
    }
}
