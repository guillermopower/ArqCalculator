<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="arqCalcWebApp.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <%-- <style>
        #txtResuts{
            width:100%;
            height:150px;
        }
        .control{
           width:150px;
           height:20px;
        }
        .Content{
            overflow:hidden;
            /*width:500px;
            height:25px;*/
        }
        .OneColumn{
            width:100%;
         }
         .TwoColumnsLeft{
            width:40%;
            float:left;
         }
         .TwoColumnsRight{
            width:40%;
            float:left;
            
         }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Content">
            <div class="OneColumn">
                <div >
                    <asp:Label ID="lblZona" runat="server" Text="Zona" ></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlZona" runat="server" class="Control" ></asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="Content">
            <div class="TwoColumsLeft">
                <asp:Label ID="lblMateriales" runat="server" Text="Materiales" class="Control"></asp:Label>
            </div>
            <div class="TwoColumsRight">
                <asp:DropDownList ID="ddlMateriales" runat="server" class="Control" ></asp:DropDownList>
            </div>
        </div>
        <div class="Content">
            <div class="TwoColumsLeft">
                <asp:Label ID="Label1" runat="server" Text="Espesor" class="Control"></asp:Label>
            </div>
            <div class="TwoColumsRight">
                <asp:TextBox ID="txtEspesor" runat="server"></asp:TextBox>
                <asp:Button ID="btnAgregar" runat="server" Text="..." OnClick="btnAgregar_Click" />
            </div>
            </div>
            <br />

             <div class="OneColumn">
                <asp:GridView ID="gdvResults" runat="server"></asp:GridView>
            </div>

            <div class="OneColumn">
                <asp:Button ID="btnCalcular" runat="server" Text="Button" OnClick="btnCalcular_Click" />
            </div>

            <div class="OneColumn">
                <asp:TextBox ID="txtResuts" runat="server" TextMode="MultiLine" Width="500px" Height="300px"></asp:TextBox>
            </div>
           
     
    </form>
    
</body>
</html>
