using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace CoreCalculoConductividad.RulesBusiness
{
    public class Calculos
    {
        public static float alfai = 7;
        public static float alfaeMURO = 20;
        public static float alfaeCUBIERTA = 25;

        public string CalcularResistenciaTermica(List<Entities.Item> ListaItems, bool EsMuro=true)
        {
            float? Resistencia = 0;

            foreach (Entities.Item _item in ListaItems)
            {
                DAL.MaterialDAL dal = new DAL.MaterialDAL();
                Entities.Material _material = dal.MaterialesDatos.FirstOrDefault(x => x.idMaterial == _item.idMaterial);
                Resistencia += _item.Espesor / _material.conductividadPractica;
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

        public string CalcularMasa(List<Entities.Item> ListaItems)
        {
            float? MasaMuro = 0;

            foreach (Entities.Item _item in ListaItems)
            {
                DAL.MaterialDAL dal = new DAL.MaterialDAL();
                Entities.Material _material = dal.MaterialesDatos.FirstOrDefault(x => x.idMaterial == _item.idMaterial);
                MasaMuro += _item.Espesor * _material.pesoEspecificoDesde;
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
            Entities.ZonaBioAmbiental z = Datos.Zonas.Where(x => x.ZonaNombre.Equals(zona)).OrderBy(Y=>Y.indiceExterno).FirstOrDefault();

            if (!EsCubierta)
            {
                sumando = float.TryParse(z.indiceExterno.Split('+')[0], out floatAux) ? float.Parse(z.indiceExterno.Split('+')[0].Replace('.',',')) : 0;
                coeficiente = float.TryParse(z.indiceExterno.Split('+')[1].Replace("mt", ""), out floatAux) ? float.Parse(z.indiceExterno.Split('+')[1].Replace("mt", "")) : 0;
            }
            else
            {
                sumando = float.TryParse(z.indiceCubierta.Split('+')[0], out floatAux) ? float.Parse(z.indiceCubierta.Split('+')[0].Replace('.', ',')) : 0;
                coeficiente = float.TryParse(z.indiceCubierta.Split('+')[1].Replace("mt", ""), out floatAux) ? float.Parse(z.indiceCubierta.Split('+')[1].Replace("mt", "")) : 0;
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