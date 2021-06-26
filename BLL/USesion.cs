using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class USesion
    {
        public int Login(string usr, string passenc)
        {
            DAL.Usuario u = new DAL.Usuario();
            BLL.Bitacora bit = new BLL.Bitacora();

            if (u.Listar(usr).Id != "")
            {
                BE.Usuario usuario = new BE.Usuario();
                usuario = u.Listar(usr);
                if (Autenticar(usuario, passenc))
                {
                    if (usuario.Bloqueado && DateTime.Now.Subtract(usuario.UltimoIntentoF) < TimeSpan.FromMinutes(15))
                    {
                        return -1;
                    }
                    else
                    {
                        BE.USesion.GetInstance.UsuarioSesion = usuario;
                        u.ResetearIntentosFallidos(usuario.Id);
                        if (usuario.Bloqueado)
                        {
                            u.BloqueoCuenta(usuario.Id, false);
                        }
                        bit.RegistrarBitacora(usr, 1);
                        return 1;
                    }                    
                }
                else
                {
                    bit.RegistrarBitacora(usr, 11);
                    return 0;
                }                    
            }
            bit.RegistrarBitacora(usr, 11);
            return 0;
        }

        private bool Autenticar(BE.Usuario usr, string pass)
        {
            BLL.Encriptado enc = new BLL.Encriptado();
            if (enc.Encriptar(pass, usr.Salt) == usr.EncPassword)
            {
                return true;
            }
            DAL.Usuario u = new DAL.Usuario();
            if (usr.IntentosF > 2 && usr.Bloqueado==false)
            {
                u.BloqueoCuenta(usr.Id,true);
            }
            u.RegistrarIntentoFallido(usr.Id);
            return false;
        }

        public bool Logout(string usr)
        {
            bool b;
            BLL.Bitacora bit = new BLL.Bitacora();
            if (bit.RegistrarBitacora(usr, 9))
                b = true;
            else
                b = false;

            return b;
        }

        public bool IniciarRecuperoClave(string mail)
        {
            BLL.Usuario negUsuario = new BLL.Usuario();
            BE.Usuario usuario = new BE.Usuario("","","","",mail);
            try
            {
                usuario = negUsuario.Listar(usuario).First();
                string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                long timestamp = DateTime.UtcNow.Ticks;
                BLL.Mailing negMail = new BLL.Mailing();
                negMail.EnviarMail(mail, "Recupero de clave", "Estimado " + usuario.Nombre + " " + usuario.Apellido + ",<br>Haga click en el siguiente enlace para reestablecer su contraseña:<br><a href='https://localhost:44312/ReestablecerClave.aspx?user="+usuario.Id+"&token="+token+ "'>Reestablecer Contraseña</a><br><br><footer>El link posee una validez de una hora, luego de ese plazo deberá iniciar nuevmaente el proceso de recuperación.</footer>");
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool RecuperarClave()
        {
            string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            long timestamp = DateTime.UtcNow.Ticks;
            return true;
        }
    }
}
