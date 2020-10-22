using ARQCALC.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARQCALC.DAL
{
    public class CalculoDeMaterialesDAL: ICalculoDeMaterialesDAL
    {
        
        public List<CalculoDeMaterialesResult> MatrizCalculo;

        private readonly IConnectionBase _connectionBase;
        //private readonly ConnectionBase _connectionBase;

        public CalculoDeMaterialesDAL(IConnectionBase ConnectionBase)
        {
            _connectionBase = ConnectionBase;
        }

        public CalculoDeMaterialesDAL()
        {
            _connectionBase = new ConnectionBase();
        }

        public List<CalculoDeMaterialesResult> GetMatrizCalculo(int IdSubTipoCalculo )
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdSubTipoCalculo",IdSubTipoCalculo)
            };

            using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("spCalcular_Materiales",
                                                                                               parameters,
                                                                                                ConnectionBase.EnumTypeDataBase.SQLDB,
                                                                                               ConnectionBase.EnumNameDataBase.ARQCALC,
                                                                                               ConnectionBase.EnumTypeExecute.ExecuteReader))
            {
                if (dr != null)
                {
                    int pos_IdSubTipoCalculo = dr.GetOrdinal("IdSubTipoCalculo");
                    int pos_IdMaterial = dr.GetOrdinal("IdMaterial");
                    int pos_NombreMaterial = dr.GetOrdinal("NombreMaterial");
                    int pos_CantidadMaterial = dr.GetOrdinal("CantidadMaterial");
                    int pos_Abreviatura = dr.GetOrdinal("Abreviatura");
                   
                    CalculoDeMaterialesResult oCalculoDeMaterialesResult;
                    MatrizCalculo = new List<CalculoDeMaterialesResult>();

                    while (dr.Read())
                    {
                        oCalculoDeMaterialesResult = new CalculoDeMaterialesResult();
                        oCalculoDeMaterialesResult.IdSubTipoCalculo = dr.GetInt32(pos_IdSubTipoCalculo);
                        oCalculoDeMaterialesResult.IdMaterial = dr.GetInt32(pos_IdMaterial);
                        oCalculoDeMaterialesResult.NombreMaterial = dr.GetString(pos_NombreMaterial);
                        oCalculoDeMaterialesResult.CantidadMaterial= dr.GetDecimal(pos_CantidadMaterial);
                        oCalculoDeMaterialesResult.Abreviatura = dr.GetString(pos_Abreviatura);
                        
                        MatrizCalculo.Add(oCalculoDeMaterialesResult);
                    }
                }

                return MatrizCalculo;
            }
        }

    }
}