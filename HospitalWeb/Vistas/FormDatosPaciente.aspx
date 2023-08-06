<%@ Page Title="Personas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormDatosPaciente.aspx.cs" Inherits="HospitalWeb.FormDatosPaciente" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">  
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#btnAsignarMedico").click(function () {
                $("#AsignarMedico").modal('show');
            });
        });
    </script>
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
        .modal-backdrop.fade.show{
           display:none;
        }
    </style>
    <asp:UpdatePanel ID="updatePanel" runat="server">
        <ContentTemplate>            
            <!-- Modal HTML -->
            <div id="AsignarMedico" class="modal fade" role="dialog">
                <div class="modal-dialog modal-lg">
                    <div class="row">
                        <div class="modal-content">  
                            <div class="modal-header">
                                <h2 class="modal-title">Asignar Médico</h2>                           
                              </div>
                            <div class="modal-body">
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
                            </div>
                            <div class="modal-footer">
                                <div class="d-flex justify-content-end">     
                                    <div class="d-flex justify-content-end" style="margin-right:2px;">
                                        <asp:Button CssClass="btn btn-primary" style="width: 100%;" ID="btnAceptarMA" runat="server" Text="Aceptar" OnClick="btnAceptarMA_Click"/>

                                    </div>
                                    <div class="d-flex justify-content-end" style="margin-right:2px;">
                                        <asp:Button CssClass="btn btn-primary" style="width: 100%;" ID="btnCancelarMA" runat="server" Text="Cancelar" OnClick="btnCancelarMA_Click" />
                                    </div>        
                                </div>                      
                            </div>
                        </div>
                    </div>                    
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
                    <div class="col-md-1" style="margin-top: 0.5%;">
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
                    <div class="col-md-1" style="margin-top: 0.5%; width: 10%;">
                        <asp:Label CssClass="form-label" ID="lblDni" runat="server" Text="DNI:">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtDNI" runat="server"></asp:TextBox>
                    </div>                     
                </div>
                <div class="row" style="margin-top: 1.5%">
                    <div class="col-md-1" style="margin-top: 0.5%;">
                        <asp:Label CssClass="form-label" ID="lblEnfermedad" runat="server" Text="Enf :">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-2">                        
                            <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtEnfermedad" runat="server" ></asp:TextBox>                                            
                    </div>                      
                    <div class="col-md-1" style="margin-top: 0.5%;">
                        <asp:Label CssClass="form-label" ID="lblTratamiento" runat="server" Text="Tto :">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-3">                       
                            <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtTratamiento" runat="server" ></asp:TextBox>                                                
                    </div> 
                    <div class="col-md-1" style="margin-top: 0.5%; width: 10%;">
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
                    <div class="col-md-1" style="margin-top: 0.5%;">
                        <asp:Label CssClass="form-label" ID="lblEmail" runat="server" Text="Email:">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-6">
                        <div class="input-group mb-3">
                            <span class="input-group-text" id="basic-addon1">@</span>
                            <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtEmail" runat="server" ></asp:TextBox>
                        </div>                        
                    </div>   
                    <div class="col-md-1" style="margin-top: 0.5%; width: 10%;">
                        <asp:Label CssClass="form-label" ID="lblMedicoAsignado" runat="server" Text="M. asig:">                        
                        </asp:Label>
                    </div>
                    <div class="col-md-3">
                        <div class="input-group mb-3">
                            <asp:TextBox style="max-width: 100% !important;" CssClass="form-control" ID="txtMedicoAsignado" runat="server" Enabled="False"></asp:TextBox>                            
                            <button type="button" id="btnAsignarMedico" class="input-group-text">🔍</button>  
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
        <div class="row" style="margin-top:3%;">
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
