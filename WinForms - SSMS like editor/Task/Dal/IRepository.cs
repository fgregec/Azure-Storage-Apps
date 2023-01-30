using System.Collections.Generic;
using System.Data;
using Task.Models;

namespace Task.Dal
{
    public interface IRepository
    {
        IEnumerable<Column> GetColumns(DBEntity dBEntity);
        IEnumerable<Database> GetDatabases();
        IEnumerable<DBEntity> GetDBEntities(Database database, DBEntityType dBEntity);
        IEnumerable<ProcedureParams> GetParams(Procedure procedure);
        IEnumerable<Procedure> GetProcedures(Database database);
        void LogIn(string server, string username, string password);
        DataSet Execute(string useCommand);
    }
}