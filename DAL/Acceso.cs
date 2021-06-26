using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    internal class Acceso
    {
        private SqlConnection cn;

        private SqlTransaction tx;

        public void Abrir()
        {
            cn = new SqlConnection();
            cn.ConnectionString = @"Server=tcp:kiwysrv01.database.windows.net,1433;Initial Catalog=kiwyDB;Persist Security Info=False;User ID=admin_kiwysrv01;Password=H6Pv2lzeULp70jBsA&c439NB;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //cn.ConnectionString = @"Data Source=.\SQL_UAI;Initial Catalog=ENERFOTVOL;Integrated Security=SSPI";
            cn.Open();
        }

        public void Cerrar()
        {
            cn.Close();
            cn.Dispose();
            cn = null;
            GC.Collect();
        }

        public void IniciarTransaccion()
        {
            tx = cn.BeginTransaction();
        }

        public void ConfirmarTransaccion()
        {
            tx.Commit();
        }

        public void DeshacerTransaccion()
        {
            tx.Rollback();
        }

        public DataTable Leer(string nom, List<SqlParameter> par = null)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = CrearComando(nom, par);
            
            da.Fill(dt);
            
            return dt;
        }

        public int Escribir(string nom, List<SqlParameter> par)
        {
            SqlCommand cm = CrearComando(nom, par);

            int i;
            try
            {
                i = cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                i = -1;
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", "-------------------------------------------------------------");
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Environment.NewLine);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Convert.ToString(DateTime.Now.TimeOfDay) + " - " + ex.Message);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Environment.NewLine);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", ex.StackTrace);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Environment.NewLine);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", "-------------------------------------------------------------");
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Environment.NewLine);
            }

            cm.Parameters.Clear();
            cm.Dispose();
            cm = null;
            GC.Collect();
            
            return i;
        }

        public DataTable LeerSQL(string nom)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.CommandText = nom;
            Abrir();
            da.SelectCommand.Connection = cn;
            da.Fill(dt);
            Cerrar();
            return dt;
        }
        public bool EscribirSQL(string nom)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandType = CommandType.Text;
            cm.CommandText = nom;
            Abrir();
            cm.Connection = cn;
            bool i;
            try
            {
                cm.ExecuteNonQuery();
                i = true;
            }
            catch (Exception ex)
            {
                i = false;
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", "-------------------------------------------------------------");
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Environment.NewLine);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Convert.ToString(DateTime.Now.TimeOfDay) + " - " + ex.Message);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Environment.NewLine);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", ex.StackTrace);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Environment.NewLine);
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", "-------------------------------------------------------------");
                System.IO.File.AppendAllText("%TMP%\\ENERFOTVOL_error.log", Environment.NewLine);
            }

            Cerrar();
            return i;
        }

        private SqlCommand CrearComando(string nombre, List<SqlParameter> parametros = null)
        {
            SqlCommand cm = new SqlCommand();
            cm.CommandText = nombre;
            cm.CommandType = CommandType.StoredProcedure;
            cm.Connection = cn;
            if (tx != null)
            {
                cm.Transaction = tx;
            }


            if (parametros != null && parametros.Count > 0)
            {
                cm.Parameters.AddRange(parametros.ToArray());
            }
            return cm;
        }

        public SqlParameter CrearParametro(string nom, string val)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.String;
            p.ParameterName = nom;
            p.Value = val;
            return p;
        }

        public SqlParameter CrearParametro(string nom, int val)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.ParameterName = nom;
            p.Value = val;
            return p;
        }

        public SqlParameter CrearParametro(string nom, double val)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Double;
            p.ParameterName = nom;
            p.Value = val;
            return p;
        }
        public SqlParameter CrearParametro(string nom, bool val)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Boolean;
            p.ParameterName = nom;
            p.Value = val;
            return p;
        }
        public SqlParameter CrearParametro(string nom, DateTime val)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.DateTime;
            p.ParameterName = nom;
            p.Value = val;
            return p;
        }

        public SqlParameter CrearParametro(string nom, TimeSpan val)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Time;
            p.ParameterName = nom;
            p.Value = val.ToString();
            return p;
        }
        public SqlParameter CrearParametro(string nom, long val)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int64;
            p.ParameterName = nom;
            p.Value = val.ToString();
            return p;
        }
        public SqlParameter CrearParametro(string nom, DBNull val)
        {
            SqlParameter p = new SqlParameter(nom, DBNull.Value);
            return p;
        }
    }

}
