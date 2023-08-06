using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HospitalWeb.Modelos
{
    public static class CtrlMedico
    {
        public static Medico ObtenerMedico(string id)
        {
            Medico oMedico = new Medico();
            List<Medico> lstAuxiliar = new List<Medico>();

            lstAuxiliar.AddRange(Registro.Medicos.Where(p => p.ID.ToString() == id));            
           
            return oMedico = lstAuxiliar[0]; 
        }

        public static List <Medico> ObtenerMedicoPorFiltro(int nFiltroSeleccionado, string sValorBusqueda)
        {
            List<Medico> lstAuxiliar = new List<Medico>();
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            
            if (sValorBusqueda == null)
                sValorBusqueda = "";
            
            switch (nFiltroSeleccionado)
            {
                case 0:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Nombre, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 1:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Edad.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 2:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Sexo.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 3:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.DocIdentidad, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 4:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Email, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 5:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.NumTelefono.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 6:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.NumColegiado.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 7:
                    lstAuxiliar.AddRange(Registro.Medicos.Where(p => compareInfo.IndexOf(p.Especialidad, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
            }

           return lstAuxiliar;
        }

        public static void ModificarMedico(Medico oMedicoSeleccionado, Medico oMedico)
        {
            if (Registro.Medicos.Contains(oMedicoSeleccionado))
            {
                Registro.Medicos.Remove(oMedicoSeleccionado);
                Registro.Personas.Remove(oMedicoSeleccionado);
            }          
          
            Registro.Medicos.Insert(0, oMedico);
            Registro.Personas.Insert(0, oMedico);
        }

        public static void InsertarMedico(Medico oMedico)
        {
            Registro.Medicos.Insert(0, oMedico);
            Registro.Personas.Insert(0, oMedico);
        }

        public static void EliminarMedico(string id)
        {
            List<Medico> lstAuxiliar = new List<Medico>();

            lstAuxiliar.AddRange(Registro.Medicos.Where(p => p.ID.ToString() == id));

            Registro.Medicos.Remove(lstAuxiliar[0]);
            Registro.Personas.Remove(lstAuxiliar[0]);
        }
    }
}
