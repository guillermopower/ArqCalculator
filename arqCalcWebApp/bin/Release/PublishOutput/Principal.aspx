
<%@ Page Title="Zona de calculos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="arqCalcWebApp.Principal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>TECNOLOGIA I - CASTELLANO</h1>
        <p class="lead">Resistencia Térmica - K Admisible - Verificación</p>
    </div>
    <div class="container body-content">
        <asp:UpdatePanel ID="UpdatePanelll" runat="server" UpdateMode="Always">
            <ContentTemplate>
		        <div class="row">
		            <div class="col-lg-4 col-md-4">
			            <div class="form-group" id="divZona" runat="server">
			                <label id="lblZona" for="ddlZona">Zona</label>
		                    <asp:DropDownList ID="ddlZona" runat="server" class="form-control" OnSelectedIndexChanged="ddlZona_SelectedIndexChanged"></asp:DropDownList>
			            </div>
		            </div>
		            <div class="col-lg-4 col-md-4">
			            <div class="form-group">
			                <label id="lblMateriales" >Materiales</label>
			                <asp:DropDownList ID="ddlMateriales" runat="server" class="form-control"></asp:DropDownList>
				        </div>
			        </div>
			        <div class="col-lg-4 col-md-4">
			            <div class="form-group">
				            <label id="Label1" for="txtEspesor" >Espesor</label>
				            <asp:TextBox ID="txtEspesor" runat="server" class="form-control" ValidationGroup="check"/>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                              ControlToValidate="txtEspesor" ErrorMessage="Ingrese numeros enteros o decimales solo con coma (,)." ForeColor="Red"
                              ValidationExpression="\d+(,\d{1,2})?"></asp:RegularExpressionValidator>
				        </div>
			        </div>
		        </div>

		
		        <div class="row">
                    <div class="col-lg-2 col-xs-2">
			        </div>
		            <div class="col-lg-2 col-xs-2">
				        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" class="btn btn-primary"/>
			        </div>
			        <div class="col-lg-1 col-xs-1">
			        </div>
			        <div class="col-lg-2 col-xs-2">
	                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" class="btn btn-primary" Enabled="false"/>
	                </div>
	                <div class="col-lg-1 col-xs-1">
			        </div>
			        <div class="col-lg-2 col-xs-2">
	                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" class="btn btn-primary" />
	                </div>
		        </div>
		        <br />

		        <div class="row" >
		            <div class="col-lg-4" style="font-size: 1.60vw;">
                        <asp:GridView ID="gdvItemsACalcular" runat="server" ></asp:GridView>
		            </div>
                
		            <div class="col-lg-4" style="font-size: 1.6vw;">
	                    <asp:GridView ID="gdvResultadosFinales" runat="server"></asp:GridView>
	                </div>
	            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>  