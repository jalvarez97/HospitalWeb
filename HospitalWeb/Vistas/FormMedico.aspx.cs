﻿
using HospitalWeb.Modelos;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HospitalWeb
{
    public partial class FormMedico : Page
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
            var bindingList = new BindingList<Medico>(CtrlMedico.ObtenerMedicoPorFiltro(cboFiltro.SelectedIndex, txtBuscar.Text));
            
            var source = new BindingSource(bindingList, null);

            grdMedico.DataSource = source;
            grdMedico.DataBind();

            if (!this.IsPostBack)
                txtBuscar.Focus();
        }        

        protected void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Focus();
            grdMedico.SelectedIndex = -1;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            grdMedico.SelectedIndex = -1;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        protected void grdMedico_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMedico.PageIndex = e.NewPageIndex;
            RellenarGrid();

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
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    nIdSeleccionado = Convert.ToInt32(row.Cells[2].Text);
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
            grdMedico.SelectedIndex = -1;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            RellenarGrid();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormDatosMedico.aspx?a=" + 0);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormDatosMedico.aspx?id=" + nIdSeleccionado + "&a=" + 1);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            CtrlMedico.EliminarMedico(nIdSeleccionado.ToString());
            RellenarGrid();
        }
    
    }
}