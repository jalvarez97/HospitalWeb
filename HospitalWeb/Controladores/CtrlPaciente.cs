using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace HospitalWeb.Modelos
{
    public static class CtrlPaciente
    {
        public static Paciente ObtenerPaciente(string id)
        {
            Paciente oPaciente = new Paciente();
            List<Paciente> lstAuxiliar = new List<Paciente>();

            lstAuxiliar.AddRange(Registro.Pacientes.Where(p => p.ID.ToString() == id));            
           
            return oPaciente = lstAuxiliar[0]; 
        }

        public static List <Paciente> ObtenerPacientePorFiltro(int nFiltroSeleccionado, string sValorBusqueda)
        {
            List<Paciente> lstAuxiliar = new List<Paciente>();
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
           
            if (sValorBusqueda == null)
                sValorBusqueda = "";
            
            switch (nFiltroSeleccionado)
            {
                case 0:
                    lstAuxiliar.AddRange(Registro.Pacientes.Where(p => compareInfo.IndexOf(p.Nombre, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 1:
                    lstAuxiliar.AddRange(Registro.Pacientes.Where(p => compareInfo.IndexOf(p.Edad.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 2:
                    lstAuxiliar.AddRange(Registro.Pacientes.Where(p => compareInfo.IndexOf(p.Sexo.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 3:
                    lstAuxiliar.AddRange(Registro.Pacientes.Where(p => compareInfo.IndexOf(p.DocIdentidad, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 4:
                    lstAuxiliar.AddRange(Registro.Pacientes.Where(p => compareInfo.IndexOf(p.Email, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 5:
                    lstAuxiliar.AddRange(Registro.Pacientes.Where(p => compareInfo.IndexOf(p.NumTelefono.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 6:
                    lstAuxiliar.AddRange(Registro.Pacientes.Where(p => compareInfo.IndexOf(p.Enfermedad.ToString(), sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 7:
                    lstAuxiliar.AddRange(Registro.Pacientes.Where(p => compareInfo.IndexOf(p.Tratamiento, sValorBusqueda, CompareOptions.IgnoreCase) > -1));
                    break;
                case 8:
                    lstAuxiliar.AddRange(Registro.Pacientes.Where(p => p.MedicoAsignado.ToString() == sValorBusqueda));
                    break;
            }

            return lstAuxiliar;
        }

        public static void ModificarPaciente(Paciente oPacienteSeleccionado, Paciente oPaciente)
        {
            if (Registro.Pacientes.Contains(oPacienteSeleccionado))
            {
                Registro.Pacientes.Remove(oPacienteSeleccionado);
                Registro.Personas.Remove(oPacienteSeleccionado);
            }          
          
            Registro.Pacientes.Insert(0, oPaciente);
            Registro.Personas.Insert(0, oPaciente);
        }

        public static void InsertarPaciente(Paciente oPaciente)
        {
            Registro.Pacientes.Insert(0, oPaciente);
            Registro.Personas.Insert(0, oPaciente);
        }

        public static void EliminarPaciente(string id)
        {
            List<Paciente> lstAuxiliar = new List<Paciente>();

            lstAuxiliar.AddRange(Registro.Pacientes.Where(p => p.ID.ToString() == id));

            Registro.Pacientes.Remove(lstAuxiliar[0]);
            Registro.Personas.Remove(lstAuxiliar[0]);
        }
    }
}
