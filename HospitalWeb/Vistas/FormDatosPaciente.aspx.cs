using HospitalWeb.Modelos;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HospitalWeb
{
    public partial class FormDatosPaciente : Page
    {
        static Paciente oPacienteSeleccionado = new Paciente();
        static bool bInsert = true;
        static Nullable<int> nNumColegiadoSeleccionado = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InicializarForm();
            }
        }

        protected void InicializarForm()
        {
            if (!IsPostBack)
            {
                RellenarGrid();
                if (Request.QueryString["a"].Equals("1"))
                    bInsert = false;
                else
                    bInsert = true;

                if (!bInsert)
                {
                    MapearPacienteToCampos();
                }      
                else 
                {
                    if (Request.QueryString["b"] != null)
                        txtMedicoAsignado.Text = Request.QueryString["b"];
                }                     
                
                txtNombre.Focus();
            }            
        }

        protected void RellenarGrid()
        {
            var bindingList = new BindingList<Medico>(CtrlMedico.ObtenerMedicoPorFiltro(cboFiltro.SelectedIndex, txtBuscar.Text));

            var source = new BindingSource(bindingList, null);

            grdMedico.DataSource = source;
            grdMedico.DataBind();

            if (!this.IsPostBack)
                txtBuscar.Focus();
        }

        protected void AbrirModal()
        {           
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append(@"<script type='text/javascript'>");
            sb.Append("$(function () {");
            sb.Append(" $('#AsignarMedico').modal('show');});");
            sb.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ModelScript", sb.ToString(), false);
        }

        protected void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {            
            txtBuscar.Focus();
            AbrirModal();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {            
            grdMedico.SelectedIndex = -1;
            AbrirModal();
        }
        
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!bInsert)
                CtrlPaciente.ModificarPaciente(oPacienteSeleccionado, MapearCamposToPaciente());
            else
                CtrlPaciente.InsertarPaciente(MapearCamposToPaciente());

            Response.Redirect("FormPaciente.aspx");
        }

        protected void btnAceptarMA_Click(object sender, EventArgs e)
        {   
            if (!bInsert)
                Response.Redirect("FormDatosPaciente.aspx?id=" + oPacienteSeleccionado.ID + "&a=" + 1 + "&b=" + nNumColegiadoSeleccionado.ToString());
            else
                Response.Redirect("FormDatosPaciente.aspx?a=" + 0 + "&b=" + nNumColegiadoSeleccionado.ToString());
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormPaciente.aspx");
        }

        protected void btnCancelarMA_Click(object sender, EventArgs e)
        {
            if(!bInsert)
                Response.Redirect("FormDatosPaciente.aspx?id=" + oPacienteSeleccionado.ID + "&a=" + 1);
            else
                Response.Redirect("FormDatosPaciente.aspx?a=" + 0);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RellenarGrid();
            AbrirModal();
        }

        protected void grdMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMedico.PageIndex = e.NewPageIndex;
            RellenarGrid();
            AbrirModal();
        }

        protected void grdMedico_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Style.Add("display", "none !important");
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[10].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[10].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdMedico, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar la fila.";
            }
        }

        protected void grdMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdMedico.Rows)
            {
                if (row.RowIndex == grdMedico.SelectedIndex)
                {
                    nNumColegiadoSeleccionado = Convert.ToInt32(row.Cells[0].Text);
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
            AbrirModal();
        }

        protected void MapearPacienteToCampos()
        {
            oPacienteSeleccionado = CtrlPaciente.ObtenerPaciente(Request.QueryString["id"]);
            lblTitulo.Text += " (" + oPacienteSeleccionado.Nombre + ", " + oPacienteSeleccionado.DocIdentidad + ")";
            txtNombre.Text = oPacienteSeleccionado.Nombre.ToString();
            txtEdad.Text = oPacienteSeleccionado.Edad.ToString();
            txtDNI.Text = oPacienteSeleccionado.DocIdentidad.ToString();
            txtEnfermedad.Text = oPacienteSeleccionado.Enfermedad.ToString();
            txtTratamiento.Text = oPacienteSeleccionado.Tratamiento.ToString();
            txtTelefono.Text = oPacienteSeleccionado.NumTelefono.ToString();
            txtEmail.Text = oPacienteSeleccionado.Email.ToString();
            txtMedicoAsignado.Text = oPacienteSeleccionado.MedicoAsignado.ToString();
            if (Request.QueryString["b"] != null)
                txtMedicoAsignado.Text = Request.QueryString["b"];
            rbGenero.SelectedIndex = 0;
            if (!oPacienteSeleccionado.Genero)
            {
                rbGenero.SelectedIndex = 1;
            }
        }

        protected Paciente MapearCamposToPaciente()
        {
            Paciente oPaciente = new Paciente();

            if (!bInsert)
                oPaciente.ID = oPacienteSeleccionado.ID;
            else
                oPaciente.ID = Registro.Personas.Count + 1;

            oPaciente.Ocupacion = "Paciente";
            oPaciente.Nombre = txtNombre.Text;
            oPaciente.Edad = Convert.ToInt32(txtEdad.Text);
            oPaciente.DocIdentidad = txtDNI.Text;
            oPaciente.Enfermedad = txtEnfermedad.Text;
            oPaciente.Tratamiento = txtTratamiento.Text;
            oPaciente.NumTelefono = Convert.ToInt32(txtTelefono.Text);
            oPaciente.Email = txtEmail.Text;
            oPaciente.MedicoAsignado = Convert.ToInt32(txtMedicoAsignado.Text);
            oPaciente.Genero = true;
            oPaciente.Sexo = "Hombre";

            if (rbGenero.SelectedIndex != 0)
            {
                oPaciente.Genero = false;
                oPaciente.Sexo = "Mujer";
            }

            return oPaciente;
        }        
    }
}