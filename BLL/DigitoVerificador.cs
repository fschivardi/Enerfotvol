using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DigitoVerificador
    {

        // *************************************** METODOS QUE CALCULAN ***************************************
        // Calcula el DVH para un determinado Objeto.
        public String CalcDVH(object objeto)
        {
            BLL.Encriptado enc = new BLL.Encriptado();
            string str ="";

            Type myType = objeto.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                if (prop.Name != "DigitoV")
                { 
                String s = str + prop.GetValue(objeto).ToString();

                str = enc.Encriptar(Convert.ToString(s));
                }
                else
                {
                    BE.DigitoVerificador dig = (BE.DigitoVerificador)prop.GetValue(objeto);
                }
            }
                 
            return str;
        }

        // Calcula el Digito Verificador Vertical para una determinada tabla
        private String CalcDVV(string tabla)
        {
            Encriptado enc = new Encriptado();
            String dvv="";
            var lsdvh = new List<String>();
            DAL.DigitoVerificador digver = new DAL.DigitoVerificador();

            lsdvh = digver.TraerDVHfromTabla(tabla);
            
            foreach (String dvh in lsdvh)
            {
                dvv = dvv + dvh;
                dvv = enc.Encriptar(dvv);
            }

            return dvv;
        }


        // *************************************** METODOS QUE ACTUALIZAN ***************************************
        // Actualizar el DVV para una determinada tabla
        public void ActualizarDVV(string tabla)
        {
            var digver = new DAL.DigitoVerificador();
            String DVV;
            DVV = CalcDVV(tabla);
            digver.ActualizarDVV(tabla, DVV);
        }

        // *************************************** VERIFICACION DE INTEGRIDAD ***************************************
        // Verifica Integridad del Sistema
        public bool VerifIntegridad()
        {
            if (VerifIntDVV())
            {
                if (VerifIntDVH())
                {
                    return true;
                }
            }

            return false;
        }

        // Verifica Integridad del Dígito Verificador Vertical
        private bool VerifIntDVV()
        {
            var listablas = new List<BE.DigitoVerificador>();
            var digver = new DAL.DigitoVerificador();
            listablas = digver.Listar();
            foreach (BE.DigitoVerificador tabla in listablas)
            {
                String i;
                i = CalcDVV(tabla.Tabla);
                if (!(i == tabla.DVV))
                {
                    return false;
                }
            }

            return true;
        }

        // Verifica Integridad del Dígito Verificador Horizontal
        private bool VerifIntDVH()
        {
            var usr = new DAL.Usuario();
            var bit = new DAL.Bitacora();
            var per = new DAL.Perfil();
            if (!VerifIntDVHObjeto(usr.Listar()))
                return false;
            if (!VerifIntDVHObjeto(bit.ListarBitacora()))
                return false;
            if (!VerifIntDVHObjeto(per.Listar()))
                return false;
            return true;
        }

        //Verifica Integridad del un determinado Objeto
        private bool VerifIntDVHObjeto(object objeto)
        {

            Encriptado enc = new Encriptado();

            Type myType = objeto.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                String dvh;
                dvh = CalcDVH(prop);
                if (dvh == objeto.GetType().GetProperty("DVH").GetValue(objeto, null).ToString())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
