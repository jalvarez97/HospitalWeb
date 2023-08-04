using HospitalWeb.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace HospitalWeb
{
    public partial class FormMedico : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                InicializarForm();
            }
        }
        private void InicializarForm()
        {
            BuscarMedicos();

            cboFiltro.SelectedIndex = 0;
        }
        public void BuscarMedicos()
        {
            List<Medico> lstAuxiliar = new List<Medico>();
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;

            switch (cboFiltro.SelectedIndex)
            {
                case 0:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Nombre, txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 1:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Edad.ToString(), txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 2:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Sexo.ToString(), txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 3:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.DocIdentidad, txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 4:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Email, txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 5:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.NumTelefono.ToString(), txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 6:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.NumColegiado.ToString(), txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 7:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Especialidad, txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
            }

            var bindingList = new BindingList<Medico>(lstAuxiliar);
            
            var source = new BindingSource(bindingList, null);

            grdMedico.DataSource = source;
            grdMedico.DataBind();

            if (source.Count > 0)
            {               
                txtBuscar.Focus();
            }
        }

        protected void grdPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMedico.PageIndex = e.NewPageIndex;
            BuscarMedicos();

        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarMedicos();
        }

        protected void grdPersonas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[9].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[9].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdMedico, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }
        protected void grdMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdMedico.Rows)
            {
                if (row.RowIndex == grdMedico.SelectedIndex)
                {
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
    }
}