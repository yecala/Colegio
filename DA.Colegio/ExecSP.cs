using Insight.Database;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DA.Colegio
{
    public class ExecSP<T>
    {
        SqlConnectionStringBuilder dataBase;

        public ExecSP() 
        {
            dataBase = new SqlConnectionStringBuilder("Server=JESSICA;Database=db_Colegio;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public List<T> Exec(string spNombre, object parametros = null)
        {
            return dataBase.Connection().Query<T>(spNombre, parametros) as List<T>;
        }

        public void ExecAsync(string spNombre, object parametros)
        {
            dataBase.Connection().Execute(spNombre, parametros);
        }

        public T ExecFirst(string spNombre, object parametros = null)
        {
            return dataBase.Connection().Query<T>(spNombre, parametros, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

    }
}
