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
    public class ConnectionBase: IConnectionBase
    {
        readonly SqlConnection sqlConnection = new SqlConnection();
        readonly OracleConnection oracleConnection = new OracleConnection();

        private readonly string strSQLConnection = ConfigurationManager.ConnectionStrings["ARQCALCConnectionString"].ConnectionString;
        private readonly string strOracleIBSConnection = ConfigurationManager.ConnectionStrings["ARQCALCConnectionString"].ConnectionString;
        public enum EnumNameDataBase
        {
            ARQCALC,
            bdCobranzas
        }
        public enum EnumTypeDataBase
        {
            SQLDB,
            OracleIBS
        }

        public enum EnumTypeExecute
        {
            ExecuteNonQuery,
            ExecuteReader
        }


        public ConnectionBase()
        {
            sqlConnection.ConnectionString = this.strSQLConnection;
            oracleConnection.ConnectionString = this.strOracleIBSConnection;
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
                    else if (nameDataBaseName == EnumNameDataBase.bdCobranzas)
                    {
                        DataConnection = ChooseDatabaseName(sqlConnection, EnumNameDataBase.bdCobranzas);
                        break;
                    }
                    else
                        break;
                case EnumTypeDataBase.OracleIBS:
                    DataConnection = oracleConnection;
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
                case EnumNameDataBase.bdCobranzas:
                    oSqlConnection.ConnectionString = this.strSQLConnection;
                    break;
                default:
                    break;
            }
            return oSqlConnection;
        }
        public DbDataReader ExecuteByStoredProcedure(string ProcedureName,
                                                    IEnumerable<DbParameter> parameters = null,
                                                    EnumTypeDataBase typeDataBase = EnumTypeDataBase.SQLDB,
                                                    EnumNameDataBase nameDataBaseName = EnumNameDataBase.ARQCALC,
                                                    EnumTypeExecute typeExecute = EnumTypeExecute.ExecuteReader)
        {
            DbConnection DataConnection = GetConnection(typeDataBase, nameDataBaseName);
            DbCommand cmdCommand = DataConnection.CreateCommand();
            cmdCommand.CommandText = ProcedureName;
            cmdCommand.CommandType = CommandType.StoredProcedure;
            cmdCommand.CommandTimeout = 0;

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
        public DbDataReader ExecuteByStoredProcedure(string ProcedureName,
                                                    IEnumerable<DbParameter> parameters = null,
                                                    EnumTypeDataBase typeDataBase = EnumTypeDataBase.OracleIBS,
                                                    EnumTypeExecute typeExecute = EnumTypeExecute.ExecuteReader)
        {
            DbConnection DataConnection = GetConnection(typeDataBase);
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
                if (typeDataBase == EnumTypeDataBase.OracleIBS)
                {
                    if (IsOracleReader(cmdCommand))
                    {
                        myReader = cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    }
                    else { myReader = null; }
                }
                else
                {
                    myReader = null;
                }
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
        private bool IsOracleReader(DbCommand cmdCommand)
        {
            bool isOracleReader = false;
            foreach (DbParameter item in cmdCommand.Parameters)
            {
                if (item is OracleParameter)
                {
                    if ((item as OracleParameter).OracleDbType == OracleDbType.RefCursor)
                    {
                        isOracleReader = true;
                        break;
                    }
                }
            }
            return isOracleReader;
        }
    }
}
