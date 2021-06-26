using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Backup
    {
        private string db = "master";

        public bool RealizarBackup(string directorio)
        {
            var con = new Acceso();
            try
            {
                var sCmd = new StringBuilder();
                sCmd.Append("BACKUP DATABASE [CENTROSALUDcs] TO  DISK = N'" + directorio + @"\BKP_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Minute.ToString() + ".sql' ");
                sCmd.Append("WITH DESCRIPTION = N'RESTORE', NOFORMAT, NOINIT, ");
                sCmd.Append("NAME = N'BKP_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Minute.ToString() + "', SKIP, NOREWIND, NOUNLOAD,  STATS = 10");
                if (con.EscribirSQL(sCmd.ToString()))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RealizarRestore(string File)
        {
            var con = new Acceso();
            var sCmd = new StringBuilder();
            try
            {
                // sCmd.Append("RESTORE DATABASE [ServicioTecnico] FROM DISK='" & File & "'")
                // sCmd.Append("USE master ALTER DATABASE ServicioTecnico SET SINGLE_USER WITH ROLLBACK IMMEDIATE  RESTORE DATABASE ServicioTecnico FROM DISK = '" & File & "' ALTER DATABASE Student SET MULTI_USER ;")
                // Chequear el uso del SET OFFLINE
                sCmd.Append("USE master ALTER DATABASE [CENTROSALUDcs] SET SINGLE_USER WITH ROLLBACK IMMEDIATE  RESTORE DATABASE [CENTROSALUDcs] FROM DISK = '" + File + "' WITH REPLACE ALTER DATABASE CENTROSALUDcs SET MULTI_USER ;");
                if (con.EscribirSQL(sCmd.ToString()))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
