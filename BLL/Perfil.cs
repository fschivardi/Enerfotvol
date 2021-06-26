using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Perfil : Gestor<BE.Perfil>
    {
        public override List<BE.Perfil> Listar(BE.Perfil per)
        {
            var mapperPerfil = new DAL.Perfil();
            List<BE.Perfil> ls;            
            ls = mapperPerfil.Listar();
            foreach (BE.Perfil p in ls)           
                FillFamilyComponents(p);            
            return ls;
        }

        public override List<BE.Perfil> Listar()
        {
            var mapperUsuario = new DAL.Perfil();
            List<BE.Perfil> ls;
            ls = mapperUsuario.Listar();
            foreach (BE.Perfil p in ls)
                FillFamilyComponents(p);
            return ls;
        }

        public List<BE.Permiso> ListarControles()
        {
            var mapperUsuario = new DAL.Perfil();
            List<BE.Permiso> ls;
            ls = mapperUsuario.ListarControles();
            return ls;
        }

        public bool Existe(BE.Componente c, BE.Usuario u)
        {
            foreach (var item in u.Perfil)
            {
                if (Existe(item, c.Id))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Existe(BE.Componente c, BE.Perfil p)
        {
            foreach (var item in p.Hijos)
            {
                if (Existe(item, c.Id))
                {
                    return true;
                }
            }
            return false;
        }

        private bool Existe(BE.Componente c, int id)
        {
            bool existe = false;

            if (c.Id.Equals(id))
                existe = true;
            else

                foreach (var item in c.Hijos)
                {

                    existe = Existe(item, id);
                    if (existe) return true;
                }

            return existe;

        }

        public override bool Crear(BE.Perfil per)
        {
            BLL.DigitoVerificador dgv = new BLL.DigitoVerificador();
            var mapperPerfil = new DAL.Perfil();
            if (mapperPerfil.Crear(per) > 0)            
                return true;            

            return false;
        }

        public override bool Actualizar(BE.Perfil per)
        {
            BLL.DigitoVerificador dgv = new BLL.DigitoVerificador();
            DAL.Perfil mapperPerfil = new DAL.Perfil();

            if (mapperPerfil.Actualizar(per) > 0)
            {

                return true;
            }

            return false;
        }

        public override bool Borrar(BE.Perfil per)
        {
            BLL.DigitoVerificador dgv = new BLL.DigitoVerificador();
            DAL.Perfil mapperPerfil = new DAL.Perfil();
            if (mapperPerfil.Borrar(per) > 0)
            {
                return true;
            }

            return false;
        }

        public void FillUserComponents(BE.Usuario u)
        {
            DAL.Perfil mapperPerfil = new DAL.Perfil();
            mapperPerfil.FillUserComponents(u);

        }

        public void FillFamilyComponents(BE.Perfil perfil)
        {
            DAL.Perfil mapperPerfil = new DAL.Perfil();
            mapperPerfil.FillFamilyComponents(perfil);

        }

    }
}
