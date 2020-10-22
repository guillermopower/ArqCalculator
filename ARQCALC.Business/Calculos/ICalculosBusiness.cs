using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARQCALC.Entidades;

namespace ARQCALC.Business
{
    public interface ICalculosBusiness
    {
        string CalcularResistenciaTermica(List<Item> ListaItems, bool EsMuro = true);
        string CalcularMasa(List<Item> ListaItems);
        string CalcularKMaxAdmisible(float MasaMuro, string orientacion = null, string zona = "IIIb", bool EsCubierta = false);
        bool Verificar(float KMaxAdmisible, float Resistencia);
        List<CalculoDeMaterialesResult> GetMatrizCalculo(int IdSubTipoCalculo);
    }
}
