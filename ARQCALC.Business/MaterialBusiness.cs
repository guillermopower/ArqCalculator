using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARQCALC.Entidades;

namespace ARQCALC.Business
{
    public class MaterialBusiness
    {
        DAL.MaterialDAL dal = new DAL.MaterialDAL();

        public List<Material> GetMateriales(int? IdMaterial, string NombreMaterial)
        {
            List<Material> lstMateriales = new List<Material>();
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