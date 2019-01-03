using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ARQCALC.Business;
using ARQCALC.Entidades;

namespace arqCalcWebApp
{
    public partial class Principal : System.Web.UI.Page
    {
       
        public List<ItemPresentacion> ListaItems
        {
            get
            {
                if (HttpContext.Current.Session["ListaItems"] == null)
                {
                    HttpContext.Current.Session["ListaItems"] = new List<ItemPresentacion>();
                }
                return HttpContext.Current.Session["ListaItems"] as List<ItemPresentacion>;
            }
            set
            {
                HttpContext.Current.Session["ListaItems"] = value;
            }

        }

        public List<Resultado> ListaResultados
        {
            get
            {
                if (HttpContext.Current.Session["ListaResultados"] == null)
                {
                    HttpContext.Current.Session["ListaResultados"] = new List<Resultado>();
                }
                return HttpContext.Current.Session["ListaResultados"] as List<Resultado>;
            }
            set
            {
                HttpContext.Current.Session["ListaResultados"] = value;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
                ListaItems = new List<ItemPresentacion>();
                //ddlZona.SelectedIndexChanged += ddlZona_SelectedIndexChanged;
            }
        }

        public void CargarControles()
        {
            /*
            ZonaBioAmbientalBusiness ZonaBssnss = new ZonaBioAmbientalBusiness();
            MaterialBusiness materialBsnss = new MaterialBusiness();
            
            this.ddlZona.DataSource = ZonaBssnss.GetZonaBioAmbientales(null,null).ToList();
            this.ddlZona.DataTextField = "NombreZona";
            this.ddlZona.DataValueField="IdZona";
            this.ddlZona.DataBind();
            this.ddlZona.SelectedIndex = 8;

            this.ddlMateriales.DataSource = materialBsnss.GetMateriales(null,null).ToList();
            this.ddlMateriales.DataTextField = "NombreMaterial";
            this.ddlMateriales.DataValueField = "IdMaterial";
            this.ddlMateriales.DataBind();
            this.ddlMateriales.SelectedIndex = -1;

            LimpiarGrillagdvItemsACalcular();
            LimpiarGrillaResultados();
            */
        }

        private void LimpiarGrillagdvItemsACalcular()
        {
           lblItemsACalcular.Value = "Material / Espesor en m" + Environment.NewLine; 
        }

        private void LimpiarGrillaResultados()
        {
            lblResultados1.Value =
            lblResultados2.Value = string.Empty;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlMateriales.SelectedItem == null || string.IsNullOrEmpty(txtEspesor.Text)) return;

                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Deshabilitar", "DesHabilitar()", true);

                int _idMaterial = 0; float _Espesor = 0;
                _idMaterial = Int32.TryParse(ddlMateriales.SelectedItem.Value, out _idMaterial) ? Int32.Parse(ddlMateriales.SelectedItem.Value) : -1;
                _Espesor = float.TryParse(txtEspesor.Text, out _Espesor) ? float.Parse(txtEspesor.Text) : -1;
                string NombreMaterial = (ddlMateriales.SelectedItem.Text);

                ListaItems.Add(new ItemPresentacion {  IdMaterial = _idMaterial, Espesor = _Espesor, Material = NombreMaterial });
                string string_items = "Material / Espesor en m" + Environment.NewLine;
                ListaItems.ForEach(x => string_items += (x.Material.Length >14 ? x.Material.Substring(0, 15) : x.Material) + "...  " + x.Espesor.ToString() + " m" + Environment.NewLine);

                lblItemsACalcular.Value = string_items;
                this.txtEspesor.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Error!", "alert('"+ ex.Message+ "')", true);
            }
           
        }

        private void Limpiar(bool profundo = false)
        {
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Habilitar", "Habilitar()", true);
            ListaItems.Clear();
            this.txtEspesor.Text = string.Empty;
            this.ddlMateriales.SelectedIndex = -1;
            if (!profundo) return;
            LimpiarGrillagdvItemsACalcular();
            LimpiarGrillaResultados();
            ListaResultados.Clear();
            
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            /*
            try
            { 
        	    if(ListaItems.Count()==0) return;
            
                List<Item> ListaMaterialesMuro = new List<Item>();

                Calculos calcu = new Calculos(new IZonaBioAmbientalDAL, new IMaterialBusiness);
                ListaMaterialesMuro = ListaItems.Cast<Item>().ToList();

                Resultado rdo = new Resultado();

                string MasaMuro_String = calcu.CalcularMasa(ListaMaterialesMuro);
                float MasaMuro = float.Parse(MasaMuro_String.Split(' ')[0]);
                rdo.Masa =  (MasaMuro.ToString("####0.00") + " tn/m²");
            
                string ResistenciaTermica_String = calcu.CalcularResistenciaTermica(ListaMaterialesMuro);
                float ResistenciaTermica = float.Parse(ResistenciaTermica_String.Split(' ')[0]);
                rdo.Resistencia_Termica = ResistenciaTermica_String;
            
                rdo.Transmitancia =(calcu.CalcularTransmitancia(ResistenciaTermica));
          
                string KMaxAdmisible_string = calcu.CalcularKMaxAdmisible(MasaMuro, null, ddlZona.SelectedItem.Text, false);
                rdo.Maximo_K_Admisible = KMaxAdmisible_string;

                float KMaxAdmisible = float.Parse(KMaxAdmisible_string.Split(' ')[0]);

                rdo.Verifica = calcu.Verificar(KMaxAdmisible, ResistenciaTermica) ? "SI" : "NO";

                this.ListaResultados.Add(rdo);

                string resultad1 = "Masa: " + ListaResultados.FirstOrDefault().Masa + Environment.NewLine;
                resultad1 += "Res.Térmica (λ): " + ListaResultados.FirstOrDefault().Resistencia_Termica + Environment.NewLine;
                resultad1 += "Transmitancia: " + ListaResultados.FirstOrDefault().Transmitancia;

                lblResultados1.Value = resultad1;
            
                string resultad2 = "Max. K Admisible: " + ListaResultados.FirstOrDefault().Maximo_K_Admisible + Environment.NewLine;
                resultad2 += "Verifica: " + ListaResultados.FirstOrDefault().Verifica;
           
                lblResultados2.Value = resultad2;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "Error!", "alert('" + ex.Message + "')", true);
            }
            */
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(true);
        }

    }
}