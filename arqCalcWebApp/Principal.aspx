<%@ Page Title="Zona de calculos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="arqCalcWebApp.Principal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <div class="jumbotron">
       <%-- <h1</h1>--%>
        <p class="lead">Resistencia Térmica - K Admisible - Verificación</p>
        <p class="lead">TECNOLOGIA I - CASTELLANO</p>
        <span>La información contenida en la página Web se proporciona a título meramente informativo. La web no se responsabiliza por el uso o mal uso de la información suministrada.</span>
    </div>
    <div class="container body-content">
        <asp:UpdatePanel ID="UpdatePanelll" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="row">
                    <div class="col-lg-4 col-md-4">
			            <div class="form-group" >
			                <asp:RadioButtonList ID="rbtListCubiertaMuro" runat="server">
                                <asp:ListItem Selected="True" Text="Muro" Value="Muro"></asp:ListItem>
                                <asp:ListItem Selected="False" Text="Cubierta" Value ="Cubierta"></asp:ListItem>
			                </asp:RadioButtonList> 
			            </div>
		            </div>
                </div>  
		        <div class="row">
		            <div class="col-lg-4 col-md-4">
			            <div class="form-group" id="divZona" runat="server">
			                <label id="lblZona" for="ddlZona">Zona</label>
		                    <asp:DropDownList ID="ddlZona" runat="server" class="form-control" ></asp:DropDownList>
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
				            <label id="Label1" for="txtEspesor" >Espesor (en mts)</label>
				            <asp:TextBox ID="txtEspesor" runat="server" class="form-control" ValidationGroup="check"/>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                              ControlToValidate="txtEspesor" ErrorMessage="Ingrese numeros enteros o decimales solo con coma (,)." ForeColor="Red"
                              ValidationExpression="\d+(,\d{1,5})?"></asp:RegularExpressionValidator>
				        </div>
			        </div>
		        </div>

		        
		        <div class="row">
                    <div class="col-lg-2 col-xs-2">
				        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" class="btn btn-primary"/>
			        </div>
			        <div class="col-lg-1 col-xs-1">
			        </div>
			        <div class="col-lg-2 col-xs-2">
	                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" class="btn btn-primary"/>
	                </div>
	                <div class="col-lg-1 col-xs-1">
			        </div>
			        <div class="col-lg-2 col-xs-2">
	                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" onclick="btnLimpiar_Click" class="btn btn-primary" />
	                </div>
		        </div>
		        <br />
               
                <div class="row" >
		            <div class="col-lg-4 col-md-4">
                       <textarea ID="lblItemsACalcular" runat="server" class="form-control" aria-multiline="true" rows="5"></textarea>
		            </div>
                    <div class="col-lg-4 col-md-4">
	                   
                        <textarea ID="lblResultados1" runat="server" class="form-control" aria-multiline="true" rows="5" style="font-weight:bold"></textarea>
	                </div>

                    <div class="col-lg-4 col-md-4">
	                    <textarea ID="lblResultados2" runat="server" class="form-control" aria-multiline="true" rows="5" style="font-weight:bold"></textarea>
	                </div>
	            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>  