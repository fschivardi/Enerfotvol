using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Producto : Gestor<BE.Producto>
    {
        public BE.Producto Listar(int cod)
        {
            DAL.Producto mapperUsuario = new DAL.Producto();
            BE.Producto u;
            u = mapperUsuario.Listar(cod);
            return u;
        }

        public override List<BE.Producto> Listar(BE.Producto prod)
        {
            DAL.Producto mapperUsuario = new DAL.Producto();
            List<BE.Producto> ls;
            ls = mapperUsuario.Listar(prod);
            return ls;
        }

        public override List<BE.Producto> Listar()
        {
            DAL.Producto mapperUsuario = new DAL.Producto();
            List<BE.Producto> ls;
            ls = mapperUsuario.Listar();
            return ls;
        }

        public override bool Crear(BE.Producto prod)
        {
            DAL.Producto mapperProducto = new DAL.Producto();            
            if (mapperProducto.Crear(prod) > 0)
            {
                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(prod.Codigo +" - "+ prod.Nombre, 14);
                return true;
            }

            return false;
        }

        public override bool Actualizar(BE.Producto prod)
        {
            DAL.Producto mapperProducto = new DAL.Producto();
            if (mapperProducto.Actualizar(prod) > 0)
            {
                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(prod.Codigo + " - " + prod.Nombre, 16);
                return true;
            }
            return false;
        }

        public override bool Borrar(BE.Producto prod)
        {
            DAL.Producto mapperProducto = new DAL.Producto();
            if (mapperProducto.Borrar(prod) > 0)
            {
                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(prod.Codigo + " - " + prod.Nombre, 15);
                return true;
            }
            return false;
        }
    }
}
