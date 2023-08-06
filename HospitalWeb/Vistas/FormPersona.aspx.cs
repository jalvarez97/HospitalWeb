using HospitalWeb.Modelos;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HospitalWeb
{
    public partial class FormPersona : Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InicializarForm();
            }     
        }

        protected void InicializarForm()
        {
            if (Registro.Medicos.Count == 0) {
                Registro.GenerarRegistros();
            }
            
            RellenarGrid();
            cboFiltro.SelectedIndex = 0;
        }       

        protected void grdPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPersonas.PageIndex = e.NewPageIndex;
            RellenarGrid();
        }
              
        protected void grdPersonas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[4].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[4].Visible = false;
            }
        }       

        protected void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }
        
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RellenarGrid();            
        }

        protected void RellenarGrid()
        {
            var bindingList = new BindingList<Persona>(CtrlPersona.ObtenerPersonaPorFiltro(cboFiltro.SelectedIndex, txtBuscar.Text));
            var source = new BindingSource(bindingList, null);

            grdPersonas.DataSource = source;
            grdPersonas.DataBind();
            
            if (!this.IsPostBack)
                txtBuscar.Focus();
        }
    }
}