using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARQCALC.Entidades;
using ARQCALC.DAL;

namespace ARQCALC.Business
{
    public class ZonaBioAmbientalBusiness
    {
        ZonaBioAmbientalDAL dal = new ZonaBioAmbientalDAL();
        public List<ZonaBioAmbiental> GetZonaBioAmbientales(int? IdZonaBioAmbiental, string NombreZonaBioAmbiental)
        {
            List<ZonaBioAmbiental> lstZonaBioAmbientales = new List<ZonaBioAmbiental>();
            try
            {
                lstZonaBioAmbientales = dal.GetZonaBioAmbiental(IdZonaBioAmbiental, NombreZonaBioAmbiental);
            }
            catch (Exception)
            {

                throw;
            }

            return lstZonaBioAmbientales;
        }
    }
}