using ARQCALC.DAL.SubTiposCalculos;
using System.Collections.Generic;

namespace ARQCALC.Business.CalculoMateriales
{
    public class SubTiposCalculosBusiness: ISubTiposCalculosBusiness
    {
        private readonly ISubTiposCalculosDAL dal;

        public SubTiposCalculosBusiness()
        {
            this.dal = new SubTiposCalculosDAL();
        }

        public SubTiposCalculosBusiness(ISubTiposCalculosDAL dal)
        {
            this.dal = dal;
        }

        public List<Entidades.SubTiposCalculos> Get(int? IdSubTipoCalculo)
        {
           return this.dal.Get(IdSubTipoCalculo);
        }

        public List<Entidades.ResultCalculoMateriales> CalcularMateriales(int? IdSubTipoCalculo, decimal SuperficieVolumen)
        {
            return this.dal.CalcularMateriales(IdSubTipoCalculo, SuperficieVolumen);
        }
    }
}
