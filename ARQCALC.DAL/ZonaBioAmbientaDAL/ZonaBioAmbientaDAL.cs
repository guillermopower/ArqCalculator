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
    public class ZonaBioAmbientalDAL: IZonaBioAmbientalDAL
    {
        private readonly IConnectionBase _connectionBase;
        public List<ZonaBioAmbiental> ListaZonas;

        
        public ZonaBioAmbientalDAL(IConnectionBase ConnectionBase)
        {
            _connectionBase = ConnectionBase;
        }
         
        public List<ZonaBioAmbiental> GetZonaBioAmbiental(int? IdZona = null, string NombreZona = null)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@IdZona",IdZona),
                new SqlParameter("@NombreZona",NombreZona)
            };

            //ConnectionBase _connectionBase = new ConnectionBase();
            using (SqlDataReader dr = (SqlDataReader)_connectionBase.ExecuteByStoredProcedure("spZONASBIOAMBIENTALES_SELECT",
                                                                                               parameters,
                                                                                                ConnectionBase.EnumTypeDataBase.SQLDB,
                                                                                               ConnectionBase.EnumNameDataBase.ARQCALC,
                                                                                               ConnectionBase.EnumTypeExecute.ExecuteReader))
            {
                if (dr != null)
                {
                    int pos_IdZona = dr.GetOrdinal("IdZona");
                    int pos_NombreZona = dr.GetOrdinal("NombreZona");
                    int pos_OrientacionExterna = dr.GetOrdinal("OrientacionExterna");
                    int pos_IndiceExterno = dr.GetOrdinal("IndiceExterno");
                    int pos_IndiceCubierta = dr.GetOrdinal("IndiceCubierta");
                    int pos_Observaciones = dr.GetOrdinal("Observaciones");

                    ZonaBioAmbiental oZonaBioAmbiental;
                    ListaZonas = new List<ZonaBioAmbiental>();

                    while (dr.Read())
                    {
                        //oZonaBioAmbiental = new ZonaBioAmbiental()
                        //{
                        //    IdZona=  dr.GetInt32(pos_IdZona),
                        //    NombreZona = dr.GetString(pos_NombreZona),
                        //    OrientacionExterna = dr.GetString(pos_OrientacionExterna),
                        //    IndiceExterno = dr.GetString(pos_IndiceExterno),
                        //    IndiceCubierta = dr.GetString(pos_IndiceCubierta),
                        //    Observaciones = dr.GetString(pos_Observaciones)
                        //};
                        oZonaBioAmbiental = new ZonaBioAmbiental();
                        oZonaBioAmbiental.IdZona = dr.GetInt32(pos_IdZona);
                        oZonaBioAmbiental.NombreZona = dr.GetString(pos_NombreZona);
                        oZonaBioAmbiental.OrientacionExterna = dr.GetString(pos_OrientacionExterna);
                        oZonaBioAmbiental.IndiceExterno = dr.GetString(pos_IndiceExterno);
                        oZonaBioAmbiental.IndiceCubierta = dr.GetString(pos_IndiceCubierta);
                        oZonaBioAmbiental.Observaciones = dr.GetString(pos_Observaciones);
                        
                        ListaZonas.Add(oZonaBioAmbiental);
                    }
                }

                return ListaZonas;
            }
        }

    }
}