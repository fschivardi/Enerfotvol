using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DAL
{
    public class DigitoVerificador:Mapper<BE.DigitoVerificador>
    {
        public DigitoVerificador()
        {
            con = new Acceso();
            conpropia = true;
        }

        internal DigitoVerificador(Acceso ac)
        {
            con = ac;
            conpropia = false;
        }
        public bool ActualizarDVV(string tabla, String dvv)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@TABLA", tabla));
            par.Add(con.CrearParametro("@DVV", dvv));
            
            Abrir();
            res = con.Escribir("ActualizarDVV", par);
            Cerrar();
            bool ok;
            if (res > 0)
            {
                ok = true;
            }
            else
            {
                ok = false;
            }

            return ok;
        }

        public List<String> TraerDVHfromTabla(string tbl)
        {            
            var dt = new DataTable();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@TABLA", tbl));

            Abrir();
            dt = con.Leer("ListarDVHTabla", par);
            Cerrar();

            var ls = new List<String>();
            foreach (DataRow row in dt.Rows)
            {
                String r;
                r = row["DVH"].ToString();
                ls.Add(r);
            }

            con = null;
            return ls;
        }

        public override List<BE.DigitoVerificador> Listar()
        {
            var dt = new DataTable();

            Abrir();
            dt = con.Leer("ListarTablas");
            Cerrar();

            var lsDVV = new List<BE.DigitoVerificador>();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                var r = new BE.DigitoVerificador();
                r.Tabla = Convert.ToString(dt.Rows[n]["Tabla"]);
                r.DVV = Convert.ToString(dt.Rows[n]["DGV"]);
                lsDVV.Add(r);
            }

            con = null;
            return lsDVV;
        }

        public override int Crear(BE.DigitoVerificador objeto)
        {
            throw new NotImplementedException();
        }
        public override int Actualizar(BE.DigitoVerificador objeto)
        {
            throw new NotImplementedException();
        }
        public override int Borrar(BE.DigitoVerificador objeto)
        {
            throw new NotImplementedException();
        }
    }
}
