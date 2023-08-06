
using HospitalWeb.Modelos;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HospitalWeb
{
    public partial class FormPaciente : Page
    {
        static Nullable<int> nIdSeleccionado = null;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InicializarForm();
            }
        }

        protected void InicializarForm()
        {
            RellenarGrid();

            cboFiltro.SelectedIndex = 0;
        }

        protected void RellenarGrid()
        {
            var bindingList = new BindingList<Paciente>(CtrlPaciente.ObtenerPacientePorFiltro(cboFiltro.SelectedIndex, txtBuscar.Text));
            
            var source = new BindingSource(bindingList, null);

            grdPaciente.DataSource = source;
            grdPaciente.DataBind();

            if (!this.IsPostBack)
                txtBuscar.Focus();
        }        

        protected void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Focus();
            grdPaciente.SelectedIndex = -1;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            grdPaciente.SelectedIndex = -1;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
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
                e.Row.Cells[3].Style.Add("display", "none !important");
                e.Row.Cells[7].Visible = false;
                e.Row.Cells[11].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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

        protected void grdPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdPaciente.Rows)
            {
                if (row.RowIndex == grdPaciente.SelectedIndex)
                {
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    nIdSeleccionado = Convert.ToInt32(row.Cells[3].Text);
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            grdPaciente.SelectedIndex = -1;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            RellenarGrid();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormDatosPaciente.aspx?a=" + 0);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormDatosPaciente.aspx?id=" + nIdSeleccionado + "&a=" + 1);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CtrlPaciente.EliminarPaciente(nIdSeleccionado.ToString());
            RellenarGrid();
        }
    
    }
}