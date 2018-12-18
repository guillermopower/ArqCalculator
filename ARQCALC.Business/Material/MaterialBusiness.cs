using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARQCALC.Entidades;
using ARQCALC.DAL;

namespace ARQCALC.Business
{
    public class MaterialBusiness: IMaterialBusiness
    {
        public readonly IMaterialDAL dal;

        public MaterialBusiness(IMaterialDAL dal)
        {
            this.dal = dal;
        }

        public List<ARQCALC.Entidades.Material> GetMateriales(int? IdMaterial, string NombreMaterial)
        {
            List<ARQCALC.Entidades.Material> lstMateriales = new List<ARQCALC.Entidades.Material>();
            try
            {
                lstMateriales = dal.GetMateriales(IdMaterial , NombreMaterial);
            }
            catch (Exception)
            {

                throw;
            }
            
            return lstMateriales;
        }
    }
}