<%@ Page Title="Personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormMedico.aspx.cs" Inherits="HospitalWeb.FormMedico" EnableEventValidation="false" %>

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
                 <h2 id="title">Buscar (Medico)</h2>
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
                        <asp:ListItem>NumColegiado</asp:ListItem>
                        <asp:ListItem>Especialidad</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-10">
                    <div class="input-group mb-3">
                        <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtBuscar" runat="server" OnTextChanged="txtBuscar_TextChanged"></asp:TextBox>
                        <asp:Button CssClass="input-group-text" ID="btnBuscar" runat="server" Text="🔍" OnClick="btnBuscar_Click"/>                                            
                    </div>   
                 </div>               
            </div>           
        </div>    
        <div class="row" style="margin-top: 1.5%">
            <div class="col-md-12">
                <div class="table-responsive">
                    <asp:GridView ID="grdMedico" runat="server" CssClass="table table-striped table-bordered table-condensed table-responsive table-hover" AllowPaging="true"
                                  OnPageIndexChanging="grdMedico_PageIndexChanging" OnRowDataBound="grdMedico_RowDataBound" OnSelectedIndexChanged="grdMedico_SelectedIndexChanged">
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="9" FirstPageText="<<" LastPageText=">>"/>  
                        <PagerStyle CssClass="pag" HorizontalAlign="Left" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="row" >
            <div class="d-flex justify-content-end">       
                <div class="col-md-1 d-flex justify-content-end" style="margin-right:2px;">
                    
                </div>
                <div class="col-md-1 d-flex justify-content-end" style="margin-right:2px;">
                     <asp:Button CssClass="btn btn-primary" style="width: 100%;" ID="btnCrear" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                </div>
                <div class="col-md-1 d-flex justify-content-end" style="margin-right:2px;">
                    <asp:Button CssClass="btn btn-primary" style="width: 100%;" ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" Enabled="False" />
                </div>
                <div class="col-md-1 d-flex justify-content-end">
                     <asp:Button CssClass="btn btn-primary" style="width: 100%;" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" Enabled="False" />               
                </div>             
           </div>
        </div>
    </main>
</asp:Content>
