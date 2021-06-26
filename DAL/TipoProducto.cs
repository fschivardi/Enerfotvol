using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class TipoProducto : Mapper<BE.TipoProducto>
    {
        public TipoProducto()
        {
            con = new Acceso();
            conpropia = true;
        }

        internal TipoProducto(Acceso ac)
        {
            con = ac;
            conpropia = false;
        }
        public override List<BE.TipoProducto> Listar()
        {
            DataTable dt = new DataTable();
            List<BE.TipoProducto> ls = new List<BE.TipoProducto>();

            Abrir();
            dt = con.Leer("ListarTiposProducto");
            Cerrar();

            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                BE.TipoProducto r = new BE.TipoProducto();
                r.Id = Convert.ToInt32(dt.Rows[n]["IdTipo"]);
                r.Descripcion = Convert.ToString(dt.Rows[n]["Tipo"]);
                ls.Add(r);
            }

            return ls;
        }

        public BE.TipoProducto Listar(int id)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", id));

            Abrir();
            dt = con.Leer("CargarTiposProducto", par);
            Cerrar();

            BE.TipoProducto tipoprod = new BE.TipoProducto();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                tipoprod.Id = Convert.ToInt32(dt.Rows[n]["IdTipo"]);
                tipoprod.Descripcion = Convert.ToString(dt.Rows[n]["Tipo"]);
            }

            return tipoprod;
        }



        public override int Crear(BE.TipoProducto tipoprod)
        {
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@DESCR", tipoprod.Descripcion));

            Abrir();
            int res = con.Escribir("CrearTipoProducto", par);
            Cerrar();

            return res;
        }

        public override int Actualizar(BE.TipoProducto tipoprod)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", tipoprod.Id));
            par.Add(con.CrearParametro("@DESCR", tipoprod.Descripcion));

            Abrir();
            res = con.Escribir("ModificarTipoProducto", par);
            Cerrar();

            return res;
        }


        public override int Borrar(BE.TipoProducto tipoprod)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", tipoprod.Id));

            Abrir();

            res = con.Escribir("BorrarTipoProducto", par);

            Cerrar();
            return res;
        }
    }
}
