using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace ARQCALC.DAL
{
    public class ConnectionBase //: IConnectionBase
    {
        public SqlConnection sqlConnection;
        private readonly string strSQLConnection = ConfigurationManager.ConnectionStrings["ARQCALCConnectionString"].ConnectionString;
        private readonly string strSQLCobranzasConnection = ConfigurationManager.ConnectionStrings["ARQCALCConnectionString"].ConnectionString;

        public enum EnumNameDataBase
        {
            ARQCALC,
            OTRA
        }
        public enum EnumTypeDataBase
        {
            SQLDB,
            ORACLEDB
        }

        public enum EnumTypeExecute
        {
            ExecuteNonQuery,
            ExecuteReader
        }


        public ConnectionBase()
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = this.strSQLConnection;
        }

        public DbParameterCollection ParamsCollectionResult { get; set; }

        public DbConnection GetConnection(EnumTypeDataBase typeDataBase = EnumTypeDataBase.SQLDB,
                                          EnumNameDataBase nameDataBaseName = EnumNameDataBase.ARQCALC)
        {
            DbConnection DataConnection = null;
            switch (typeDataBase)
            {
                case EnumTypeDataBase.SQLDB:
                    if (nameDataBaseName == EnumNameDataBase.ARQCALC)
                    {
                        DataConnection = ChooseDatabaseName(sqlConnection, EnumNameDataBase.ARQCALC);
                        break;
                    }
                    else if (nameDataBaseName == EnumNameDataBase.OTRA)
                    {
                        DataConnection = ChooseDatabaseName(sqlConnection, EnumNameDataBase.OTRA);
                        break;
                    }
                    else
                        break;
                case EnumTypeDataBase.ORACLEDB:
                    break;
                default:
                    break;
            }
            return DataConnection;
        }
        public DbConnection ChooseDatabaseName(SqlConnection oSqlConnection,
                                               EnumNameDataBase nameDataBaseName = EnumNameDataBase.ARQCALC)
        {
            switch (nameDataBaseName)
            {
                case EnumNameDataBase.ARQCALC:
                    oSqlConnection.ConnectionString = this.strSQLConnection;
                    break;
                case EnumNameDataBase.OTRA:
                    oSqlConnection.ConnectionString = this.strSQLCobranzasConnection;
                    break;
                default:
                    break;
            }
            return oSqlConnection;
        }
        public DbDataReader ExecuteByStoredProcedure(string ProcedureName,
                                                    IEnumerable<DbParameter> parameters = null,
                                                    EnumTypeDataBase typeDataBase = EnumTypeDataBase.SQLDB,
                                                    EnumNameDataBase nameDataBase = EnumNameDataBase.ARQCALC,
                                                    EnumTypeExecute typeExecute = EnumTypeExecute.ExecuteReader)
        {
            DbConnection DataConnection = GetConnection(typeDataBase, nameDataBase);
            DbCommand cmdCommand = DataConnection.CreateCommand();
            cmdCommand.CommandText = ProcedureName;
            cmdCommand.CommandType = CommandType.StoredProcedure;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    cmdCommand.Parameters.Add(parameter);
                }
            }

            DataConnection.Open();
            DbDataReader myReader;

            if (typeExecute == EnumTypeExecute.ExecuteReader)
            {
                myReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            else
            {
                cmdCommand.ExecuteNonQuery();
                ParamsCollectionResult = cmdCommand.Parameters;
                cmdCommand.Connection.Close();
                myReader = null;
            }

            return myReader;
        }
    }
}
