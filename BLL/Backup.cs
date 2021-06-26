using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Backup
    {
        public bool HacerBKP(string directorio)
        {
            BLL.Bitacora bit = new BLL.Bitacora();
            bit.RegistrarBitacora(directorio, 12);
            DAL.Backup mapperBKP = new DAL.Backup();
            bool b = mapperBKP.RealizarBackup(directorio);            
            return b;
        }

        public bool HacerRestore(string file)
        {
            DAL.Backup mapperBKP = new DAL.Backup();
            bool b = mapperBKP.RealizarRestore(file);
            BLL.Bitacora bit = new BLL.Bitacora();
            bit.RegistrarBitacora(file, 13);
            return b;
        }
    }
}
