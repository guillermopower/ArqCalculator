using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARQCALC.Entidades;

namespace ARQCALC.Business
{
    public class Calculos
    {
        public static float alfai = 7;
        public static float alfaeMURO = 20;
        public static float alfaeCUBIERTA = 25;

        public string CalcularResistenciaTermica(List<Item> ListaItems, bool EsMuro=true)
        {
            float? Resistencia = 0;

            foreach (Item _item in ListaItems)
            {
                DAL.MaterialDAL dal = new DAL.MaterialDAL();
                Material _material = dal.GetMateriales().FirstOrDefault(x => x.IdMaterial == _item.IdMaterial);
                Resistencia += _item.Espesor / (float)_material.ConductividadPractica;
            }

            Resistencia += 1 / alfai;
            Resistencia += 1 / (EsMuro? alfaeMURO:alfaeCUBIERTA);

            return String.Format("{0:0.0000}", Resistencia) + " KCal/h m² °C";
        }
        /// <summary>
        /// Obtener K
        /// </summary>
        /// <returns></returns>
        public string CalcularTransmitancia(float Resistencia)
        {
            if (Resistencia == 0) return string.Empty;
            return (1/Resistencia).ToString("####0.0000") + " h m² °C/Kcal";
        }

        public string CalcularMasa(List<Item> ListaItems)
        {
            float? MasaMuro = 0;

            foreach (Item _item in ListaItems)
            {
                DAL.MaterialDAL dal = new DAL.MaterialDAL();
                Material _material = dal.GetMateriales().FirstOrDefault(x => x.IdMaterial == _item.IdMaterial);
                MasaMuro += _item.Espesor *(float) _material.PesoEspecificoDesde;
            }

            return (MasaMuro/1000).ToString() + " tn / m²";
        }

        public string CalcularKMaxAdmisible(float MasaMuro, string orientacion = null, string zona = "IIIb", bool EsCubierta = false)
        {
            if (MasaMuro == 0) return string.Empty;
            float KMaxAdmisible = 0;
            float floatAux = 0;
            float sumando = 0;
            float coeficiente = 0;

            DAL.ZonaBioAmbientalDAL Datos = new DAL.ZonaBioAmbientalDAL();
            ZonaBioAmbiental z = Datos.GetZonaBioAmbiental().Where(x => x.NombreZona.Equals(zona)).OrderBy(Y=>Y.IndiceExterno).FirstOrDefault();

            if (!EsCubierta)
            {
                sumando = float.TryParse(z.IndiceExterno.Split('+')[0], out floatAux) ? float.Parse(z.IndiceExterno.Split('+')[0].Replace('.',',')) : 0;
                coeficiente = float.TryParse(z.IndiceExterno.Split('+')[1].Replace("mt", ""), out floatAux) ? float.Parse(z.IndiceExterno.Split('+')[1].Replace("mt", "")) : 0;
            }
            else
            {
                sumando = float.TryParse(z.IndiceCubierta.Split('+')[0], out floatAux) ? float.Parse(z.IndiceCubierta.Split('+')[0].Replace('.', ',')) : 0;
                coeficiente = float.TryParse(z.IndiceCubierta.Split('+')[1].Replace("mt", ""), out floatAux) ? float.Parse(z.IndiceCubierta.Split('+')[1].Replace("mt", "")) : 0;
            }

            KMaxAdmisible = ((MasaMuro * coeficiente) + sumando);

            return KMaxAdmisible.ToString("####0.0000") + " Kcal / h m² °C";
        }

        public bool Verificar(float KMaxAdmisible, float Resistencia)
        {
            if (KMaxAdmisible == 0 && Resistencia == 0) return false;
           
            return (1/Resistencia) <= KMaxAdmisible;
        }
      
    }
}