<%@ Page Title="Personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormDatosMedico.aspx.cs" Inherits="HospitalWeb.FormDatosMedico" EnableEventValidation="false" %>

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
            background: radial-gradient(#5485d1, #5b98f7);
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
            background-color: #5485d1;
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
                 <h2 id="title">
                     <asp:Label ID="lblTitulo" runat="server" Text="Datos Médico"></asp:Label>
                 </h2>
                 <hr>      
            </div>
        </div>
        
        <div class ="row">
            <div class ="col-md-9">
                <div class = "row">
                    <div class="col-md-1" style="margin-top: 0.5%; width: 10%;">
                        <asp:Label CssClass="form-label" ID="lblNombre" runat="server" Text="Nombre:">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                    </div>                     
                    <div class="col-md-1" style="margin-top: 0.5%;">
                        <asp:Label CssClass="form-label" ID="lblEdad" runat="server" Text="Edad:">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtEdad" runat="server"></asp:TextBox>
                    </div> 
                      
                    <div class="col-md-1" style="margin-top: 0.5%;">
                        <asp:Label CssClass="form-label" ID="lblDni" runat="server" Text="DNI:">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtDNI" runat="server"></asp:TextBox>
                    </div>                     
                </div>
                <div class="row" style="margin-top: 1.5%">
                    <div class="col-md-1" style="margin-top: 0.5%; width: 10%;">
                        <asp:Label CssClass="form-label" ID="lbl" runat="server" Text="Nº col:">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-2">                        
                          <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtNumColegiado" runat="server" Enabled="False" ></asp:TextBox>                                            
                    </div>                      
                    <div class="col-md-1" style="margin-top: 0.5%;">
                        <asp:Label CssClass="form-label" ID="lblEspecialidad" runat="server" Text="Esp :">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-3">                       
                          <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtEspecialidad" runat="server" ></asp:TextBox>                                                
                    </div> 
                    <div class="col-md-1" style="margin-top: 0.5%;">
                        <asp:Label CssClass="form-label" ID="lblTelefono" runat="server" Text="Tfno:">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-3">
                        <div class="input-group mb-3">
                          <span class="input-group-text" id="basic-addon2">☏</span>
                          <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtTelefono" runat="server" ></asp:TextBox>
                        </div>                        
                    </div> 
                </div>
                <div class="row" style="margin-top: 1.5%">
                    <div class="col-md-1" style="margin-top: 0.5%;width: 10%;">
                        <asp:Label CssClass="form-label" ID="lblEmail" runat="server" Text="Email:">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-6">
                        <div class="input-group mb-3">
                          <span class="input-group-text" id="basic-addon1">@</span>
                          <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtEmail" runat="server" ></asp:TextBox>
                        </div>                        
                    </div>                     
                </div>                
            </div>       
            <div class ="col-md-3 d-flex justify-content-end">
                <div class="card border-dark mb-3" style="width: 100%;max-width: 18rem;border-color: #5f5b5b66 !important;">
                      <div class="card-header" style=" background: radial-gradient(#5485d1, #5b98f7); color:white">Genero</div>
                      <div class="card-body">
                         <asp:RadioButtonList ID="rbGenero" runat="server" AutoPostBack="True">
                            <asp:ListItem>Hombre</asp:ListItem>
                            <asp:ListItem>Mujer</asp:ListItem>
                        </asp:RadioButtonList>
                      </div>
                    </div>
            </div>
        </div>  
        <div runat="server" id="divPacientesAsignados">
            <div class="row">
                <div class="col-md-4" style="margin-top: 0.5%;font-weight: bold;">
                    <asp:Label  ID="lblPacientesAsignados" runat="server" Text="Pacientes asignados:">                        
                    </asp:Label>               
                </div>   
                <div class ="col-md-12">                 
                    <hr />
                </div>
            </div>
            <div class="row" >            
                <div class="col-md-12">
                    <div class="table-responsive">
                        <asp:GridView ID="grdPaciente" runat="server" CssClass="table table-striped table-bordered table-condensed table-responsive table-hover" AllowPaging="true"
                                      OnPageIndexChanging="grdPaciente_PageIndexChanging" OnRowDataBound="grdPaciente_RowDataBound">
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="9" FirstPageText="<<" LastPageText=">>"/>  
                            <PagerStyle CssClass="pag" HorizontalAlign="Left" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>        
        <div class="row">            
            <div class="d-flex justify-content-end">         
                <div class="col-md-1 d-flex justify-content-end" style="margin-right:2px;">
                     <asp:Button CssClass="btn btn-primary" style="width: 100%;" ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click"/>
                </div>
                <div class="col-md-1 d-flex justify-content-end" style="margin-right:2px;">
                    <asp:Button CssClass="btn btn-primary" style="width: 100%;" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>        
           </div>
        </div>
    </main>
</asp:Content>
