using System.Collections.Generic;
using System.Data.SqlClient;

namespace ARQCALC.DAL.SubTiposCalculos
{
    public class SubTiposCalculosDAL: ISubTiposCalculosDAL
    {
        private readonly IConnectionBase _connectionBase;
        
        public SubTiposCalculosDAL(IConnectionBase ConnectionBase)
        {
            _connectionBase = ConnectionBase;
        }

        public SubTiposCalculosDAL()
        {
            _connectionBase = new ConnectionBase();
        }

        public List<ARQCALC.Entidades.SubTiposCalculos> Get(int? IdSubTipoCalculo = null)
        {
            List<ARQCALC.Entidades.SubTiposCalculos> Lista = new List<Entidades.SubTiposCalculos>();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdSubTipoCalculo",IdSubTipoCalculo)
            };

            using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("spSubTiposCalculos_SELECT",
                                                                                               parameters,
                                                                                                ConnectionBase.EnumTypeDataBase.SQLDB,
                                                                                               ConnectionBase.EnumNameDataBase.ARQCALC,
                                                                                               ConnectionBase.EnumTypeExecute.ExecuteReader))
            {
                if (dr != null)
                {
                    int pos_IdSubTipoCalculo = dr.GetOrdinal("IdSubTipoCalculo");
                    int pos_Descripcion = dr.GetOrdinal("Descripcion");

                    ARQCALC.Entidades.SubTiposCalculos oSubTiposCalculos;
                   
                    while (dr.Read())
                    {
                        oSubTiposCalculos = new Entidades.SubTiposCalculos();
                        oSubTiposCalculos.IdSubTipoCalculo = dr.GetInt32(pos_IdSubTipoCalculo);
                        oSubTiposCalculos.Descripcion = dr.GetString(pos_Descripcion);
                        Lista.Add(oSubTiposCalculos);
                    }
                }
            }
            return Lista;
        }

        public List<ARQCALC.Entidades.ResultCalculoMateriales> CalcularMateriales(int? IdSubTipoCalculo = null, decimal? SuperficieVolumen = 1)
        {
            List<ARQCALC.Entidades.ResultCalculoMateriales> Lista = new List<Entidades.ResultCalculoMateriales>();
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdSubTipoCalculo",IdSubTipoCalculo), new SqlParameter("@SuperficieVolumen", SuperficieVolumen)
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
                    int pos_UnidadMedida = dr.GetOrdinal("UnidadMedida");

                    ARQCALC.Entidades.ResultCalculoMateriales oResultCalculoMateriales;

                    while (dr.Read())
                    {
                        oResultCalculoMateriales = new Entidades.ResultCalculoMateriales();
                        oResultCalculoMateriales.IdSubTipoCalculo = dr.GetInt32(pos_IdSubTipoCalculo);
                        oResultCalculoMateriales.IdMaterial = dr.GetInt32(pos_IdMaterial);
                        oResultCalculoMateriales.NombreMaterial = dr.GetString(pos_NombreMaterial);
                        oResultCalculoMateriales.CantidadMaterial = dr.GetDecimal(pos_CantidadMaterial);
                        oResultCalculoMateriales.UnidadMedida = dr.GetString(pos_UnidadMedida);
                        Lista.Add(oResultCalculoMateriales);
                    }
                }
            }
            return Lista;
        }
    }
}
