using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TipoProducto : Gestor<BE.TipoProducto>
    {
        public BE.TipoProducto Listar(int id)
        {
            DAL.TipoProducto mapperTipoProducto = new DAL.TipoProducto();
            BE.TipoProducto u;
            u = mapperTipoProducto.Listar(id);
            return u;
        }

        public override List<BE.TipoProducto> Listar(BE.TipoProducto tipoprod)
        {
            DAL.TipoProducto mapperTipoProducto = new DAL.TipoProducto();
            List<BE.TipoProducto> ls;
            ls = mapperTipoProducto.Listar();
            return ls;
        }

        public override List<BE.TipoProducto> Listar()
        {
            DAL.TipoProducto mapperTipoProducto = new DAL.TipoProducto();
            List<BE.TipoProducto> ls;
            ls = mapperTipoProducto.Listar();
            return ls;
        }

        public override bool Crear(BE.TipoProducto tipoprod)
        {
            DAL.TipoProducto mapperTipoProducto = new DAL.TipoProducto();
            if (mapperTipoProducto.Crear(tipoprod) > 0)
            {
                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(tipoprod.Id.ToString()+" - "+tipoprod.Descripcion, 17);
                return true;
            }

            return false;
        }

        public override bool Actualizar(BE.TipoProducto tipoprod)
        {
            DAL.TipoProducto mapperTipoProducto = new DAL.TipoProducto();
            if (mapperTipoProducto.Actualizar(tipoprod) > 0)
            {
                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(tipoprod.Id.ToString() + " - " + tipoprod.Descripcion, 19);
                return true;
            }
            return false;
        }

        public override bool Borrar(BE.TipoProducto tipoprod)
        {
            DAL.TipoProducto mapperTipoProducto = new DAL.TipoProducto();
            if (mapperTipoProducto.Borrar(tipoprod) > 0)
            {

                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(tipoprod.Id.ToString() + " - " + tipoprod.Descripcion, 20);
                return true;
            }
            return false;
        }
    }
}

