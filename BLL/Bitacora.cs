using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Bitacora
    {
        // Método para registrar los eventos que realiza el usuario sobré sí mismo.
        public bool RegistrarBitacora(string obj, int evt)
        {
            BLL.DigitoVerificador dgv = new BLL.DigitoVerificador();
            BE.Bitacora bitac = new BE.Bitacora();
            BE.Evento even = new BE.Evento();
            try
            {
                even.Id = evt;
                even.Descripcion = "";
                bitac.Objeto = obj;
                bitac.Evento = even;
                if (BE.USesion.GetInstance.UsuarioSesion != null)
                {
                    bitac.Autor = BE.USesion.GetInstance.UsuarioSesion.Id;
                }
                else
                {
                    bitac.Autor = "";
                }
                //bitac.DigitoV.DVH = dgv.CalcDVH(bitac);
                DAL.Bitacora btc = new DAL.Bitacora();
                btc.RegistrarBitacora(bitac);
                //dgv.ActualizarDVV("Bitacora");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
        public List<BE.Bitacora> ListarBitacora(BE.Bitacora bitac, DateTime desde, DateTime hasta, int idioma)
        {
            DAL.Bitacora mapperBitacora = new DAL.Bitacora();
            List<BE.Bitacora> ls = new List<BE.Bitacora>();
            ls = mapperBitacora.ListarBitacora(bitac, desde, hasta, idioma);
            return ls;
        }

        public List<BE.Evento> ListarEventos()
        {
            DAL.Bitacora mapperBitacora = new DAL.Bitacora();
            List<BE.Evento> ls = new List<BE.Evento>();
            ls = mapperBitacora.ListarEventos();
            return ls;
        }
    }
}
