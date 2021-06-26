using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Usuario:Mapper<BE.Usuario>
    {
        public Usuario()
        {
            con = new Acceso();
            conpropia = true;
        }

        internal Usuario(Acceso ac)
        {
            con = ac;
            conpropia = false;
        }
        public override List<BE.Usuario> Listar()
        {            
            DataTable dt = new DataTable();
            List<BE.Usuario> ls = new List<BE.Usuario>();

            Abrir();
            dt = con.Leer("CargarUsuario");
            Cerrar();

            
            Perfil per = new Perfil();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                BE.Usuario r = new BE.Usuario();
                r.Id = Convert.ToString(dt.Rows[n]["Id_Usuario"]);
                r.Nombre = Convert.ToString(dt.Rows[n]["Nombre"]);
                r.Apellido = Convert.ToString(dt.Rows[n]["Apellido"]);
                r.Mail = Convert.ToString(dt.Rows[n]["Mail"]);
                r.EncPassword = Convert.ToString(dt.Rows[n]["Clave"]);
                r.Salt = Convert.ToString(dt.Rows[n]["Salt"]);
                var ul = new DateTime(Convert.ToInt64(dt.Rows[n]["UltimoLogin"]));
                r.UltimoLogin = ul;
                var uf = new DateTime(Convert.ToInt64(dt.Rows[n]["UltimoIntentoF"]));
                r.UltimoIntentoF = uf;
                r.IntentosF = Convert.ToInt32(dt.Rows[n]["CantIntentosF"]);
                r.Bloqueado = Convert.ToBoolean(dt.Rows[n]["Bloqueado"]);
                r.Estado = Convert.ToBoolean(dt.Rows[n]["Estado"]);
                per.ListarPerfilxUsuario(r);
                ls.Add(r);
            }

            return ls;
        }

        public BE.Usuario Listar(string u)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", u));

            Abrir();
            dt = con.Leer("CargarUsuario", par);
            Cerrar();

            BE.Usuario usr = new BE.Usuario();
            Perfil per = new Perfil();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                usr.Id = Convert.ToString(dt.Rows[n]["Id_Usuario"]);
                usr.Nombre = Convert.ToString(dt.Rows[n]["Nombre"]);
                usr.Apellido = Convert.ToString(dt.Rows[n]["Apellido"]);
                usr.Mail = Convert.ToString(dt.Rows[n]["Mail"]);
                usr.EncPassword = Convert.ToString(dt.Rows[n]["Clave"]);
                usr.Salt = Convert.ToString(dt.Rows[n]["Salt"]);
                var ul = new DateTime(Convert.ToInt64(dt.Rows[n]["UltimoLogin"]));
                usr.UltimoLogin = ul;
                var uf = new DateTime(Convert.ToInt64(dt.Rows[n]["UltimoIntentoF"]));
                usr.UltimoIntentoF = uf;
                usr.IntentosF = Convert.ToInt32(dt.Rows[n]["CantIntentosF"]);
                usr.Bloqueado = Convert.ToBoolean(dt.Rows[n]["Bloqueado"]);
                usr.Estado = Convert.ToBoolean(dt.Rows[n]["Estado"]);
            }
            per.ListarPermisosxUsuario(usr);

            return usr;
        }

        public List<BE.Usuario> Listar(BE.Usuario usr)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", usr.Id));
            par.Add(con.CrearParametro("@NOMBRE", usr.Nombre));
            par.Add(con.CrearParametro("@APELLIDO", usr.Apellido));
            par.Add(con.CrearParametro("@MAIL", usr.Mail));

            Abrir();
            dt = con.Leer("ListarUsuarios", par);
            Cerrar();

            List<BE.Usuario> ls = new List<BE.Usuario>();
            Perfil per = new Perfil();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                BE.Usuario u = new BE.Usuario();
                u.Id = Convert.ToString(dt.Rows[n]["Id_Usuario"]);
                u.Nombre = Convert.ToString(dt.Rows[n]["Nombre"]);
                u.Apellido = Convert.ToString(dt.Rows[n]["Apellido"]);
                u.Mail = Convert.ToString(dt.Rows[n]["Mail"]);
                u.EncPassword = Convert.ToString(dt.Rows[n]["Clave"]);
                u.Salt = Convert.ToString(dt.Rows[n]["Salt"]);
                var ul = new DateTime(Convert.ToInt64(dt.Rows[n]["UltimoLogin"]));
                u.UltimoLogin = ul;
                var uf = new DateTime(Convert.ToInt64(dt.Rows[n]["UltimoIntentoF"]));
                u.UltimoIntentoF = uf;
                u.IntentosF = Convert.ToInt32(dt.Rows[n]["CantIntentosF"]);
                u.Bloqueado = Convert.ToBoolean(dt.Rows[n]["Bloqueado"]);
                u.Estado = Convert.ToBoolean(dt.Rows[n]["Estado"]);
                ls.Add(u);
            }

            return ls;
        }

        //public bool Login(string usuario, string passwordenc)
        //{            
        //    DataTable dt = new DataTable();
        //    List<SqlParameter> par = new List<SqlParameter>();
        //    par.Add(con.CrearParametro("@USUARIO", usuario));
        //    par.Add(con.CrearParametro("@PASS", passwordenc));

        //    Abrir();
        //    dt = con.Leer("ValidarLogin", par);
        //    Cerrar();

        //    if (dt.Rows.Count > 0)
        //    {
        //        ResetearIntentosFallidos(usuario);
        //        return true;
        //    }
                        
        //    return false;
        //}

        public bool RegistrarIntentoFallido(string usuario)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", usuario));
            par.Add(con.CrearParametro("@FECHAHORA", DateTime.Now.Ticks));

            Abrir();
            res = con.Escribir("RegistrarIntentoFallido", par);
            Cerrar();

            if (res > 0)
            {
                return true;
            }

            return false;
        }

        public bool ResetearIntentosFallidos(string usuario)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", usuario));
            par.Add(con.CrearParametro("@FECHAHORA", DateTime.Now.Ticks));

            Abrir();
            res = con.Escribir("ResetearIntentosFallidos", par);
            Cerrar();

            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public bool BloqueoCuenta(string usuario,bool estado)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", usuario));
            par.Add(con.CrearParametro("@ESTADO", estado));

            Abrir();
            res = con.Escribir("BloqueoCuenta", par);
            Cerrar();

            if (res > 0)
            {
                return true;
            }
            return false;
        }

        public override int Crear(BE.Usuario usuario)
        {
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", usuario.Id));
            par.Add(con.CrearParametro("@NOMBRE", usuario.Nombre));
            par.Add(con.CrearParametro("@APELLIDO", usuario.Apellido));
            par.Add(con.CrearParametro("@DESCR", usuario.Descripcion));
            par.Add(con.CrearParametro("@MAIL", usuario.Mail));
            par.Add(con.CrearParametro("@ULTIMOLOGIN", usuario.UltimoLogin.Ticks));
            par.Add(con.CrearParametro("@ULTIMOINTENTOF", usuario.UltimoIntentoF.Ticks));
            par.Add(con.CrearParametro("@INTENTOSF", usuario.IntentosF));
            par.Add(con.CrearParametro("@CLAVE", usuario.EncPassword));
            par.Add(con.CrearParametro("@SALT", usuario.Salt));
            
            Abrir();
            con.IniciarTransaccion();
            int res = con.Escribir("CrearUsuario", par);
            foreach (BE.Componente p in usuario.Perfil)
                if (!AgregarPerfil(usuario.Id, p.Id)) {
                    con.DeshacerTransaccion();
                    return -1;
                }

            con.ConfirmarTransaccion();
            Cerrar();

            return res;
        }

        public override int Actualizar(BE.Usuario usuario)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", usuario.Id));
            par.Add(con.CrearParametro("@NOMBRE", usuario.Nombre));
            par.Add(con.CrearParametro("@APELLIDO", usuario.Apellido));

            Abrir();
            con.IniciarTransaccion();
            
            if (usuario.EncPassword == "")
            {
                res = con.Escribir("ModifUsuario", par);
            } else
            {
                par.Add(con.CrearParametro("@CLAVE", usuario.EncPassword));
                
                res = con.Escribir("ModifUsuarioConPass", par);
            }
            if (!QuitarPerfil(usuario.Id)) {
                con.DeshacerTransaccion();
                return -1;
            }
            foreach (BE.Componente p in usuario.Perfil)
                if (!AgregarPerfil(usuario.Id, p.Id))
                {
                    con.DeshacerTransaccion();
                    return -1;
                }                                    

            con.ConfirmarTransaccion();
            Cerrar();

            return res;
        }

        public int CambiarClave(BE.Usuario usuario)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", usuario.Id));
            par.Add(con.CrearParametro("@CLAVE", usuario.EncPassword));
            par.Add(con.CrearParametro("@SALT", usuario.Salt));

            Abrir();
            res = con.Escribir("CambiarClaveUsuario", par);
            Cerrar();

            return res;
        }

        public override int Borrar(BE.Usuario usuario)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", usuario.Id));

            Abrir();
            con.IniciarTransaccion();
            res = con.Escribir("BorrarUsuario", par);
            if (res > 0)
            {
                if (usuario.Perfil.Count > 0)
                {
                    if (!QuitarPerfil(usuario.Id))
                    {
                        con.DeshacerTransaccion();
                        Cerrar();
                        return -1;
                    }
                }
            }
            con.ConfirmarTransaccion();
            Cerrar();
            return res;
        }

        private bool AgregarPerfil(string idusr, int idperf)
        {            
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@IDUSR", idusr));
            par.Add(con.CrearParametro("@IDPERF", idperf));
            res = con.Escribir("AgregarPerfilUsuario", par);
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

        private bool QuitarPerfil(string idusr)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@IDUSR", idusr));
            
            res = con.Escribir("QuitarPerfilUsuario", par);
            
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
    }
}
