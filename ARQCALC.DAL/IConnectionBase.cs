using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace ARQCALC.DAL
{
    public interface IConnectionBase
    {
        DbConnection GetConnection(ConnectionBase.EnumTypeDataBase typeDataBase = ConnectionBase.EnumTypeDataBase.SQLDB,
                                   ConnectionBase.EnumNameDataBase nameDataBaseName = ConnectionBase.EnumNameDataBase.ARQCALC);

        DbParameterCollection ParamsCollectionResult { get; set; }

        DbDataReader ExecuteByStoredProcedure(string ProcedureName,
                                              IEnumerable<DbParameter> parameters = null,
                                              ConnectionBase.EnumTypeDataBase typeDataBase = ConnectionBase.EnumTypeDataBase.SQLDB,
                                              ConnectionBase.EnumNameDataBase nameDataBaseName = ConnectionBase.EnumNameDataBase.ARQCALC,
                                              ConnectionBase.EnumTypeExecute typeExecute = ConnectionBase.EnumTypeExecute.ExecuteReader);
    }

}
