using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARQCALC.Entidades;
using ARQCALC.DAL;

namespace ARQCALC.Business
{
    public class ZonaBioAmbientalBusiness: IZonaBioAmbientalBusiness
    {
        private readonly IZonaBioAmbientalDAL dal;

        public ZonaBioAmbientalBusiness()
        {
            this.dal = new ZonaBioAmbientalDAL();
        }

        public ZonaBioAmbientalBusiness(IZonaBioAmbientalDAL dal)
        {
            this.dal = dal;
        }

        public List<ZonaBioAmbiental> GetZonaBioAmbientales(int? IdZonaBioAmbiental, string NombreZonaBioAmbiental)
        {
            List<ZonaBioAmbiental> lstZonaBioAmbientales = new List<ZonaBioAmbiental>();
            try
            {
                lstZonaBioAmbientales = dal.GetZonaBioAmbiental(IdZonaBioAmbiental, NombreZonaBioAmbiental);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return lstZonaBioAmbientales;
        }
    }
}