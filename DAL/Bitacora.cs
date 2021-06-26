using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class Bitacora
    {
        public int RegistrarBitacora(BE.Bitacora btc)
        {
            Acceso con = new Acceso();

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", btc.Objeto));
            par.Add(con.CrearParametro("@FECHAHORA", btc.FechaHora.Ticks));
            par.Add(con.CrearParametro("@EVENTO", btc.Evento.Id));
            par.Add(con.CrearParametro("@AUTOR", btc.Autor));
            
            con.Abrir();
            int res = con.Escribir("RegistrarBitacora", par);
            con.Cerrar();
                        
            return res;
        }

      
        // Lista TODA LA TABLA DE BITACORA
        public List<BE.Bitacora> ListarBitacora()
        {
            Acceso con = new Acceso();
            List<BE.Bitacora> ls = new List<BE.Bitacora>();
            
            con.Abrir();
            DataTable dt = con.Leer("ListarBitacoraALL");
            con.Cerrar();

            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                BE.Bitacora r = new BE.Bitacora();
                BE.Evento j = new BE.Evento();

                r.Id = Convert.ToInt32(dt.Rows[n]["Id_Audit"]);
                r.Objeto = Convert.ToString(dt.Rows[n]["Id_Usuario"]);
                var d = new DateTime(Convert.ToInt64(dt.Rows[n]["FechaHora"]));
                r.FechaHora = d;
                j.Id = Convert.ToInt32(dt.Rows[n]["Id_Evento"]);
                j.Descripcion = "";
                r.Evento = j;
                r.Autor = Convert.ToString(dt.Rows[n]["Id_Autor"]);
                r.DigitoV.DVH = Convert.ToString(dt.Rows[n]["DVH"]);
                ls.Add(r);
            }

            con = null;
            return ls;
        }

        public List<BE.Bitacora> ListarBitacora(BE.Bitacora bitac, DateTime desde, DateTime hasta, int idioma)
        {
            var con = new Acceso();
            
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@OBJETO", bitac.Objeto));
            par.Add(con.CrearParametro("@DESDE", desde.Ticks));
            par.Add(con.CrearParametro("@HASTA", hasta.Ticks));
            par.Add(con.CrearParametro("@IDIOMA", idioma));
            if (bitac.Evento.Id > 0)
            {
                par.Add(con.CrearParametro("@EVENTO", bitac.Evento.Id));                
            }
            else
            {
                par.Add(con.CrearParametro("@EVENTO", DBNull.Value));
            }

            par.Add(con.CrearParametro("@AUTOR", bitac.Autor));
            con.Abrir();
            DataTable dt = con.Leer("ListarBitacora", par);
            con.Cerrar();
            List<BE.Bitacora> ls = new List<BE.Bitacora>();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                var r = new BE.Bitacora();
                var j = new BE.Evento();
                r.Id = Convert.ToInt32(dt.Rows[n]["Id_Bitacora"]);
                r.Objeto = Convert.ToString((dt.Rows[n]["Objeto"]));
                var d = new DateTime(Convert.ToInt64(dt.Rows[n]["FechaHora"]));
                r.FechaHora = d;
                j.Id = Convert.ToInt32(dt.Rows[n]["Id_Evento"]);
                j.Descripcion = Convert.ToString(dt.Rows[n]["Descripcion"]);
                j.Critico = Convert.ToBoolean(dt.Rows[n]["Critico"]);
                r.Evento = j;
                r.Autor = Convert.ToString(dt.Rows[n]["Autor"]);                
                ls.Add(r);
            }

            con = null;
            return ls;
        }


        public List<BE.Evento> ListarEventos()
        {
            var con = new Acceso();

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@IDIOMA", BE.USesion.GetInstance.IdiomaSesion.Id.ToString()));
            
            con.Abrir();
            DataTable dt = con.Leer("ListarEventos", par);
            con.Cerrar();
            List<BE.Evento> ls = new List<BE.Evento>();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                var r = new BE.Evento();
                r.Id = Convert.ToInt32(dt.Rows[n]["Id_Evento"]);
                r.Descripcion = Convert.ToString(dt.Rows[n]["Descripcion"]);
                ls.Add(r);
            }

            con = null;
            return ls;
        }
    }
}
