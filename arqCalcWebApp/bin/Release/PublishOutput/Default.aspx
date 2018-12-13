<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="arqCalcWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>TECNOLOGIA I - CASTELLANO&nbsp;</h1>
        <p class="lead">Pagina destinada a realizar calculos relacionados al mundo de la construcción, arquitectura y urbanismo.</p>
        <p><a href="http://www.undav.edu.ar/index.php?idcateg=255" class="btn btn-primary btn-lg">UNDAV &raquo;</a></p>
        
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Intoduccion</h2>
            <p>
                En base a lo aprendido en las clases de Tecnologia de la Construccion I -  Cátedra Castellano, con colaboración de las arquitectas Florencia Piccardi y Jesica Bucchino
            </p>
            <p>
                Veremos cálculos relatios a:
            </p>
            <ul>
                <li>Pesos específicos de materiales</li>
                <li>conductividades prácticas orientativa,</li>
                <li>Valores de transmitancia térmicas máximos admisibles (kmax)</li>
                <li>Clasificación Bioambiental</li>
            </ul>

        </div>

        <div class="col-md-4">
            <h2>GRUPO G2</h2>
            <p>
                Integranes:
            </p>
            <ul>
                <li>LISSA RAMOA</li>
                <li>ANDRES TORALES</li>
                <li>PEDRO MACHADO</li>
                <li>ELIZER ESCUDERO</li>
                <li>EVER ROJAS</li>
                <li>MAXIMILIANO RAMIREZ</li>
                <li>GUILLERMO RODRIGUEZ</li>
            </ul>
        </div>
        <div class="col-md-4">
            <h2>Coming soon</h2>
            <p>
                Aislación Acústica, Diagrama de ley de Masas
            </p>
            <%--<p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>--%>
        </div>
    </div>

</asp:Content>
