using ARQCALC.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ARQCALC.DAL
{
    public class MaterialDAL: IMaterialDAL
    {
        public List<Material> ListaMateriales;

        //private readonly IConnectionBase _connectionBase;
        //private readonly ConnectionBase _connectionBase;

        public MaterialDAL()
        {
            ConnectionBase _connectionBase = new ConnectionBase();
        }

        public List<Material> GetMateriales(int? IdMaterial = null , string NombreMaterial = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdMaterial",IdMaterial),
                new SqlParameter("@NombreMaterial",NombreMaterial)
            };

            ConnectionBase _connectionBase = new ConnectionBase();

            using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("spMATERIALES_SELECT",
                                                                                               parameters,
                                                                                                ConnectionBase.EnumTypeDataBase.SQLDB,
                                                                                               ConnectionBase.EnumNameDataBase.ARQCALC,
                                                                                               ConnectionBase.EnumTypeExecute.ExecuteReader))
            {
                if (dr != null)
                {
                    int pos_IdMaterial = dr.GetOrdinal("IdMaterial");
                    int pos_NombreMaterial = dr.GetOrdinal("NombreMaterial");
                    int pos_PesoEspecificoDesde = dr.GetOrdinal("PesoEspecificoDesde");
                    int pos_PesoEspecificoHasta = dr.GetOrdinal("PesoEspecificoHasta");
                    int pos_ConductividadPractica = dr.GetOrdinal("ConductividadPractica");
                    int pos_IdUnidadMedida = dr.GetOrdinal("IdUnidadMedida");

                    Material oMaterial;
                    ListaMateriales = new List<Material>();

                    while (dr.Read())
                    {
                        oMaterial = new Material();
                        oMaterial.IdMaterial = dr.GetInt32(pos_IdMaterial);
                        oMaterial.NombreMaterial = dr.GetString(pos_NombreMaterial);
                        if (!dr.IsDBNull(pos_PesoEspecificoDesde)) oMaterial.PesoEspecificoDesde = dr.GetDecimal(pos_PesoEspecificoDesde);
                        if (!dr.IsDBNull(pos_PesoEspecificoHasta)) oMaterial.PesoEspecificoHasta = dr.GetDecimal(pos_PesoEspecificoHasta);
                        if (!dr.IsDBNull(pos_ConductividadPractica)) oMaterial.ConductividadPractica = dr.GetDecimal(pos_ConductividadPractica);
                        if (!dr.IsDBNull(pos_IdUnidadMedida)) oMaterial.IdUnidadMedida =  dr.GetInt32(pos_IdUnidadMedida);
                        

                        //{
                        //    IdMaterial = dr.GetInt32(pos_IdMaterial),
                        //    NombreMaterial = dr.GetString(pos_NombreMaterial),
                        //    PesoEspecificoDesde = dr.GetFloat(pos_PesoEspecificoDesde),
                        //    PesoEspecificoHasta = dr.GetFloat(pos_PesoEspecificoHasta),
                        //    ConductividadPractica = dr.GetFloat(pos_ConductividadPractica),
                        //    IdUnidadMedida = !dr.IsDBNull(pos_IdUnidadMedida) ? dr.GetInt32(pos_IdUnidadMedida): int.Parse(null)
                        //};


                        ListaMateriales.Add(oMaterial);
                    }
                }

                return ListaMateriales;
            }
        }

    }
}