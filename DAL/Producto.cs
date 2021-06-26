using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

 namespace DAL
{
    public class Producto : Mapper<BE.Producto>
    {
        public Producto()
        {
            con = new Acceso();
            conpropia = true;
        }

        internal Producto(Acceso ac)
        {
            con = ac;
            conpropia = false;
        }
        public override List<BE.Producto> Listar()
        {            
            DataTable dt = new DataTable();
            List<BE.Producto> ls = new List<BE.Producto>();

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", ""));
            par.Add(con.CrearParametro("@NOMBRE", ""));
            par.Add(con.CrearParametro("@TIPO", DBNull.Value));
            par.Add(con.CrearParametro("@SKU", ""));
            
            Abrir();
            dt = con.Leer("ListarProductos",par);
            Cerrar();

            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                BE.Producto r = new BE.Producto();
                r.Codigo = Convert.ToString(dt.Rows[n]["CodProducto"]);
                r.Nombre = Convert.ToString(dt.Rows[n]["Nombre"]);
                r.Descripcion = Convert.ToString(dt.Rows[n]["Descripcion"]);
                r.Tipo.Id = Convert.ToInt32(dt.Rows[n]["IdTipo"]);
                r.Tipo.Descripcion = Convert.ToString(dt.Rows[n]["Tipo"]);
                r.PuntoStock = Convert.ToInt32(dt.Rows[n]["PuntoStock"]);
                r.SKU = Convert.ToString(dt.Rows[n]["SKU"]);
                r.Estado = Convert.ToBoolean(dt.Rows[n]["Estado"]);
                ls.Add(r);
            }

            return ls;
        }

        public List<BE.Producto> Listar(BE.Producto prod)
        {
            DataTable dt = new DataTable();
            List<BE.Producto> ls = new List<BE.Producto>();

            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", prod.Codigo));
            par.Add(con.CrearParametro("@NOMBRE", prod.Nombre));
            if (prod.Tipo.Id > 0)
            {
                par.Add(con.CrearParametro("@TIPO", prod.Tipo.Id));
            }
            else
            {
                par.Add(con.CrearParametro("@TIPO", DBNull.Value));
            }
            par.Add(con.CrearParametro("@SKU", prod.SKU));

            

            Abrir();
            dt = con.Leer("ListarProductos",par);
            Cerrar();

            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                BE.Producto r = new BE.Producto();
                r.Codigo = Convert.ToString(dt.Rows[n]["CodProducto"]);
                r.Nombre = Convert.ToString(dt.Rows[n]["Nombre"]);
                r.Descripcion = Convert.ToString(dt.Rows[n]["Descripcion"]);
                r.Tipo.Id = Convert.ToInt32(dt.Rows[n]["IdTipo"]);
                r.Tipo.Descripcion = Convert.ToString(dt.Rows[n]["Tipo"]);
                r.SKU = Convert.ToString(dt.Rows[n]["SKU"]);
                r.PuntoStock = Convert.ToInt32(dt.Rows[n]["PuntoStock"]);
                r.Estado = Convert.ToBoolean(dt.Rows[n]["Estado"]);
                ls.Add(r);
            }

            return ls;
        }

        public BE.Producto Listar(int codigo)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", codigo));

            Abrir();
            dt = con.Leer("CargarProducto", par);
            Cerrar();

            BE.Producto prod = new BE.Producto();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                prod.Codigo = Convert.ToString(dt.Rows[n]["CodProducto"]);
                prod.Nombre = Convert.ToString(dt.Rows[n]["Nombre"]);
                prod.Descripcion = Convert.ToString(dt.Rows[n]["Descripcion"]);
                prod.Tipo.Id = Convert.ToInt32(dt.Rows[n]["IdTipo"]);
                prod.Tipo.Descripcion = Convert.ToString(dt.Rows[n]["Tipo"]);
                prod.SKU = Convert.ToString(dt.Rows[n]["SKU"]);
                prod.PuntoStock = Convert.ToInt32(dt.Rows[n]["PuntoStock"]);
                prod.Estado = Convert.ToBoolean(dt.Rows[n]["Estado"]);
            }

            return prod;
        }

        

        public override int Crear(BE.Producto producto)
        {
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", producto.Codigo));
            par.Add(con.CrearParametro("@NOMBRE", producto.Nombre));
            par.Add(con.CrearParametro("@DESCR", producto.Descripcion));
            par.Add(con.CrearParametro("@TIPO", producto.Tipo.Id));
            par.Add(con.CrearParametro("@PSTOCK", producto.PuntoStock));
            par.Add(con.CrearParametro("@SKU", producto.SKU));            

            Abrir();
            int res = con.Escribir("CrearProducto", par);
            Cerrar();

            return res;
        }

        public override int Actualizar(BE.Producto producto)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", producto.Codigo));
            par.Add(con.CrearParametro("@NOMBRE", producto.Nombre));
            par.Add(con.CrearParametro("@DESCR", producto.Descripcion));
            par.Add(con.CrearParametro("@TIPO", producto.Tipo.Id));
            par.Add(con.CrearParametro("@PSTOCK", producto.PuntoStock));
            par.Add(con.CrearParametro("@SKU", producto.SKU));

            Abrir();
            res = con.Escribir("ModificarProducto", par);
            Cerrar();

            return res;
        }

        
        public override int Borrar(BE.Producto producto)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", producto.Codigo));

            Abrir();
            
            res = con.Escribir("BorrarProducto", par);
            
            Cerrar();
            return res;
        }
    }
}
