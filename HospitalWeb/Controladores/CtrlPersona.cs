using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HospitalWeb.Modelos
{
    public static class CtrlPersona
    {      
        public static List <Persona> ObtenerPersonaPorFiltro(int nFiltroSeleccionado, string sValorBusqueda)
        {
            List<Persona> lstAuxiliar = new List<Persona>();
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;

            switch (nFiltroSeleccionado)
            {
                case 0:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Nombre, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 1:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Edad.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 2:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Sexo.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 3:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.DocIdentidad, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 4:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Email, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 5:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.NumTelefono.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 6:
                    lstAuxiliar.AddRange(Registro.Personas.Where(p => compareInfo.IndexOf(p.Ocupacion, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
            }

            return lstAuxiliar;
        }
    }
}
