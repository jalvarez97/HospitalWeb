using HospitalWeb.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HospitalWeb
{
    public partial class FormDatosMedico : Page
    {
        static Medico oMedicoSeleccionado = new Medico();
        static bool bInsert = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InicializarForm();
            }
        }
        private void InicializarForm()
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["a"].Equals("1"))
                {
                    bInsert = false;
                }                    
                else
                {
                    bInsert = true;
                }

                if (!bInsert)
                    MapearMedicoToCampos();
                else
                    divPacientesAsignados.Visible = false;
                    txtNumColegiado.Enabled = true;
                
                txtNombre.Focus();
            }            
        }

        protected void RellenarGrid()
        {
            var bindingList = new BindingList<Paciente>(CtrlPaciente.ObtenerPacientePorFiltro(8, oMedicoSeleccionado.NumColegiado.ToString()));

            var source = new BindingSource(bindingList, null);

            grdPaciente.DataSource = source;
            grdPaciente.DataBind();            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!bInsert)            
                CtrlMedico.ModificarMedico(oMedicoSeleccionado, MapearCamposToMedico());
            else
                CtrlMedico.InsertarMedico(MapearCamposToMedico());
            
            Response.Redirect("FormMedico.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormMedico.aspx");
        }

        protected void grdPaciente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPaciente.PageIndex = e.NewPageIndex;
            RellenarGrid();
        }

        protected void grdPaciente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Style.Add("display", "none !important");               
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[11].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;               
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[11].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdPaciente, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click para seleccionar la fila.";
            }
        }

        protected void MapearMedicoToCampos()
        {
            oMedicoSeleccionado = CtrlMedico.ObtenerMedico(Request.QueryString["id"]);
            lblTitulo.Text += " (" + oMedicoSeleccionado.Nombre + ", " + oMedicoSeleccionado.NumColegiado + ")";
            txtNombre.Text = oMedicoSeleccionado.Nombre.ToString();
            txtEdad.Text = oMedicoSeleccionado.Edad.ToString();
            txtDNI.Text = oMedicoSeleccionado.DocIdentidad.ToString();
            txtNumColegiado.Text = oMedicoSeleccionado.NumColegiado.ToString();
            txtEspecialidad.Text = oMedicoSeleccionado.Especialidad.ToString();
            txtTelefono.Text = oMedicoSeleccionado.NumTelefono.ToString();
            txtEmail.Text = oMedicoSeleccionado.Email.ToString();
            rbGenero.SelectedIndex = 0;
            if (!oMedicoSeleccionado.Genero)
            {
                rbGenero.SelectedIndex = 1;
            }
            RellenarGrid();
        }

        protected Medico MapearCamposToMedico()
        {
            Medico oMedico = new Medico();

            if (!bInsert)
                oMedico.ID = oMedicoSeleccionado.ID;
            else
                oMedico.ID = Registro.Personas.Count + 1;

            oMedico.Ocupacion = "Medico";
            oMedico.Nombre = txtNombre.Text;
            oMedico.Edad = Convert.ToInt32(txtEdad.Text);
            oMedico.DocIdentidad = txtDNI.Text;
            oMedico.NumColegiado = Convert.ToInt32(txtNumColegiado.Text);
            oMedico.Especialidad = txtEspecialidad.Text;
            oMedico.NumTelefono = Convert.ToInt32(txtTelefono.Text);
            oMedico.Email = txtEmail.Text;
            oMedico.Genero = true;
            oMedico.Sexo = "Hombre";

            if (rbGenero.SelectedIndex != 0)
            {
                oMedico.Genero = false;
                oMedico.Sexo = "Mujer";
            }

            return oMedico;
        }        
    }
}