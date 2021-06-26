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
    public class Perfil : Mapper<BE.Perfil>
    {
        public Perfil()
        {
            con = new Acceso();
            conpropia = true;
        }

        internal Perfil(Acceso ac)
        {
            con = ac;
            conpropia = false;
        }

        public void FillUserComponents(BE.Usuario u)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", u.Id));
            Abrir();
            dt = con.Leer("ListarPerfilesXUsuario", par);
            Cerrar();
            List<BE.Componente> lista = new List<BE.Componente>();
            
            u.Perfil.Clear();

            foreach (DataRow r in dt.Rows)
            {
                var idp = Convert.ToInt32(r["Id_Perfil"]);
                var nombrep = r["Nombre"].ToString();

                var permisop = String.Empty;
                if (r["Permiso"] != DBNull.Value)
                    permisop = r["Permiso"].ToString();

                BE.Componente c1;
                if (!String.IsNullOrEmpty(permisop))
                {
                    c1 = new BE.Permiso();
                    c1.Id = idp;
                    c1.Descripcion = nombrep;
                    c1.Permiso = permisop;
                    u.Perfil.Add(c1);
                }
                else
                {
                    c1 = new BE.Perfil();
                    c1.Id = idp;
                    c1.Descripcion = nombrep;

                    var f = GetAll(idp);

                    foreach (var familia in f)
                    {
                        c1.AgregarHijo(familia);
                    }
                    u.Perfil.Add(c1);
                }
            }

            
            
        }

        private BE.Componente GetComponent(int id, IList<BE.Componente> lista)
        {
            BE.Componente component = lista != null ? lista.Where(i => i.Id.Equals(id)).FirstOrDefault() : null;

            if (component == null && lista != null)
            {
                foreach (var c in lista)
                {
                    var l = GetComponent(id, c.Hijos);
                    if (l != null && l.Id == id) return l;
                    else
                    if (l != null)
                        return GetComponent(id, l.Hijos);
                }
            }

            return component;
        }

        public IList<BE.Componente> GetAll(int familia)
        {
            DataTable dt = new DataTable();
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@IDPERFIL", familia));
            Abrir();
            dt = con.Leer("ListarPerfilesXPerfil", par);
            Cerrar();

            var lista = new List<BE.Componente>();

            foreach (DataRow r in dt.Rows)
            {
                int id_padre = 0;
                if (r["Id_PerfilPadre"] != DBNull.Value)
                {
                    id_padre = Convert.ToInt32(r["Id_PerfilPadre"]);
                }

                var id = Convert.ToInt32(r["Id_Perfil"]);
                var nombre = r["Nombre"].ToString();

                var permiso = string.Empty;
                if (r["permiso"] != DBNull.Value)
                    permiso = r["Permiso"].ToString();

                BE.Componente c;

                if (string.IsNullOrEmpty(permiso))
                    c = new BE.Perfil();

                else
                    c = new BE.Permiso();

                c.Id = id;
                c.Descripcion = nombre;
                if (!string.IsNullOrEmpty(permiso))
                    c.Permiso = permiso;

                var padre = GetComponent(id_padre, lista);

                if (padre == null)
                {
                    lista.Add(c);
                }
                else
                {
                    padre.AgregarHijo(c);
                }
            }

            return lista;
        }

        public void FillFamilyComponents(BE.Perfil perfil)
        {
            perfil.VaciarHijos();
            foreach (var item in GetAll(perfil.Id))
            {
                perfil.AgregarHijo(item);
            }
        }

        public override List<BE.Perfil> Listar()
        {
            DataTable dt = new DataTable();
            Abrir();
            dt = con.Leer("ListarPerfiles");
            Cerrar();
            List<BE.Perfil> ls = new List<BE.Perfil>();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                var r = new BE.Perfil();
                r.Id = Convert.ToInt32(dt.Rows[n]["Id_Perfil"]);
                r.Descripcion = Convert.ToString(dt.Rows[n]["Nombre"]);

                ls.Add(r);
            }

            return ls;
        }

        public List<BE.Permiso> ListarControles()
        {
            DataTable dt = new DataTable();
            Abrir();
            dt = con.Leer("ListarPermisos");
            Cerrar();
            List<BE.Permiso> ls = new List<BE.Permiso>();
            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                var r = new BE.Permiso();
                r.Id = Convert.ToInt32(dt.Rows[n]["Id_Perfil"]);
                r.Descripcion = Convert.ToString(dt.Rows[n]["Nombre"]);
                r.Permiso = Convert.ToString(dt.Rows[n]["Permiso"]);

                ls.Add(r);
            }

            return ls;
        }

        public override int Crear(BE.Perfil perf)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            Abrir();
            con.IniciarTransaccion();
            perf.Id = CalcIdPerfil();
            par.Add(con.CrearParametro("@ID", perf.Id));
            par.Add(con.CrearParametro("@NOM", perf.Descripcion));
            par.Add(con.CrearParametro("@DVH", "123"));
            res = con.Escribir("CrearPerfil", par);
            if (res > 0)
            {
                foreach (BE.Componente c in perf.Hijos)
                {
                    if (!AgregarPerfil(perf.Id, c.Id))
                    {
                        con.DeshacerTransaccion();
                        return -1;
                    }
                }
            }
            else
            {
                con.DeshacerTransaccion();
                return -1;
            }
            con.ConfirmarTransaccion();            
            Cerrar();

            return res;
        }

        public override int Borrar(BE.Perfil perf)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@ID", perf.Id));

            Abrir();
            res = con.Escribir("BorrarPerfil", par);
            Cerrar();

            return res;
        }

        public override int Actualizar(BE.Perfil perf)
        {
            int res = 0;                       
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@IDPERF", perf.Id));
            par.Add(con.CrearParametro("@NOM", perf.Descripcion));
            
            Abrir();
            con.IniciarTransaccion();
            int r = con.Escribir("ModificarPerfil", par);
            if (r > 0)
            {
                res = res + r;
                if (QuitarPerfil(perf))
                {
                    foreach (BE.Componente c in perf.Hijos)
                    {
                        if (!AgregarPerfil(perf.Id, c.Id))
                        {
                            con.DeshacerTransaccion();
                            return -1;
                        }
                    }
                }
                else
                {
                    con.DeshacerTransaccion();
                    return -1;
                }
            }
            else
            {
                con.DeshacerTransaccion();
                Cerrar();
                return -1;
            }            

            con.ConfirmarTransaccion();
            Cerrar();

            return res;
        }

        private bool AgregarPerfil(int idp, int idh)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@IDP", idp));
            par.Add(con.CrearParametro("@IDH", idh));
            
            res = con.Escribir("AgregarPerfil", par);
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

        private bool QuitarPerfil(BE.Perfil perf)
        {
            int res;
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@IDPER", perf.Id));

            res = con.Escribir("QuitarPerfil", par);

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

        public int CalcIdPerfil()
        {            
            var dt = new DataTable();
            dt = con.Leer("CalcIdPerfil");
            int i = Convert.ToInt32(dt.Rows[0]["Id_Perfil"]);            
            return i;
        }

        public void ListarPermisosxUsuario(BE.Usuario usr)
        {
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", usr.Id));
            
            Abrir();
            DataTable dt = con.Leer("ListarPermisosXUsuario", par);
            Cerrar();

            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                BE.Permiso c = new BE.Permiso();

                c.Id = Convert.ToInt32(dt.Rows[n]["Id_Perfil"]);
                c.Permiso = Convert.ToString(dt.Rows[n]["Permiso"]);
                c.Descripcion = Convert.ToString(dt.Rows[n]["Nombre"]);

                usr.Perfil.Add(c);
            }            
        }

        public void ListarPerfilxUsuario(BE.Usuario usr)
        {
            List<SqlParameter> par = new List<SqlParameter>();
            par.Add(con.CrearParametro("@USUARIO", usr.Id));

            Abrir();
            DataTable dt = con.Leer("ListarPerfilesXUsuario", par);
            Cerrar();

            for (int n = 0, loopTo = dt.Rows.Count - 1; n <= loopTo; n++)
            {
                BE.Perfil p = new BE.Perfil();
                BE.Permiso c = new BE.Permiso();

                c.Id = Convert.ToInt32(dt.Rows[n]["Id_Perfil"]);
                c.Permiso = Convert.ToString(dt.Rows[n]["Permiso"]);
                c.Descripcion = Convert.ToString(dt.Rows[n]["Nombre"]);

                p.AgregarHijo(c);
                usr.Perfil.Add(p);
            }
        }
    }
}
