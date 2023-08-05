<%@ Page Title="Personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormPersona.aspx.cs" Inherits="HospitalWeb.FormPersona" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /*gridview*/
        .pag table table  tbody  tr  td a ,
        .table table  tbody  tr  td  span
        {
            padding: 6px 12px;
        }
        .table table tbody tr td a{
            padding: 6px 12px;
        }
        .table
        {
            background: white;
        }
         .table>tbody>tr>th
        {
            background: radial-gradient(#0d6efdd4, #0d6efdcf);
            color: #fff!important;
        }        
        .table table  tbody  tr  td a ,
        .table table  tbody  tr  td  span {       
            
            margin-left: -1px;
            line-height: 1.42857143;
            color: #000;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
        }

        .table table > tbody > tr > td > span {
            z-index: 3;
            color: #fff;
            cursor: default;
            background-color: #0d6efdd4;
            border-color: #337ab7;
        }

        .table table > tbody > tr > td:first-child > a,
        .table table > tbody > tr > td:first-child > span {
            margin-left: 0;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }

        .table table > tbody > tr > td:last-child > a,
        .table table > tbody > tr > td:last-child > span {
            border-top-right-radius: 4px;
            border-bottom-right-radius: 4px;
        }

        .table table > tbody > tr > td > a:hover,
        .table table > tbody > tr > td > span:hover,
        .table table > tbody > tr > td > a:focus,
        .table table > tbody > tr > td > span:focus {
            z-index: 2;
            color: #000;
            background-color: #eee;
            border-color: #ddd;
        }
    </style>
    <main aria-labelledby="title">  
        <div class = "row">
            <div class ="col-md-12">
                 <h2 id="title">Buscar (Todo)</h2>
            </div>
        </div>
        <div class ="row">            
            <div class ="input-group">
                <div class="col-md-2">
                    <asp:DropDownList CssClass="form-select" ID="cboFiltro" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cboFiltro_SelectedIndexChanged">
                        <asp:ListItem>Nombre</asp:ListItem>
                        <asp:ListItem>Edad</asp:ListItem>
                        <asp:ListItem>Sexo</asp:ListItem>
                        <asp:ListItem>Dni</asp:ListItem>
                        <asp:ListItem>Email</asp:ListItem>
                        <asp:ListItem>Teléfono</asp:ListItem>
                        <asp:ListItem>Ocupación</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-10">
                    <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtBuscar" runat="server" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>
                </div>               
            </div>           
        </div>    
        <div class="row" style="margin-top: 1.5%">
            <div class="col-md-12">
                <asp:GridView ID="grdPersonas" runat="server" class="table table-striped table-responsive" AllowPaging="true" 
                              OnPageIndexChanging="grdPersonas_PageIndexChanging" OnRowDataBound="grdPersonas_RowDataBound" >
                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="9" FirstPageText="<<" LastPageText=">>"/>  
                    <PagerStyle CssClass="pag" HorizontalAlign="Left" />
                </asp:GridView>
            </div>
        </div>

    </main>
</asp:Content>
