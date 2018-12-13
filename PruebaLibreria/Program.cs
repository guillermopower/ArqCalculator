using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARQCALC.Test
{
    class Program
    {
        static void Main(string[] args)
        {
           //ARQCALC.DAL.MaterialDAL matDal = new ARQCALC.DAL.MaterialDAL();
           
           // List<int> ListaIdMateriales = new List<int>() { 23, 21, 14, 22, 21, 21 };
           // var lista = matDal.MaterialesDatos.Where(x => ListaIdMateriales.Contains(x.idMaterial));
           // lista.ToList().ForEach(x => Console.WriteLine(
           //   "Id Material: " + x.idMaterial.ToString() + Environment.NewLine 
           // + "Nombre Material: " + x.nombreMaterial + Environment.NewLine 
           // + "Conductividad Practica: " + x.conductividadPractica.ToString() + Environment.NewLine 
           // + "Peso Especifico Desde: " + x.pesoEspecificoDesde.ToString()));

           //ARQCALC.Business.Calculos calcu = new ARQCALC.Business.Calculos();

            

           // List<ARQCALC.Entities.Item> ListaMaterialesMuro = new List<ARQCALC.Entities.Item>();
           // ListaMaterialesMuro.Add(new ARQCALC.Entities.Item() { idMaterial = 23, Espesor = 0.01f });
           // ListaMaterialesMuro.Add(new ARQCALC.Entities.Item() { idMaterial = 21, Espesor = 0.015f });
           // ListaMaterialesMuro.Add(new ARQCALC.Entities.Item() { idMaterial = 14, Espesor = 0.18f });
           // ListaMaterialesMuro.Add(new ARQCALC.Entities.Item() { idMaterial = 22, Espesor = 0.01f });
           // ListaMaterialesMuro.Add(new ARQCALC.Entities.Item() { idMaterial = 21, Espesor = 0.015f });
           // ListaMaterialesMuro.Add(new ARQCALC.Entities.Item() { idMaterial = 21, Espesor = 0.01f });

           // Console.WriteLine();
           // Console.WriteLine();
           // Console.WriteLine("Masa");
           // string MasaMuro_String = calcu.CalcularMasa(ListaMaterialesMuro);
           // float MasaMuro = float.Parse(MasaMuro_String.Split(' ')[0]);
           // Console.WriteLine(MasaMuro.ToString() + "tn/m²");
           // Console.WriteLine();

           // Console.WriteLine("Calcular Resistencia Térmica");
           // string ResistenciaTermica_String = calcu.CalcularResistenciaTermica(ListaMaterialesMuro);
           // float ResistenciaTermica = float.Parse(ResistenciaTermica_String.Split(' ')[0]);
           // Console.WriteLine(ResistenciaTermica_String);
           // Console.WriteLine();

           // Console.WriteLine("Calcular K (Resistencia térmica)");
           // Console.WriteLine(calcu.CalcularTransmitancia(ResistenciaTermica));
           // Console.WriteLine();
           // Console.WriteLine("Calcular K Max Admisible");
           // string KMaxAdmisible_string = calcu.CalcularKMaxAdmisible(MasaMuro, null, "IIIb", false);
           // float KMaxAdmisible = float.Parse(KMaxAdmisible_string.Split(' ')[0]);
            
           // Console.WriteLine(KMaxAdmisible_string);
           // Console.WriteLine();

           // Console.WriteLine("VERIFICA");
           // Console.WriteLine();
           // string Verifica_String = calcu.Verificar(KMaxAdmisible, ResistenciaTermica) ? "SI VERIFICA!!!!!!!!!!!!!!!!!!" : "NO VERIFICA";
           // Console.WriteLine(Verifica_String);
            
           // Console.ReadKey();

        }
    }
}
