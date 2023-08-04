using HospitalWeb.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
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
        private void InicializarForm()
        {
            Registro.GenerarRegistros();
            BuscarPersonas();
            cboFiltro.SelectedIndex = 0;
        }
        private void BuscarPersonas()
        {
            List<Persona> lstAuxiliar = new List<Persona>();
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;

            switch (cboFiltro.SelectedIndex)
            {
                case 0:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Nombre, txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 1:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Edad.ToString(), txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 2:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Sexo.ToString(), txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 3:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.DocIdentidad, txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 4:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Email, txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 5:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.NumTelefono.ToString(), txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
                case 6:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Ocupacion, txtBuscar.Text, CompareOptions.IgnoreCase) > -1));
                    break;
            }

            var bindingList = new BindingList<Persona>(lstAuxiliar);
            var source = new BindingSource(bindingList, null);

            grdPersonas.DataSource = source;
            grdPersonas.DataBind();

            if (source.Count > 0)
            {                
                txtBuscar.Focus();
            }
        }

        protected void grdPersonas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPersonas.PageIndex = e.NewPageIndex;
            BuscarPersonas();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarPersonas();
        }

        protected void grdPersonas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Visible = false;
            }
        }
    }
}