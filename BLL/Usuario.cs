using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Usuario : Gestor<BE.Usuario>
    {
        public bool VerificarPermiso(BE.Usuario usr, string pagina)
        {
            if (usr is null || usr.Perfil is null)
                return false;
            foreach (BE.Componente c in usr.Perfil)
            {
                if (pagina.ToUpper() == "~/PAGES/" + c.Permiso.ToUpper()+".ASPX")
                {
                    return true;
                }
            }
            return false;
        }
        public BE.Usuario CargarUsr(string usr)
        {
            var mapperUsuario = new DAL.Usuario();
            BE.Usuario u;
            u = mapperUsuario.Listar(usr);
            return u;
        }

        public override List<BE.Usuario> Listar(BE.Usuario usr)
        {
            var mapperUsuario = new DAL.Usuario();
            List<BE.Usuario> ls;
            ls = mapperUsuario.Listar(usr);
            return ls;
        }

        public override List<BE.Usuario> Listar()
        {
            DAL.Usuario mapperUsuario = new DAL.Usuario();
            List<BE.Usuario> ls;
            ls = mapperUsuario.Listar();
            return ls;
        }

        public override bool Crear(BE.Usuario usr)
        {
            HashearClave(usr);
            DAL.Usuario mapperUsuario = new DAL.Usuario();
            if (mapperUsuario.Crear(usr) > 0)
            {
                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(usr.Id, 10);
                return true;
            }            
            return false;
        }

        public bool CambiarClave(BE.Usuario usr)
        {
            HashearClave(usr);
            DAL.Usuario mapperUsuario = new DAL.Usuario();
            if (mapperUsuario.CambiarClave(usr) > 0)
            {
                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(usr.Id, 2);
                return true;
            }
            return false;
        }

        private void HashearClave(BE.Usuario usr)
        {
            BLL.Encriptado enc = new BLL.Encriptado();
            usr.Salt = enc.GenerarSalt();
            usr.EncPassword = enc.Encriptar(usr.EncPassword, usr.Salt);
        }

        public override bool Actualizar(BE.Usuario usr)
        {
            BLL.DigitoVerificador dgv = new BLL.DigitoVerificador();
            DAL.Usuario mapperUsuario = new DAL.Usuario();
            DAL.Perfil mapperPerfil = new DAL.Perfil();
            for (int i = 0, loopTo = usr.Perfil.Count - 1; i <= loopTo; i++)
            {
                string s;
                s = usr.Id + usr.Perfil[i].Id;
                //usr.Perfil[i].DigitoV.DVH = dgv.CalcDVH(s);
            }

            if (mapperUsuario.Actualizar(usr)>0)
            {
                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(usr.Id, 3);
                return true;
            }

            return false;
        }

        public override bool Borrar(BE.Usuario usr)
        {
            BLL.DigitoVerificador dgv = new BLL.DigitoVerificador();
            
            DAL.Usuario mapperUsuario = new DAL.Usuario();
            if (mapperUsuario.Borrar(usr) > 0)
            {
                BLL.Bitacora negBitacora = new BLL.Bitacora();
                negBitacora.RegistrarBitacora(usr.Id, 4);
                return true;
            }
            
            return false;
        }

        private bool ActualizarPerfil(string idusr, List<BE.Perfil> perfusr)
        {
            BLL.DigitoVerificador dgv = new BLL.DigitoVerificador();
            DAL.Perfil mapperPerfiles = new DAL.Perfil();
            List<BE.Perfil> perfiles = new List<BE.Perfil>();
            List<BE.Perfil> perfilantes = new List<BE.Perfil>();
            perfiles = mapperPerfiles.Listar();
            //perfilantes = mapperPerfiles.ListarPerfilxUsuario(idusr);
            // Perfiles a Asignar
            // Perfiles a Quitar
            dgv.CalcDVH(perfusr);
            dgv.ActualizarDVV("Usuarios_Perfiles");
            return true;
        }
    }
}
